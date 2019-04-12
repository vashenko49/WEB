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
using Ionic.Zip;
using System.IO;
using System.Windows.Automation;
namespace WebPageGrabber
{
    public partial class MainForm : Form
    {
        TcpModule _tcpmodule = new TcpModule();
        FolderBrowserDialog bd = new FolderBrowserDialog();

        Thread GrabberThread;
        string defauldFolder = @"D:\temp_web";
        string strCmdText= @"D:\temp_web\number";

        private string GetURLWEBPAGE()
        {
            var root = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"));
            var textP = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            var vpi = textP.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty).ToString();
            return vpi;
        }
        int numberFolder = 0;
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



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        #region выкачка сайта
        public void ReEnableGrabButton()
        {
            btGrab.Enabled = true;
            btAbort.Enabled = false;
        }
        private void btAbort_Click(object sender, EventArgs e)
        {
            //rockinbbv's branch
            try
            {
                GrabberThread.Abort();
                MessageBox.Show("Задача отменена!");
                ReEnableGrabButton();
                UpdateStatusText("Задача отменена!");
                label6.Text = "Задача отменена!";                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка прерывания " + Environment.NewLine + "Подробности:" + ex.Message);
            }


        }
        private void btGrab_Click(object sender, EventArgs e)
        {
            tbURL.Text = GetURLWEBPAGE();
            try
            {
                // Итак, пользователь нажал кнопку Grab! Прежде чем мы начнем захватывать, нам нужно проверить все входные данные.

                // Мы начинаем со сбора настроек, и это будет нулевым, если какой-либо параметр недействителен
                SettingsObject settings = GetSettings();

                if (settings != null)
                {
                    // Настройки действительны и мы готовы!
                    btGrab.Enabled = false;
                    progressBar1.Value = 0;


                    // Создать новый объект webGrabber, чтобы начать нашу работу! : D
                    WebPageGrabber Grabber = new WebPageGrabber(settings);
                    GrabberThread = new Thread(() => Grabber.StartGrab());
                    GrabberThread.Start();

                    btAbort.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникло исключение!" + Environment.NewLine + Environment.NewLine + "Подробности:" + Environment.NewLine + ex.Message);
            }
            webBrowser1.Navigate(tbURL.Text);


        }
        private SettingsObject GetSettings()
        {




            //Проверка правильности введенного URL
            if (!Utilities.IsUrlValid(tbURL.Text))
            {
                UpdateStatusText("Неверная ссылка! Убедитесь, что вы начинаете с http: //");
                return null;
            }

            //Получить папку назначения
            numberFolder =numberFolder+1;
            strCmdText = strCmdText + Convert.ToString(numberFolder);
            Directory.CreateDirectory(strCmdText);
            string DestinationFolder = (strCmdText);

            if (DestinationFolder == string.Empty || !System.IO.Directory.Exists(DestinationFolder))
            {
                //Ошибка из-за неверного каталога.
                UpdateStatusText("Недействительным каталог! Пожалуйста, попробуйте еще раз и выберите правильный каталог.");     
                return null;
            }


            //Проверьте другие настройки
            tbSavePath.Text = DestinationFolder;
            tbProgress.Clear();

            //проверить глубину


            //27Создать новый объект настроек
            SettingsObject Settings = new SettingsObject(this);
            Settings.DestinationFolder = DestinationFolder;
            Settings.Depth = Convert.ToInt16( tbDepth.Text);
            Settings.URL = tbURL.Text;
            
            

            return Settings;
        }

        private void UpdateStatusText(string msg)
        {
            lbStatusText.Text = msg;

            tbProgress.Text += msg + Environment.NewLine;
            tbProgress.SelectionStart = tbProgress.Text.Length;
            tbProgress.ScrollToCaret();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbDepth.Text, "[^0-9]"))
            {
                MessageBox.Show("Пожалуйста, введите только число");
                tbDepth.Text.Remove(tbDepth.Text.Length - 1);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbResolveRelativePath_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region перекачка данных

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
                ShowReceiveMessage("Письмо: " + e.sendInfo.message);
            }

            if (e.sendInfo.filesize > 0)
            {
                ShowReceiveMessage("Файл: " + e.sendInfo.filename);
            }

        }


        private void buttonConnect_Click(object sender, EventArgs e)
        {
            _tcpmodule.ConnectClient(textBoxIPserver.Text);
        }
        private void buttonStartServer_Click_1(object sender, EventArgs e)
        {
            _tcpmodule.StartServer();
        }

        private void buttonAddFile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _tcpmodule.SendFileName = dlg.FileName;
                labelFileName.Text = dlg.SafeFileName;
            }
        }
        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
        private void Form1_FormClosed(object sender, FormClosingEventArgs e)
        {
            clearFolder(defauldFolder);
            _tcpmodule.CloseSocket();
        }

        private void buttonSendData_Click_1(object sender, EventArgs e)
        {
            Thread t = new Thread(_tcpmodule.SendData);
            t.Start();
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




        #endregion

        private void btn_clearSendbox_Click(object sender, EventArgs e)
        {
            textBoxSend.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }




        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            bd.SelectedPath = strCmdText;

        }

        private void archFolder()
        {
            string tempNameArch = strCmdText + ".zip";
            ZipFile zf = new ZipFile(tempNameArch);
            zf.AddDirectory(strCmdText);
            zf.Save();
        }

        private void tbURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            archFolder();
        }
    }
}
