using System.Diagnostics;
using System.IO.Pipes;
namespace FM_Silver
{
    public partial class Form1 : Form
    {

        CheckDrivers drivers = new CheckDrivers(); //создание экземпляра объекта, хранящего методы для взаимодействия с дисками
        CheckDirectory directory = new CheckDirectory(); // создание экземпляра объекта, хранящего методы для взаимодействия с директориями и файлами.
        WMIChecking processCheck; // создание объекта, хранящего методы для проверки информации о подключаемых и отключаемых устройствах.
        string[] paths = new string[6]; //массив, хранящий пути к файлам папки Documentation
        string[] ccPaths = new string[2] { "", "" };//массив хранящий пути к вырезаемым/копируемым файлам и папкам
        bool[] cc = new bool[2] { false, false };//массив хранящий статутсы вырезания/копирования (true, false)
        string[] main = { "System", "FM-Silver", "Корзина", "Документы", "Изображения" };//массив запрещённых имён папок и файлов

        int time;
        bool locks = false;
        string type = "";

        public Form1()
        {
            InitializeComponent();
            Start();
            setMainPaths();
            processCheck = new WMIChecking(paths[2]);
        }

        //
        //Методы обновлений и проверки.
        //

        public void Start()
        {
            textBox1.Text = "";
            listBox1.DataSource = drivers.getDrivers();
            listBox2.DataSource = drivers.getDriversStats();

        }
        public void updateListBox(string path)
        {
            if (Directory.Exists(path))
            {
                directory.setInfo(path);
                listBox1.DataSource = directory.getDF();
                listBox2.DataSource = directory.getStats();
                listBox1.ClearSelected();
            }
            else
            {
                Start();
            }

        }
        public void setParametrs(string name, int index, string path)
        {
            if (index != -1)
            {
                if (path != "")
                {
                    if (!main.Contains(name) && directory.getParentPath(name).Length > 3)
                    {
                        if (cc[0] != true && cc[1] != true)
                        {
                            toolOpen.Enabled = true;
                            toolCut.Enabled = true;
                            toolCopy.Enabled = true;
                            toolDelete.Enabled = true;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = false;
                            toolClear.Enabled = false;
                            toolPast.Enabled = false;
                            toolRename.Enabled = true;

                            toolOpen.Visible = true;
                            toolCut.Visible = true;
                            toolCopy.Visible = true;
                            toolDelete.Visible = true;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = false;
                            toolClear.Visible = false;
                            toolPast.Visible = false;
                            toolRename.Visible = true;
                        }
                        else
                        {
                            if (directory.getPath(name) == ccPaths[0] || directory.getPath(name) == ccPaths[1])
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = false;
                                toolPast.Enabled = false;
                                toolRename.Enabled = false;

                                toolOpen.Visible = true;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = false;
                                toolPast.Visible = false;
                                toolRename.Visible = false;
                            }
                            else
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = true;
                                toolCopy.Enabled = true;
                                toolDelete.Enabled = true;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = false;
                                toolPast.Enabled = true;
                                toolRename.Enabled = true;

                                toolOpen.Visible = true;
                                toolCut.Visible = true;
                                toolCopy.Visible = true;
                                toolDelete.Visible = true;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = false;
                                toolPast.Visible = true;
                                toolRename.Visible = true;
                            }
                        }
                    }
                    else if (!main.Contains(name) && directory.getParentPath(name).Length == 3)
                    {
                        if (cc[0] != true && cc[1] != true)
                        {
                            toolOpen.Enabled = true;
                            toolCut.Enabled = true;
                            toolCopy.Enabled = true;
                            toolDelete.Enabled = true;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = false;
                            toolClear.Enabled = false;
                            toolPast.Enabled = false;
                            toolRename.Enabled = true;

                            toolOpen.Visible = true;
                            toolCut.Visible = true;
                            toolCopy.Visible = true;
                            toolDelete.Visible = true;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = false;
                            toolClear.Visible = false;
                            toolPast.Visible = false;
                            toolRename.Visible = true;
                        }
                        else
                        {
                            if (directory.getPath(name) == ccPaths[0] || directory.getPath(name) == ccPaths[1])
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = false;
                                toolPast.Enabled = false;
                                toolRename.Enabled = false;

                                toolOpen.Visible = true;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = false;
                                toolPast.Visible = false;
                                toolRename.Visible = false;
                            }
                            else
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = true;
                                toolCopy.Enabled = true;
                                toolDelete.Enabled = true;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = false;
                                toolPast.Enabled = true;
                                toolRename.Enabled = false;

                                toolOpen.Visible = true;
                                toolCut.Visible = true;
                                toolCopy.Visible = true;
                                toolDelete.Visible = true;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = false;
                                toolPast.Visible = true;
                                toolRename.Visible = false;
                            }
                        }
                    }
                    else if (main.Contains(name) && directory.getParentPath(name).Length > 3)
                    {
                        if (cc[0] != true && cc[1] != true)
                        {
                            if (name == "System")
                            {
                                toolOpen.Enabled = false;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = false;
                                toolPast.Enabled = false;
                                toolRename.Enabled = false;

                                toolOpen.Visible = false;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = false;
                                toolPast.Visible = false;
                                toolRename.Visible = false;
                            }
                            else if (name == "Корзина")
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = true;
                                toolPast.Enabled = false;
                                toolRename.Enabled = false;

                                toolOpen.Visible = true;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = true;
                                toolPast.Visible = false;
                                toolRename.Visible = false;
                            }
                            else
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = false;
                                toolPast.Enabled = false;
                                toolRename.Enabled = false;

                                toolOpen.Visible = true;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = false;
                                toolPast.Visible = false;
                                toolRename.Visible = false;
                            }
                        }
                        else
                        {
                            if (name == "System")
                            {
                                toolOpen.Enabled = false;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = false;
                                toolPast.Enabled = false;
                                toolRename.Enabled = false;

                                toolOpen.Visible = false;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = false;
                                toolPast.Visible = false;
                                toolRename.Visible = false;
                            }
                            else if (name == "Корзина")
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = true;
                                toolPast.Enabled = true;
                                toolRename.Enabled = false;

                                toolOpen.Visible = true;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = true;
                                toolPast.Visible = true;
                                toolRename.Visible = false;
                            }
                            else
                            {
                                toolOpen.Enabled = true;
                                toolCut.Enabled = false;
                                toolCopy.Enabled = false;
                                toolDelete.Enabled = false;
                                toolPropertys.Enabled = true;
                                toolCreate.Enabled = false;
                                toolClear.Enabled = true;
                                toolPast.Enabled = true;
                                toolRename.Enabled = false;

                                toolOpen.Visible = true;
                                toolCut.Visible = false;
                                toolCopy.Visible = false;
                                toolDelete.Visible = false;
                                toolPropertys.Visible = true;
                                toolCreate.Visible = false;
                                toolClear.Visible = true;
                                toolPast.Visible = true;
                                toolRename.Visible = false;
                            }
                        }
                    }
                    else if (main.Contains(name) && directory.getParentPath(name).Length == 3)
                    {
                        if (cc[0] != true && cc[1] != true)
                        {
                            toolOpen.Enabled = true;
                            toolCut.Enabled = false;
                            toolCopy.Enabled = false;
                            toolDelete.Enabled = false;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = false;
                            toolClear.Enabled = false;
                            toolPast.Enabled = false;
                            toolRename.Enabled = false;

                            toolOpen.Visible = true;
                            toolCut.Visible = false;
                            toolCopy.Visible = false;
                            toolDelete.Visible = false;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = false;
                            toolClear.Visible = false;
                            toolPast.Visible = false;
                            toolRename.Visible = false;
                        }
                        else
                        {
                            toolOpen.Enabled = true;
                            toolCut.Enabled = false;
                            toolCopy.Enabled = false;
                            toolDelete.Enabled = false;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = false;
                            toolClear.Enabled = false;
                            toolPast.Enabled = true;
                            toolRename.Enabled = false;

                            toolOpen.Visible = true;
                            toolCut.Visible = false;
                            toolCopy.Visible = false;
                            toolDelete.Visible = false;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = false;
                            toolClear.Visible = false;
                            toolPast.Visible = true;
                            toolRename.Visible = false;
                        }
                    }
                    else
                    {
                        toolOpen.Enabled = true;
                        toolCut.Enabled = false;
                        toolCopy.Enabled = false;
                        toolDelete.Enabled = false;
                        toolPropertys.Enabled = true;
                        toolCreate.Enabled = false;
                        toolClear.Enabled = false;
                        toolPast.Enabled = false;
                        toolRename.Enabled = false;

                        toolOpen.Visible = true;
                        toolCut.Visible = false;
                        toolCopy.Visible = false;
                        toolDelete.Visible = false;
                        toolPropertys.Visible = true;
                        toolCreate.Visible = false;
                        toolClear.Visible = false;
                        toolPast.Visible = false;
                        toolRename.Visible = false;
                    }
                }
                else
                {
                    toolOpen.Enabled = true;
                    toolCut.Enabled = false;
                    toolCopy.Enabled = false;
                    toolDelete.Enabled = false;
                    toolPropertys.Enabled = true;
                    toolCreate.Enabled = false;
                    toolClear.Enabled = false;
                    toolPast.Enabled = false;
                    toolRename.Enabled = false;

                    toolOpen.Visible = true;
                    toolCut.Visible = false;
                    toolCopy.Visible = false;
                    toolDelete.Visible = false;
                    toolPropertys.Visible = true;
                    toolCreate.Visible = false;
                    toolClear.Visible = false;
                    toolPast.Visible = false;
                    toolRename.Visible = false;
                }
            }
            else
            {
                if (name.Length < 3)
                {
                    toolOpen.Enabled = false;
                    toolCut.Enabled = false;
                    toolCopy.Enabled = false;
                    toolDelete.Enabled = false;
                    toolPropertys.Enabled = false;
                    toolCreate.Enabled = false;
                    toolClear.Enabled = false;
                    toolPast.Enabled = false;
                    toolRename.Enabled = false;

                    toolOpen.Visible = false;
                    toolCut.Visible = false;
                    toolCopy.Visible = false;
                    toolDelete.Visible = false;
                    toolPropertys.Visible = false;
                    toolCreate.Visible = false;
                    toolClear.Visible = false;
                    toolPast.Visible = false;
                    toolRename.Visible = false;
                }
                else if (name.Length == 3)
                {
                    if (cc[0] != true && cc[1] != true)
                    {
                        toolOpen.Enabled = false;
                        toolCut.Enabled = false;
                        toolCopy.Enabled = false;
                        toolDelete.Enabled = false;
                        toolPropertys.Enabled = true;
                        toolCreate.Enabled = true;
                        toolClear.Enabled = false;
                        toolPast.Enabled = false;
                        toolDirectory.Enabled = true;
                        toolText.Enabled = false;
                        toolWord.Enabled = false;
                        toolExcel.Enabled = false;
                        toolPowerPoint.Enabled = false;
                        toolRename.Enabled = false;

                        toolOpen.Visible = false;
                        toolCut.Visible = false;
                        toolCopy.Visible = false;
                        toolDelete.Visible = false;
                        toolPropertys.Visible = true;
                        toolCreate.Visible = true;
                        toolClear.Visible = false;
                        toolPast.Visible = false;
                        toolDirectory.Visible = true;
                        toolText.Visible = false;
                        toolWord.Visible = false;
                        toolExcel.Visible = false;
                        toolPowerPoint.Visible = false;
                        toolRename.Visible = false;

                    }
                    else
                    {
                        if (!directory.getDF().Contains(directory.getName(ccPaths[0])) && !directory.getDF().Contains(directory.getName(ccPaths[1])) && directory.getName(ccPaths[1]).Contains("FM-") && directory.getName(ccPaths[0]).Contains("FM-") && name != directory.getName(ccPaths[0]) && name != directory.getName(ccPaths[1]))
                        {
                            toolOpen.Enabled = false;
                            toolCut.Enabled = false;
                            toolCopy.Enabled = false;
                            toolDelete.Enabled = false;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = true;
                            toolClear.Enabled = false;
                            toolPast.Enabled = true;
                            toolDirectory.Enabled = true;
                            toolText.Enabled = false;
                            toolWord.Enabled = false;
                            toolExcel.Enabled = false;
                            toolPowerPoint.Enabled = false;
                            toolRename.Enabled = false;

                            toolOpen.Visible = false;
                            toolCut.Visible = false;
                            toolCopy.Visible = false;
                            toolDelete.Visible = false;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = true;
                            toolClear.Visible = false;
                            toolPast.Visible = true;
                            toolDirectory.Visible = true;
                            toolText.Visible = false;
                            toolWord.Visible = false;
                            toolExcel.Visible = false;
                            toolPowerPoint.Visible = false;
                            toolRename.Visible = false;
                        }
                        else
                        {
                            toolOpen.Enabled = false;
                            toolCut.Enabled = false;
                            toolCopy.Enabled = false;
                            toolDelete.Enabled = false;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = true;
                            toolClear.Enabled = false;
                            toolPast.Enabled = false;
                            toolDirectory.Enabled = true;
                            toolText.Enabled = false;
                            toolWord.Enabled = false;
                            toolExcel.Enabled = false;
                            toolPowerPoint.Enabled = false;
                            toolRename.Enabled = false;

                            toolOpen.Visible = false;
                            toolCut.Visible = false;
                            toolCopy.Visible = false;
                            toolDelete.Visible = false;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = true;
                            toolClear.Visible = false;
                            toolPast.Visible = false;
                            toolDirectory.Visible = true;
                            toolText.Visible = false;
                            toolWord.Visible = false;
                            toolExcel.Visible = false;
                            toolPowerPoint.Visible = false;
                            toolRename.Visible = false;
                        }
                    }
                }
                else if (name.Length > 3)
                {
                    if (cc[0] != true && cc[1] != true)
                    {
                        toolOpen.Enabled = false;
                        toolCut.Enabled = false;
                        toolCopy.Enabled = false;
                        toolDelete.Enabled = false;
                        toolPropertys.Enabled = true;
                        toolCreate.Enabled = true;
                        toolClear.Enabled = false;
                        toolPast.Enabled = false;
                        toolDirectory.Enabled = true;
                        toolText.Enabled = true;
                        toolWord.Enabled = true;
                        toolExcel.Enabled = true;
                        toolPowerPoint.Enabled = true;
                        toolRename.Enabled = false;

                        toolOpen.Visible = false;
                        toolCut.Visible = false;
                        toolCopy.Visible = false;
                        toolDelete.Visible = false;
                        toolPropertys.Visible = true;
                        toolCreate.Visible = true;
                        toolClear.Visible = false;
                        toolPast.Visible = false;
                        toolDirectory.Visible = true;
                        toolText.Visible = true;
                        toolWord.Visible = true;
                        toolExcel.Visible = true;
                        toolPowerPoint.Visible = true;
                        toolRename.Visible = false;

                    }
                    else
                    {

                        if (!directory.getDF().Contains(directory.getName(ccPaths[0])) && !directory.getDF().Contains(directory.getName(ccPaths[1])) && name != directory.getName(ccPaths[0]) && name != directory.getName(ccPaths[1]))
                        {
                            toolOpen.Enabled = false;
                            toolCut.Enabled = false;
                            toolCopy.Enabled = false;
                            toolDelete.Enabled = false;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = true;
                            toolClear.Enabled = false;
                            toolPast.Enabled = true;
                            toolDirectory.Enabled = true;
                            toolText.Enabled = true;
                            toolWord.Enabled = true;
                            toolExcel.Enabled = true;
                            toolPowerPoint.Enabled = true;
                            toolRename.Enabled = false;

                            toolOpen.Visible = false;
                            toolCut.Visible = false;
                            toolCopy.Visible = false;
                            toolDelete.Visible = false;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = true;
                            toolClear.Visible = false;
                            toolPast.Visible = true;
                            toolDirectory.Visible = true;
                            toolText.Visible = true;
                            toolWord.Visible = true;
                            toolExcel.Visible = true;
                            toolPowerPoint.Visible = true;
                            toolRename.Visible = false;
                        }
                        else
                        {
                            toolOpen.Enabled = false;
                            toolCut.Enabled = false;
                            toolCopy.Enabled = false;
                            toolDelete.Enabled = false;
                            toolPropertys.Enabled = true;
                            toolCreate.Enabled = true;
                            toolClear.Enabled = false;
                            toolPast.Enabled = false;
                            toolDirectory.Enabled = true;
                            toolText.Enabled = true;
                            toolWord.Enabled = true;
                            toolExcel.Enabled = true;
                            toolPowerPoint.Enabled = true;
                            toolRename.Enabled = false;

                            toolOpen.Visible = false;
                            toolCut.Visible = false;
                            toolCopy.Visible = false;
                            toolDelete.Visible = false;
                            toolPropertys.Visible = true;
                            toolCreate.Visible = true;
                            toolClear.Visible = false;
                            toolPast.Visible = false;
                            toolDirectory.Visible = true;
                            toolText.Visible = true;
                            toolWord.Visible = true;
                            toolExcel.Visible = true;
                            toolPowerPoint.Visible = true;
                            toolRename.Visible = false;
                        }
                    }
                }
            }

        }
        public void setMainPaths()
        {
            while (true)
            {
                bool stop;
                string text;
                foreach (var dr in drivers.getDrivers())
                {
                    text = dr;
                    stop = true;
                    while (stop)
                    {
                        foreach (var dir in new DirectoryInfo(text).GetFileSystemInfos())
                        {
                            if (paths[0] == null)
                            {
                                if (dir.Name == "FM-Silver")
                                {
                                    text = dir.FullName;
                                    break;
                                }
                                if (dir.Name == "Корзина")
                                {
                                    paths[0] = (dir.FullName);
                                    stop = false;
                                    break;
                                }
                            }
                            else if (paths[1] == null)
                            {
                                if (dir.Name == "FM-Silver" || dir.Name == "System" || dir.Name == "Documentation")
                                {
                                    text = dir.FullName;
                                    break;
                                }
                                if (dir.Name == "Справка.txt")
                                {
                                    paths[1] = dir.FullName;
                                    stop = false;
                                    break;
                                }
                            }
                            else if (paths[2] == null)
                            {
                                if (dir.Name == "FM-Silver" || dir.Name == "System" || dir.Name == "Documentation")
                                {
                                    text = dir.FullName;
                                    break;
                                }
                                if (dir.Name == "processLog.txt")
                                {
                                    paths[2] = dir.FullName;
                                    stop = false;
                                    break;
                                }
                            }
                            else if (paths[3] == null)
                            {
                                if (dir.Name == "FM-Silver" || dir.Name == "System" || dir.Name == "Documentation")
                                {
                                    text = dir.FullName;
                                    break;
                                }
                                if (dir.Name == "directoryLog.txt")
                                {
                                    paths[3] = dir.FullName;
                                    stop = false;
                                    break;
                                }
                            }
                            else if (paths[4] == null)
                            {
                                if (dir.Name == "FM-Silver" || dir.Name == "System" || dir.Name == "Documentation")
                                {
                                    text = dir.FullName;
                                    break;
                                }
                                if (dir.Name == "fileLog.txt")
                                {
                                    paths[4] = dir.FullName;
                                    stop = false;
                                    break;
                                }
                            }
                            else if (paths[5] == null)
                            {
                                if ((dir.Name == "FM-Silver" && new DirectoryInfo(text).Name != "FM-Silver") || dir.Name == "System" || dir.Name == "logInfo" || dir.Name == "bin" || dir.Name == "Debug" || dir.Name == "net6.0-windows")
                                {
                                    text = dir.FullName;
                                    break;
                                }
                                if (dir.Name == "logInfo.exe")
                                {
                                    paths[5] = dir.FullName;
                                    stop = false;
                                    break;
                                }
                            }
                        }
                        if (text == dr)
                        {
                            break;
                        }
                    }
                }
                if (paths[5] != null)
                {
                    break;
                }
            }

        }
        public void writeInThread(string name)
        {
            NamedPipeServerStream pipeServerStream = new NamedPipeServerStream("testPipe", PipeDirection.Out);
            pipeServerStream.WaitForConnection();
            if (pipeServerStream.IsConnected)
            {
                try
                {
                    using (StreamWriter write = new StreamWriter(pipeServerStream))
                    {
                        write.WriteLine(name);
                    }
                }
                catch (IOException error)
                {
                    MessageBox.Show("Соединение разорвано с ошибкой: " + error);
                }
            }
        }
        //
        //Методы запуска процессов.
        //

        public void processStart(string name)
        {
            Process start = new Process();
            start.StartInfo = new ProcessStartInfo()
            {
                FileName = name,

                UseShellExecute = true
            };
            
            start.Start();
            processCheck.usableProcess(start.Id);

            if (locks == true && type == "WorkStait")
            {
                writeInThread("[Имя] - [" + start.ProcessName + "] - [Размер множества] - [" + start.WorkingSet + "]");
            }
            
        }

        //
        //Методы для ContextMenu и ToolStripDropDownButton
        //

        public void Open()
        {
            if (listBox1.SelectedItem.ToString() != "System")
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = drivers.getPath(listBox1.SelectedItem.ToString());
                    updateListBox(textBox1.Text);
                }
                else
                {
                    if (directory.getType(directory.getPath(listBox1.SelectedItem.ToString())) == "Directory")
                    {
                        textBox1.Text = directory.getPath(listBox1.SelectedItem.ToString());
                        updateListBox(textBox1.Text);
                    }
                    else
                    {
                        processStart(directory.getPath(listBox1.SelectedItem.ToString()));
                    }
                }
            }
        }
        public void Propertys()
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (textBox1.Text == "")
                {
                    drivers.getInfo(drivers.getPath(listBox1.SelectedItem.ToString()));
                }
                else
                {
                    directory.getInfo(directory.getPath(listBox1.SelectedItem.ToString()));
                }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    if (textBox1.Text.Length == 3)
                    {
                        drivers.getInfo(textBox1.Text);
                    }
                    else
                    {
                        directory.getInfo(textBox1.Text);
                    }
                }
            }
        }
        public void Clear()
        {
            if (MessageBox.Show("Вы хотите отчистить корзину?", "Отчистить корзину?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                directory.cleanDeleteDIR(paths[0], paths[3], paths[4]);
            }
        }
        public void Cut()
        {
            cc[0] = true;
            ccPaths[0] = directory.getPath(listBox1.SelectedItem.ToString());
        }
        public void Copy()
        {
            cc[1] = true;
            ccPaths[1] = directory.getPath(listBox1.SelectedItem.ToString());
        }
        public void Create(string name, int i)
        {
            new HelpForm(textBox1.Text, name, directory.getDF(), paths[i], this, locks, type).ShowDialog();
            updateListBox(textBox1.Text);
        }
        public void Delete()
        {
            if (textBox1.Text != paths[0])
            {
                DialogResult res = MessageBox.Show("Полностью удалить файл " + listBox1.SelectedItem.ToString() + "?", "Удаление объекта.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    if (directory.getType(directory.getPath(listBox1.SelectedItem.ToString())) == "Directory")
                    {
                        directory.Delete(directory.getPath(listBox1.SelectedItem.ToString()), paths[3]);
                    }
                    else
                    {
                        directory.Delete(directory.getPath(listBox1.SelectedItem.ToString()), paths[4]);
                    }
                }
                else if (res == DialogResult.No)
                {
                    if (directory.getType(directory.getPath(listBox1.SelectedItem.ToString())) == "Directory")
                    {
                        directory.moveToDelete(directory.getPath(listBox1.SelectedItem.ToString()), paths[0], paths[3]);
                    }
                    else
                    {
                        directory.moveToDelete(directory.getPath(listBox1.SelectedItem.ToString()), paths[0], paths[4]);
                    }
                }
            }
            else
            {
                if (directory.getType(directory.getPath(listBox1.SelectedItem.ToString())) == "Directory")
                {
                    directory.Delete(directory.getPath(listBox1.SelectedItem.ToString()), paths[3]);
                }
                else
                {
                    directory.Delete(directory.getPath(listBox1.SelectedItem.ToString()), paths[4]);
                }
            }
            updateListBox(textBox1.Text);
        }
        public void Rename()
        {
            if (directory.getType(directory.getPath(listBox1.SelectedItem.ToString())) == "Directory")
            {
                new HelpForm(directory.getPath(listBox1.SelectedItem.ToString()), "toolRename", directory.getDF(), paths[3], this, locks, type).ShowDialog();

            }
            else
            {
                new HelpForm(directory.getPath(listBox1.SelectedItem.ToString()), "toolRename", directory.getDF(), paths[4], this, locks, type).ShowDialog();
            }
            updateListBox(textBox1.Text);
        }
        public void Past()
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (cc[0] == true)
                {
                    directory.past(ccPaths[0], directory.getPath(listBox1.SelectedItem.ToString()), "cut", paths[3], paths[4]);
                    cc[0] = false;
                    ccPaths[0] = "";
                }
                else if (cc[1] == true)
                {
                    directory.past(ccPaths[1], directory.getPath(listBox1.SelectedItem.ToString()), "copy", paths[3], paths[4]);
                    cc[1] = false;
                    ccPaths[1] = "";
                }
            }
            else
            {
                if (cc[0] == true)
                {
                    directory.past(ccPaths[0], textBox1.Text, "cut", paths[3], paths[4]);
                    cc[0] = false;
                    ccPaths[0] = "";
                }
                else if (cc[1] == true)
                {
                    directory.past(ccPaths[1], textBox1.Text, "copy", paths[3], paths[4]);
                    cc[1] = false;
                    ccPaths[1] = "";
                }
            }
            updateListBox(textBox1.Text);
        }

        //
        //Проверка действий  из событий.
        //D

        public void checkToolProcess(string name)
        {
            switch (name)
            {
                case "toolProcessMonitor":
                    processStart("Taskmgr.exe");
                    break;
                case "toolSystemInfo":
                    processStart("msinfo32.exe");
                    break;
                case "toolCMD":
                    processStart("cmd");
                    break;
                case "toolAbout":
                    MessageBox.Show("Предмет: Операционные системы и оболчки.\nЯзык программирования: C#.\nСтудент: Симонов Кирилл Олегович.\nГруппа: РПИС-03.");
                    break;
                case "toolReference":
                    processStart(paths[1]);
                    break;
            }
        }
        public void checkToolAction(string name)
        {
            switch (name)
            {
                case "toolOpen":
                    Open();
                    break;
                case "toolPropertys":
                    Propertys();
                    break;
                case "toolClear":
                    Clear();
                    break;
                case "toolCut":
                    Cut();
                    break;
                case "toolCopy":
                    Copy();
                    break;
                case "toolDelete":
                    Delete();
                    break;
                case "toolRename":
                    Rename();
                    break;
                case "toolPast":
                    Past();
                    break;
                case "toolDirectory":
                    Create(name, 3);
                    break;
                default:
                    Create(name, 4);
                    break;
            }
        }

        //
        //Методы событий при действиях ползователя.
        //
        private void LeftMouseDoubleClick_listBox1(object sender, MouseEventArgs e)
        {
            if (listBox1.IndexFromPoint(e.Location) != -1)
            {
                Open();
            }
            else
            {
                listBox1.ClearSelected();
            }
        }
        private void MouseDown_listBox1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBox1.IndexFromPoint(e.Location) != -1)
                {
                    listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
                    setParametrs(listBox1.SelectedItem.ToString(), listBox1.SelectedIndex, textBox1.Text);
                    contextMenuStrip1.Show(Control.MousePosition);
                }
                else
                {
                    listBox1.ClearSelected();
                    setParametrs(textBox1.Text, listBox1.SelectedIndex, textBox1.Text);
                    contextMenuStrip1.Show(Control.MousePosition);
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                if (listBox1.IndexFromPoint(e.Location) != -1)
                {
                    listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
                    setParametrs(listBox1.SelectedItem.ToString(), listBox1.SelectedIndex, textBox1.Text);
                    if (toolCut.Enabled == true)
                    {
                        time = 0;
                        timer1.Enabled = true;
                    }
                }
                else
                {
                    listBox1.ClearSelected();
                }
            }
        }
        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            if (listBox1.IndexFromPoint(e.Location) != -1)
            {
                listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
                setParametrs(listBox1.SelectedItem.ToString(), listBox1.SelectedIndex, textBox1.Text);
                if (cc[0] == true && toolPast.Enabled == true)
                {
                    checkClickToolAction(toolPast, EventArgs.Empty);
                }
            }
            else
            {
                listBox1.ClearSelected();
                setParametrs(textBox1.Text, listBox1.SelectedIndex, textBox1.Text);
                if (cc[0] == true && toolPast.Enabled == true)
                {
                    checkClickToolAction(toolPast, EventArgs.Empty);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time += 1;
            if (time == 2)
            {
                timer1.Enabled = false;
                checkClickToolAction(toolCut, EventArgs.Empty);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 3)
            {
                textBox1.Text = directory.getParentPath(textBox1.Text);
                updateListBox(textBox1.Text);
            }
            else
            {
                Start();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("System"))
            {
                if (textBox1.Text.Length > 3)
                {
                    if (textBox1.Text.IndexOf("FM-")==3)
                    {
                        updateListBox(textBox1.Text);
                    }
                    else
                    {
                        Start();
                    }
                }
                else
                {
                    updateListBox(textBox1.Text);
                }
            }
        }
        private void startContextTools(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    checkClickToolAction(toolOpen, EventArgs.Empty);
                }
            }
            else if (e.KeyData == Keys.Left)
            {
                button3_Click(sender, EventArgs.Empty);
            }
            else {
                foreach (ToolStripMenuItem toolsKeys in contextMenuStrip1.Items)
                {
                    if (e.KeyData == toolsKeys.ShortcutKeys)
                    {
                        if (toolsKeys.Enabled == true)
                        {
                            checkClickToolAction(toolsKeys, EventArgs.Empty);
                        }
                    }
                }
            }
        }
        private void checkClickToolProcess(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = (ToolStripMenuItem)sender;
            checkToolProcess(tool.Name);

        }
        private void checkClickToolAction(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = (ToolStripMenuItem)sender;
            checkToolAction(tool.Name);
        }
        private void closedEvent(object sender, EventArgs e)
        {
            if (locks == true && type != "")
            {
                locks = false;
                type = "";
                writeInThread("Close");

            }
        }
        //
        //Переопределение метода WndProc - обработчик сообщений Windows, для проверки дисков.
        //
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0219)
            {
                switch ((int)m.WParam)
                {
                    case 0x8000:
                        if (textBox1.Text == "")
                        {
                            Start();
                        }
                        break;
                    case 0x8004:
                        if (textBox1.Text != "")
                        {
                            if (!drivers.getCheckReference(directory.getRootPath(textBox1.Text)))
                            {
                                Start();
                            }
                        }
                        else
                        {
                            Start();
                        }
                        break;
                }
            } //Проверка подключения устройства.


        }
        //
        //Передача данных между приложениями.
        //
        private void openFilesLog(object sender, EventArgs e)
        {
            if (locks == false && type == "")
            {

                
                locks = true;
                type = "Directory";
                processStart(paths[5]);

            }
        }
        private void closedThread(object sender, EventArgs e)
        {
            if (locks == true && type != "")
            {
                locks = false;
                type = "";
                processCheck.setThredStatus(false, "");
                writeInThread("Close");

            }

        }
        private void openProcessLog(object sender, EventArgs e)
        {
            if (locks == false && type == "")
            {
                
                locks = true;
                type = "Process";
                processCheck.setThredStatus(true, "Process");
                processStart(paths[5]);
            }

        }
        private void openWorkStaitLog(object sender, EventArgs e)
        {
            if (locks == false && type == "")
            {

                
                locks = true;
                type = "WorkStait";
                processStart(paths[5]);

            }

        }

    }
}