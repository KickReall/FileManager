using Microsoft.VisualBasic;
using System.IO.Pipes;

namespace FM_Silver
{
    public partial class HelpForm : Form
    {

        NamedPipeServerStream pipeServerStream;
        private bool threadLocks;


        private List<string> copy;
        private char[] notUse = {'/','\\',':','*','?', '«', '<', '>', '|' };
        private string path;
        private string logPath;
        private string type;
        private bool locks = false;
        private string threadType;
        public HelpForm(string path, string type, List<string> copy, string logPath, Form1 form, bool locks, string threadType)
        {
            InitializeComponent();
            this.path = path;
            this.type = type;
            this.copy = copy;
            this.logPath = logPath;
            this.threadLocks = locks;
            this.threadType = threadType;
            if (path != null && type != null)
            {
                Start();
            }
            else
            {
                Close();
            }
        }
        
        private void Start()
        {
            switch (type)
            {
                case "toolDirectory":
                    Text = "Создание папки.";
                    label1.Text = "Введите название каталога.";
                    break;
                case "toolText":
                    Text = "Создание текстового файла.";
                    label1.Text = "Введите название текстового файла.";
                    break;
                case "toolWord":
                    Text = "Создание Word файла.";
                    label1.Text = "Введите название документа.";
                    break;
                case "toolExcel":
                    Text = "Создание Excel файла.";
                    label1.Text = "Введите название таблицы.";
                    break;
                case "toolPowerPoint":
                    Text = "Создание PowerPoint файла.";
                    label1.Text = "Введите название презентации.";
                    break;
                case "toolRename":
                    Text = "Изменение имени файла/папки.";
                    label1.Text = "Введите новое имя.";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (locks == true)
            {
                switch (type)
                {
                    case "toolDirectory":
                        
                        if (path.Length == 3)
                        {
                            if (!copy.Contains("FM-" + textBox1.Text))
                            {
                                new DirectoryInfo(path + "\\FM-" + textBox1.Text).Create();
                                new WorksWithFile().writeInFile(logPath, "Создан", "FM-" + textBox1.Text, path + "\\FM-" + textBox1.Text, DateTime.Now.ToString());
                                if(threadLocks == true && threadType == "Directory")
                                {
                                    pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
                                    pipeServerStream.WaitForConnection();
                                    if (pipeServerStream.IsConnected)
                                    {
                                        try
                                        {
                                            using (StreamWriter write = new StreamWriter(pipeServerStream))
                                            {
                                                write.WriteLine("[Создана]-[" + "FM-" + textBox1.Text + "]-["+ path + "\\FM-" + textBox1.Text + "]-[" + DateTime.Now.ToString() + "]");
                                            }
                                        }
                                        catch (IOException error)
                                        {
                                            MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                                        }
                                    }
                                }
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Такой файл уже существует.");
                            }
                        }
                        else
                        {
                            if (!copy.Contains(textBox1.Text))
                            {
                                new DirectoryInfo(path + "\\" + textBox1.Text).Create();
                                new WorksWithFile().writeInFile(logPath, "Создан", textBox1.Text, path + "\\" + textBox1.Text, DateTime.Now.ToString());
                                if (threadLocks == true && threadType == "Directory")
                                {
                                    pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
                                    pipeServerStream.WaitForConnection();
                                    if (pipeServerStream.IsConnected)
                                    {
                                        try
                                        {
                                            using (StreamWriter write = new StreamWriter(pipeServerStream))
                                            {
                                                write.WriteLine("[Создана]-[" + textBox1.Text + "]-[" + path + "\\" + textBox1.Text + "]-[" + DateTime.Now.ToString() + "]");
                                            }
                                        }
                                        catch (IOException error)
                                        {
                                            MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                                        }
                                    }
                                }
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Такой файл уже существует.");
                            }
                        }
                        break;
                    case "toolText":
                        if (!copy.Contains(textBox1.Text + ".txt"))
                        {
                            new FileInfo(path + "\\" + textBox1.Text + ".txt").Create().Close();
                            new WorksWithFile().writeInFile(logPath, "Создан", textBox1.Text + ".txt", path + "\\" + textBox1.Text + ".txt", DateTime.Now.ToString());
                            if (threadLocks == true && threadType == "Directory")
                            {
                                pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
                                pipeServerStream.WaitForConnection();
                                if (pipeServerStream.IsConnected)
                                {
                                    try
                                    {
                                        using (StreamWriter write = new StreamWriter(pipeServerStream))
                                        {
                                            write.WriteLine("[Создан]-[" + textBox1.Text + ".txt]-[" + path + "\\" + textBox1.Text + ".txt]-[" + DateTime.Now.ToString() + "]");
                                        }
                                    }
                                    catch (IOException error)
                                    {
                                        MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                                    }
                                }
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Такой файл уже существует.");
                        }
                        break;
                    case "toolWord":
                        if (!copy.Contains(textBox1.Text + ".doc"))
                        {
                            new FileInfo(path + "\\" + textBox1.Text + ".docx").Create().Close();
                            new WorksWithFile().writeInFile(logPath, "Создан", textBox1.Text + ".doc", path + "\\" + textBox1.Text + ".doc", DateTime.Now.ToString());
                            if (threadLocks == true && threadType == "Directory")
                            {
                                pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
                                pipeServerStream.WaitForConnection();
                                if (pipeServerStream.IsConnected)
                                {
                                    try
                                    {
                                        using (StreamWriter write = new StreamWriter(pipeServerStream))
                                        {
                                            write.WriteLine("[Создан]-[" + textBox1.Text + ".doc]-[" + path + "\\" + textBox1.Text + ".doc]-[" + DateTime.Now.ToString() + "]");
                                        }
                                    }
                                    catch (IOException error)
                                    {
                                        MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                                    }
                                }
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Такой файл уже существует.");
                        }
                        break;
                    case "toolExcel":
                        if (!copy.Contains(textBox1.Text + ".xlsx"))
                        {
                            new FileInfo(path + "\\" + textBox1.Text + ".xlsx").Create().Close();
                            new WorksWithFile().writeInFile(logPath, "Создан", textBox1.Text + ".xlsx", path + "\\" + textBox1.Text + ".xlsx", DateTime.Now.ToString());
                            if (threadLocks == true && threadType == "Directory")
                            {
                                pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
                                pipeServerStream.WaitForConnection();
                                if (pipeServerStream.IsConnected)
                                {
                                    try
                                    {
                                        using (StreamWriter write = new StreamWriter(pipeServerStream))
                                        {
                                            write.WriteLine("[Создан]-[" + textBox1.Text + ".xlsx]-[" + path + "\\" + textBox1.Text + ".xlsx]-[" + DateTime.Now.ToString() + "]");
                                        }
                                    }
                                    catch (IOException error)
                                    {
                                        MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                                    }
                                }
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Такой файл уже существует.");
                        }
                        break;
                    case "toolPowerPoint":
                        if (!copy.Contains(textBox1.Text + ".pptx"))
                        {

                            new FileInfo(path + "\\" + textBox1.Text + ".pptx").Create().Close();
                            new WorksWithFile().writeInFile(logPath, "Создан", textBox1.Text + ".pptx", path + "\\" + textBox1.Text + ".pptx", DateTime.Now.ToString());
                            if (threadLocks == true && threadType == "Directory")
                            {
                                pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
                                pipeServerStream.WaitForConnection();
                                if (pipeServerStream.IsConnected)
                                {
                                    try
                                    {
                                        using (StreamWriter write = new StreamWriter(pipeServerStream))
                                        {
                                            write.WriteLine("[Создан]-[" + textBox1.Text + ".pptx]-[" + path + "\\" + textBox1.Text + ".pptx]-[" + DateTime.Now.ToString() + "]");
                                        }
                                    }
                                    catch (IOException error)
                                    {
                                        MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                                    }
                                }
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Такой файл уже существует.");
                        }
                        break;
                    case "toolRename":
                        rename();
                        break;
                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int count = notUse.Count();
            if (textBox1.Text != "")
            {
                foreach (char ch in notUse)
                {
                    if (!textBox1.Text.Contains(ch))
                    {
                        count--;
                    };
                }
                if (count == 0)
                {
                    locks = true;
                }
                else
                {
                    locks = false;
                }
            }

        }

        private void rename()
        {
            string exstension = new DirectoryInfo(path).Extension;
            string oldPath = path;
            path = path.Remove(path.IndexOf(new DirectoryInfo(path).Name));

            if (!new DirectoryInfo(oldPath).Name.Contains("FM-"))
            {
                path += "\\" + textBox1.Text + exstension;
            }
            else
            {
                path += "\\FM-" + textBox1.Text + exstension;
            }



            if (!copy.Contains(textBox1.Text + exstension))
            {
                FileSystem.Rename(oldPath, path);
                new WorksWithFile().writeInFile(logPath, "Переименован", new DirectoryInfo(oldPath).Name, oldPath, new DirectoryInfo(path).Name, path, DateTime.Now.ToString());
                if (threadLocks == true && threadType == "Directory")
                {
                    pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
                    pipeServerStream.WaitForConnection();
                    if (pipeServerStream.IsConnected)
                    {
                        try
                        {
                            using (StreamWriter write = new StreamWriter(pipeServerStream))
                            {
                                write.WriteLine("[Переименован]-[" + new DirectoryInfo(oldPath).Name + "]-[" + oldPath + "]>>>[" + new DirectoryInfo(path).Name + "]-[" + path + "]-["+ DateTime.Now.ToString()+"]");
                            }
                        }
                        catch (IOException error)
                        {
                            MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                        }
                    }
                }
                Close();
            }
            else
            {
                MessageBox.Show("Такой файл уже существует.");
            }
        }
    }
}
