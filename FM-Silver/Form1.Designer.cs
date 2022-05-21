namespace FM_Silver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPast = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolWord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPowerPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPropertys = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolProcessMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSystemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCMD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReadLogs = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolProcessLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDirectoryLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolWrokStaitLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCloseThread = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(39, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(507, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Путь к используемой директории:";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(272, 379);
            this.listBox1.TabIndex = 7;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LeftMouseDoubleClick_listBox1);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_listBox1);
            this.listBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpen,
            this.toolCut,
            this.toolCopy,
            this.toolPast,
            this.toolDelete,
            this.toolRename,
            this.toolCreate,
            this.toolClear,
            this.toolPropertys});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 202);
            // 
            // toolOpen
            // 
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Size = new System.Drawing.Size(204, 22);
            this.toolOpen.Text = "Открыть";
            this.toolOpen.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolCut
            // 
            this.toolCut.Name = "toolCut";
            this.toolCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.toolCut.Size = new System.Drawing.Size(204, 22);
            this.toolCut.Text = "Вырезать";
            this.toolCut.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolCopy
            // 
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolCopy.Size = new System.Drawing.Size(204, 22);
            this.toolCopy.Text = "Копировать";
            this.toolCopy.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolPast
            // 
            this.toolPast.Name = "toolPast";
            this.toolPast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolPast.Size = new System.Drawing.Size(204, 22);
            this.toolPast.Text = "Вставить";
            this.toolPast.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolDelete
            // 
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolDelete.Size = new System.Drawing.Size(204, 22);
            this.toolDelete.Text = "Удалить";
            this.toolDelete.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolRename
            // 
            this.toolRename.Name = "toolRename";
            this.toolRename.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.toolRename.Size = new System.Drawing.Size(204, 22);
            this.toolRename.Text = "Переименовать";
            this.toolRename.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolCreate
            // 
            this.toolCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDirectory,
            this.toolText,
            this.toolWord,
            this.toolExcel,
            this.toolPowerPoint});
            this.toolCreate.Name = "toolCreate";
            this.toolCreate.Size = new System.Drawing.Size(204, 22);
            this.toolCreate.Text = "Создать";
            // 
            // toolDirectory
            // 
            this.toolDirectory.Name = "toolDirectory";
            this.toolDirectory.Size = new System.Drawing.Size(135, 22);
            this.toolDirectory.Text = "Directory";
            this.toolDirectory.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolText
            // 
            this.toolText.Name = "toolText";
            this.toolText.Size = new System.Drawing.Size(135, 22);
            this.toolText.Text = "Text";
            this.toolText.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolWord
            // 
            this.toolWord.Name = "toolWord";
            this.toolWord.Size = new System.Drawing.Size(135, 22);
            this.toolWord.Text = "Word";
            this.toolWord.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolExcel
            // 
            this.toolExcel.Name = "toolExcel";
            this.toolExcel.Size = new System.Drawing.Size(135, 22);
            this.toolExcel.Text = "Excel";
            this.toolExcel.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolPowerPoint
            // 
            this.toolPowerPoint.Name = "toolPowerPoint";
            this.toolPowerPoint.Size = new System.Drawing.Size(135, 22);
            this.toolPowerPoint.Text = "PowerPoint";
            this.toolPowerPoint.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolClear
            // 
            this.toolClear.Name = "toolClear";
            this.toolClear.Size = new System.Drawing.Size(204, 22);
            this.toolClear.Text = "Отчистить";
            this.toolClear.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // toolPropertys
            // 
            this.toolPropertys.Name = "toolPropertys";
            this.toolPropertys.Size = new System.Drawing.Size(204, 22);
            this.toolPropertys.Text = "Свойства";
            this.toolPropertys.Click += new System.EventHandler(this.checkClickToolAction);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "🔎";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 24);
            this.button3.TabIndex = 13;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(302, 70);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(273, 379);
            this.listBox2.TabIndex = 14;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolReadLogs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(583, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAbout,
            this.toolReference});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripDropDownButton1.Text = "Главное";
            // 
            // toolAbout
            // 
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(149, 22);
            this.toolAbout.Text = "О программе";
            this.toolAbout.Click += new System.EventHandler(this.checkClickToolProcess);
            // 
            // toolReference
            // 
            this.toolReference.Name = "toolReference";
            this.toolReference.Size = new System.Drawing.Size(149, 22);
            this.toolReference.Text = "Справка";
            this.toolReference.Click += new System.EventHandler(this.checkClickToolProcess);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProcessMonitor,
            this.toolSystemInfo,
            this.toolCMD});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(67, 22);
            this.toolStripDropDownButton2.Text = "Утилиты";
            // 
            // toolProcessMonitor
            // 
            this.toolProcessMonitor.Name = "toolProcessMonitor";
            this.toolProcessMonitor.Size = new System.Drawing.Size(184, 22);
            this.toolProcessMonitor.Text = "Монитор ресурсов";
            this.toolProcessMonitor.Click += new System.EventHandler(this.checkClickToolProcess);
            // 
            // toolSystemInfo
            // 
            this.toolSystemInfo.Name = "toolSystemInfo";
            this.toolSystemInfo.Size = new System.Drawing.Size(184, 22);
            this.toolSystemInfo.Text = "Сведения о системе";
            this.toolSystemInfo.Click += new System.EventHandler(this.checkClickToolProcess);
            // 
            // toolCMD
            // 
            this.toolCMD.Name = "toolCMD";
            this.toolCMD.Size = new System.Drawing.Size(184, 22);
            this.toolCMD.Text = "Командная строка";
            this.toolCMD.Click += new System.EventHandler(this.checkClickToolProcess);
            // 
            // toolReadLogs
            // 
            this.toolReadLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolReadLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProcessLog,
            this.toolDirectoryLog,
            this.toolWrokStaitLog,
            this.toolCloseThread});
            this.toolReadLogs.Image = ((System.Drawing.Image)(resources.GetObject("toolReadLogs.Image")));
            this.toolReadLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReadLogs.Name = "toolReadLogs";
            this.toolReadLogs.Size = new System.Drawing.Size(69, 22);
            this.toolReadLogs.Text = "Функции";
            // 
            // toolProcessLog
            // 
            this.toolProcessLog.Name = "toolProcessLog";
            this.toolProcessLog.Size = new System.Drawing.Size(262, 22);
            this.toolProcessLog.Text = "Открыть лог процессов";
            this.toolProcessLog.Click += new System.EventHandler(this.openProcessLog);
            // 
            // toolDirectoryLog
            // 
            this.toolDirectoryLog.Name = "toolDirectoryLog";
            this.toolDirectoryLog.Size = new System.Drawing.Size(262, 22);
            this.toolDirectoryLog.Text = "Открыть лог директорий";
            this.toolDirectoryLog.Click += new System.EventHandler(this.openFilesLog);
            // 
            // toolWrokStaitLog
            // 
            this.toolWrokStaitLog.Name = "toolWrokStaitLog";
            this.toolWrokStaitLog.Size = new System.Drawing.Size(262, 22);
            this.toolWrokStaitLog.Text = "Открыть лог рабочего множества";
            this.toolWrokStaitLog.Click += new System.EventHandler(this.openWorkStaitLog);
            // 
            // toolCloseThread
            // 
            this.toolCloseThread.Name = "toolCloseThread";
            this.toolCloseThread.Size = new System.Drawing.Size(262, 22);
            this.toolCloseThread.Text = "Закрыть лог";
            this.toolCloseThread.Click += new System.EventHandler(this.closedThread);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 453);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closedEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startContextTools);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public TextBox textBox1;
        private Label label2;
        private ListBox listBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolOpen;
        private ToolStripMenuItem toolCut;
        private ToolStripMenuItem toolCopy;
        private ToolStripMenuItem toolDelete;
        private ToolStripMenuItem toolRename;
        private ToolStripMenuItem toolPropertys;
        private Button button1;
        private Button button3;
        private ListBox listBox2;
        private ToolStripMenuItem toolClear;
        private ToolStripMenuItem toolPast;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem toolAbout;
        private ToolStripMenuItem toolReference;
        private ToolStripMenuItem toolProcessMonitor;
        private ToolStripMenuItem toolSystemInfo;
        private ToolStripMenuItem toolCMD;
        private ToolStripMenuItem toolCreate;
        private ToolStripMenuItem toolDirectory;
        private ToolStripMenuItem toolText;
        private ToolStripMenuItem toolWord;
        private ToolStripMenuItem toolExcel;
        private ToolStripMenuItem toolPowerPoint;
        private ToolStripDropDownButton toolReadLogs;
        private ToolStripMenuItem toolProcessLog;
        private ToolStripMenuItem toolDirectoryLog;
        private ToolStripMenuItem toolCloseThread;
        private ToolStripMenuItem toolWrokStaitLog;
        private System.Windows.Forms.Timer timer1;
    }
}