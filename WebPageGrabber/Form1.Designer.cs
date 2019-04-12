namespace WebPageGrabber
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tbProgress = new System.Windows.Forms.TextBox();
            this.btAbort = new System.Windows.Forms.Button();
            this.btGrab = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbStatusText = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tbDepth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxIPserver = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.btn_clearSendbox = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(19, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 731);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbProgress);
            this.tabPage1.Controls.Add(this.btAbort);
            this.tabPage1.Controls.Add(this.btGrab);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.lbStatusText);
            this.tabPage1.Controls.Add(this.lbStatus);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbSavePath);
            this.tabPage1.Controls.Add(this.tbURL);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 705);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 515);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Enter a Valid URL";
            // 
            // tbProgress
            // 
            this.tbProgress.Location = new System.Drawing.Point(27, 160);
            this.tbProgress.Multiline = true;
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.ReadOnly = true;
            this.tbProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbProgress.Size = new System.Drawing.Size(647, 339);
            this.tbProgress.TabIndex = 4;
            this.tbProgress.WordWrap = false;
            // 
            // btAbort
            // 
            this.btAbort.AllowDrop = true;
            this.btAbort.Enabled = false;
            this.btAbort.Location = new System.Drawing.Point(412, 119);
            this.btAbort.Name = "btAbort";
            this.btAbort.Size = new System.Drawing.Size(75, 23);
            this.btAbort.TabIndex = 3;
            this.btAbort.Text = "Abort";
            this.btAbort.UseVisualStyleBackColor = true;
            this.btAbort.Click += new System.EventHandler(this.btAbort_Click);
            // 
            // btGrab
            // 
            this.btGrab.Location = new System.Drawing.Point(521, 119);
            this.btGrab.Name = "btGrab";
            this.btGrab.Size = new System.Drawing.Size(153, 23);
            this.btGrab.TabIndex = 3;
            this.btGrab.Text = "Select Folder and Grab!";
            this.btGrab.UseVisualStyleBackColor = true;
            this.btGrab.Click += new System.EventHandler(this.btGrab_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(27, 533);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(647, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // lbStatusText
            // 
            this.lbStatusText.AutoSize = true;
            this.lbStatusText.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusText.Location = new System.Drawing.Point(117, 293);
            this.lbStatusText.Name = "lbStatusText";
            this.lbStatusText.Size = new System.Drawing.Size(11, 18);
            this.lbStatusText.TabIndex = 1;
            this.lbStatusText.Text = ".";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(24, 512);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(59, 18);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "STATUS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Progress:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Save Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // tbSavePath
            // 
            this.tbSavePath.Location = new System.Drawing.Point(104, 84);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.ReadOnly = true;
            this.tbSavePath.Size = new System.Drawing.Size(570, 20);
            this.tbSavePath.TabIndex = 0;
            this.tbSavePath.Text = "      You can select folder when you click grab";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(104, 46);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(570, 20);
            this.tbURL.TabIndex = 0;
            this.tbURL.TextChanged += new System.EventHandler(this.tbURL_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Controls.Add(this.tbDepth);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 705);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(7, 33);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(782, 666);
            this.webBrowser1.TabIndex = 6;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // tbDepth
            // 
            this.tbDepth.Location = new System.Drawing.Point(151, 7);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(100, 20);
            this.tbDepth.TabIndex = 1;
            this.tbDepth.TabStop = false;
            this.tbDepth.Text = "2";
            this.tbDepth.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Depth:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelFileName);
            this.groupBox1.Location = new System.Drawing.Point(1099, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 32);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // labelFileName
            // 
            this.labelFileName.Location = new System.Drawing.Point(6, 14);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(230, 16);
            this.labelFileName.TabIndex = 10;
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1141, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "IP адрес сервера";
            // 
            // textBoxIPserver
            // 
            this.textBoxIPserver.Location = new System.Drawing.Point(1242, 36);
            this.textBoxIPserver.Name = "textBoxIPserver";
            this.textBoxIPserver.Size = new System.Drawing.Size(100, 20);
            this.textBoxIPserver.TabIndex = 20;
            this.textBoxIPserver.Text = "127.0.0.1";
            this.textBoxIPserver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1096, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Отправка";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(850, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Получение";
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(1099, 240);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(100, 23);
            this.buttonAddFile.TabIndex = 16;
            this.buttonAddFile.Text = "Добавить файл";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click_1);
            // 
            // buttonSendData
            // 
            this.buttonSendData.Location = new System.Drawing.Point(1205, 240);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(137, 23);
            this.buttonSendData.TabIndex = 17;
            this.buttonSendData.Text = "Отправить сообщение";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.buttonSendData_Click_1);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(1099, 97);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(243, 108);
            this.textBoxSend.TabIndex = 15;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(953, 33);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(90, 23);
            this.buttonConnect.TabIndex = 14;
            this.buttonConnect.Text = "Подключение";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(850, 97);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(243, 108);
            this.listBox1.TabIndex = 13;
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(850, 33);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(97, 23);
            this.buttonStartServer.TabIndex = 12;
            this.buttonStartServer.Text = "Старт сервер";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click_1);
            // 
            // btn_clearSendbox
            // 
            this.btn_clearSendbox.Location = new System.Drawing.Point(1348, 97);
            this.btn_clearSendbox.Name = "btn_clearSendbox";
            this.btn_clearSendbox.Size = new System.Drawing.Size(75, 23);
            this.btn_clearSendbox.TabIndex = 23;
            this.btn_clearSendbox.Text = "Очистка";
            this.btn_clearSendbox.UseVisualStyleBackColor = true;
            this.btn_clearSendbox.Click += new System.EventHandler(this.btn_clearSendbox_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(853, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "arch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 754);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_clearSendbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxIPserver);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "WebPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btGrab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbStatusText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbProgress;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAbort;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxIPserver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonSendData;
        public System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.TextBox tbDepth;
        private System.Windows.Forms.Button btn_clearSendbox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
    }
}

