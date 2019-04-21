using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Ionic.Zip;

namespace WebPageGrabber
{
    public partial class MainForm : Form
    {
        Thread GrabberThread;
        TcpModule _tcpmodule = new TcpModule();
        string[] information_aboutclient;
        int nuber_client = 4;
        string[,] login_and_passsword_customers = { { "qwer", "123" }, { "asdf", "456" }, { "zxcv", "789" }, { "1234", "123" } };
        public string Server_response = null;
        string defauldFolder = @"D:\temp_web";
        string strCmdText = @"D:\temp_web\number";
        string strCmdTextEdit = @"D:\temp_web\number";
        string name_file;
        int numver_for = 0;
        public MainForm()
        {
            InitializeComponent();
            _tcpmodule.Receive += new TcpModule.ReceiveEventHandler(_tcpmodule_Receive);
            _tcpmodule.Disconnected += new TcpModule.DisconnectedEventHandler(_tcpmodule_Disconnected);
            _tcpmodule.Connected += new TcpModule.ConnectedEventHandler(_tcpmodule_Connected);
            _tcpmodule.Accept += new TcpModule.AcceptEventHandler(_tcpmodule_Accept);

            _tcpmodule.Parent = this;


            listBox1.HorizontalScrollbar = true;
        }
        /// <summary>
        /// Создает архив archiveName , содержащий файлы fileNames
        /// </summary>
        /// <param name="archiver">файл архиватора вместе с полным путем</param>
        /// <param name="fileNames">Файлы для запаковки (можно с маской *)</param>
        /// <param name="archiveName">Имя архива с полным путем</param>
        public static void AddToArchive(string archiver, string fileNames, string archiveName)
        {
            try
            {
                // Предварительные проверки
                if (!File.Exists(archiver))
                    throw new Exception("Архиватор 7z по пути \"" + archiver +
                    "\" не найден");

                // Формируем параметры вызова 7z
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = archiver;
                // добавить в архив с максимальным сжатием
                startInfo.Arguments = " a -mx9 ";
                // имя архива
                startInfo.Arguments += "\"" + archiveName + "\"";
                // файлы для запаковки
                startInfo.Arguments += " \"" + fileNames + "\"";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                int sevenZipExitCode = 0;
                using (Process sevenZip = Process.Start(startInfo))
                {
                    sevenZip.WaitForExit();
                    sevenZipExitCode = sevenZip.ExitCode;
                }
                // Если с первого раза не получилось,
                //пробуем еще раз через 1 секунду
                if (sevenZipExitCode != 0 && sevenZipExitCode != 1)
                {
                    using (Process sevenZip = Process.Start(startInfo))
                    {
                        Thread.Sleep(1000);
                        sevenZip.WaitForExit();
                        switch (sevenZip.ExitCode)
                        {
                            case 0: return; // Без ошибок и предупреждений
                            case 1: return; // Есть некритичные предупреждения
                            case 2: throw new Exception("Фатальная ошибка");
                            case 7: throw new Exception("Ошибка в командной строке");
                            case 8:
                                throw new Exception("Недостаточно памяти для выполнения операции");
                            case 225:
                                throw new Exception("Пользователь отменил выполнение операции");
                            default:
                                throw new Exception("Архиватор 7z вернул недокументированный код ошибки: " + sevenZip.ExitCode.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("SevenZip.AddToArchive: " + e.Message);
            }
        }
        // Пример вызова функции AddToArchive
       // AddToArchive(@"C:\Program Files\7-Zip\7z.exe", @"C:\archive\*.*",
     //   @"C:\archive.7z");
        // После вызова AddToArchive в архиве C:\archive.7z будут лежать файлы
        //из каталога C:\archive
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void ReEnableGrabButton()
        {
            btGrab.Enabled = true;
        }
        private void btAbort_Click(object sender, EventArgs e)
        {

            try
            {
                GrabberThread.Abort();
                MessageBox.Show("Task aborted!");
                ReEnableGrabButton();
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error aborting " + Environment.NewLine + "Details: " + ex.Message);
            }


        }
        private void btGrab_ClickGOGO()
        {
            try
            {
                SettingsObject settings = GetSettings();
                if (settings != null)
                {
                    //The settings are valid and we are good to go! 
                    btGrab.Enabled = false;


                    //Create a new webGrabber object to start our work! :D
                    WebPageGrabber Grabber = new WebPageGrabber(settings);
                    GrabberThread = new Thread(() => Grabber.StartGrab());
                    GrabberThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured!" + Environment.NewLine + Environment.NewLine + "Details: " + Environment.NewLine + ex.Message);
            }
        }
        private void btGrab_Click(object sender, EventArgs e)
        {

            try
            {
                SettingsObject settings = GetSettings();       
                if (settings != null)
                {
                    //The settings are valid and we are good to go! 
                    btGrab.Enabled = false;


                    //Create a new webGrabber object to start our work! :D
                    WebPageGrabber Grabber = new WebPageGrabber(settings);
                    GrabberThread = new Thread(() => Grabber.StartGrab());
                    GrabberThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured!" + Environment.NewLine + Environment.NewLine + "Details: " + Environment.NewLine + ex.Message);
            }
        }
        private bool verification_login_password(string login, string password)
        {
            bool result = false;
            for (int i = 0; i < nuber_client; i++)
            {
                if (login == login_and_passsword_customers[i, 0] && password == login_and_passsword_customers[i, 1])
                {
                    result = true;
                }
            }
            return result;
        }
        private SettingsObject GetSettings()
        {
            //////////////////////////////////////////
            string DestinationFolder = strCmdTextEdit;
            //////////////////////////////////////////

            //Create new Settings Object:
            SettingsObject Settings = new SettingsObject(this);
            Settings.DestinationFolder = DestinationFolder;
            Settings.Depth = Convert.ToInt16(information_aboutclient[3]);
            //////////////////////////////////////////
            Settings.URL = information_aboutclient[0];
            /////////////////////////////////////////
            return Settings;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            _tcpmodule.CloseSocket();
            foreach (string file in Directory.GetFiles(defauldFolder))
                File.Delete(file);
        }
        void _tcpmodule_Accept(object sender)
        {
            ShowReceiveMessage("Клиент подключился!");
        }

        void _tcpmodule_Connected(object sender, string result)
        {
            ShowReceiveMessage(result);
        }

        void _tcpmodule_Disconnected(object sender, string result)
        {
            ShowReceiveMessage(result);
        }

        void _tcpmodule_Receive(object sender, ReceiveEventArgs e)
        {

            if (e.sendInfo.message != null)
            {
                ShowReceiveMessage(e.sendInfo.message);
                information_aboutclient = e.sendInfo.message.Split('▼');
            }

            if (e.sendInfo.filesize > 0)
            {
                ShowReceiveMessage("Файл: " + e.sendInfo.filename);
            }
            
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            _tcpmodule.StartServer();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            _tcpmodule.ConnectClient(textBoxIPserver.Text);
        }

        private void buttonSendData_Click(object sender, EventArgs e)
        {
            if (verification_login_password(information_aboutclient[1], information_aboutclient[2]) == false)
            {
                Server_response = "Ошибка вохода";
            }
            else
            {
                numver_for++;
                strCmdTextEdit = strCmdText + Convert.ToString(numver_for);
                name_file = strCmdTextEdit + ".zip";
                Directory.CreateDirectory(strCmdTextEdit);
                btGrab.PerformClick();
                System.Threading.Thread.Sleep(5000);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Zip files (*.zip)|*.zip";
                ZipFile zf = new ZipFile(name_file);
                zf.AddDirectory(strCmdTextEdit);
                zf.Save();
                MessageBox.Show("Архивация прошла успешно.", "Выполнено");
                buttonAddFile.PerformClick();

            }
                Thread t = new Thread(_tcpmodule.SendData);
                t.Start();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            _tcpmodule.SendFileName = name_file;
        }

        delegate void UpdateReceiveDisplayDelegate(string message);
        public void ShowReceiveMessage(string message)
        {
            if (listBox1.InvokeRequired == true)
            {
                UpdateReceiveDisplayDelegate rdd = new UpdateReceiveDisplayDelegate(ShowReceiveMessage);

                // Данный метод вызывается в дочернем потоке,
                // ищет основной поток и выполняет делегат указанный в качестве параметра 
                // в главном потоке, безопасно обновляя интерфейс формы.
                Invoke(rdd, new object[] { message });
            }
            else
            {
                // Если не требуется вызывать метод Invoke, обратимся напрямую к элементу формы.
                listBox1.Items.Add((listBox1.Items.Count + 1).ToString() + ". " + message);
            }
        }

        private void ChangeBackColor(object sender, EventArgs e)
        {

        }
        delegate void BackColorFormDelegate(Color color);
        public void ChangeBackColor(Color color)
        {
            if (this.InvokeRequired == true)
            {
                BackColorFormDelegate bcf = new BackColorFormDelegate(ChangeBackColor);

                // Данный метод вызывается в дочернем потоке,
                // ищет основной поток и выполняет делегат указанный в качестве параметра 
                // в главном потоке, безопасно обновляя интерфейс формы.
                Invoke(bcf, new object[] { color });
            }
            else
            {
                this.BackColor = color;
            }
        }
    }
}
