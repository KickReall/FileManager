using System;
using System.IO.Pipes;
using System.Management;

namespace FM_Silver
{
    internal class WMIChecking
    {
        ManagementEventWatcher processStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
        ManagementEventWatcher processStopEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
        bool locks = false;
        string type = "";
        private List<int> processID = new List<int>();
        StreamWriter fileWrite;


        private string processLog;
        
        public WMIChecking(string log)
        {
            processLog = log;
            processStartEvent.EventArrived += new EventArrivedEventHandler(checkStartProcess);
            processStopEvent.EventArrived += new EventArrivedEventHandler(checkStopProcess);
            processStartEvent.Start();
            processStopEvent.Start();

        }

        public void usableProcess(int process)
        {
            processID.Add(process);
        }
        public void setThredStatus(bool locks, string type)
        {
            this.locks = locks;
            this.type = type;
        }

        private void checkStartProcess(object sender, EventArrivedEventArgs e)
        {
            if (processID.Contains(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)))
            {
                lock (processLog)
                {
                    try
                    {
                        fileWrite = new StreamWriter(processLog, true);
                        fileWrite.WriteLine("[Запущен]-[" + getProcessOwner(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)) + "]-[" + e.NewEvent.Properties["ProcessName"].Value + "]-[" + DateTime.Now.ToString() + "]");
                        fileWrite.Close();
                    }
                    catch (IOException error)
                    {
                        MessageBox.Show("Ошибка: " + error);
                    }
                }

                if (locks == true && type == "Process")
                {
                    writeInThread("[Запущен]-[" + getProcessOwner(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)) + "]-[" + e.NewEvent.Properties["ProcessName"].Value + "]-[" + DateTime.Now.ToString() + "]");
                }
            }
        }
        
        private void checkStopProcess(object sender, EventArrivedEventArgs e)
        {
            if (processID.Contains(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)))
            {
                lock (processLog)
                {
                    int id = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value);

                    try
                    {
                        fileWrite = new StreamWriter(processLog, true);
                        fileWrite.WriteLine("[Остановлен]-[" + getProcessOwner(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)) + "]-[" + e.NewEvent.Properties["ProcessName"].Value + "]-[" + DateTime.Now.ToString() + "]");
                        fileWrite.Close();
                    }
                    catch (IOException error)
                    {
                        MessageBox.Show("Ошибка: " + error);
                    }
                    
                    processID.Remove(processID.IndexOf(id));
                }
                if (locks == true && type == "Process")
                {
                    writeInThread("[Остановлен]-[" + getProcessOwner(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)) + "]-[" + e.NewEvent.Properties["ProcessName"].Value + "]-[" + DateTime.Now.ToString() + "]");
                }
            }
        }

        public string getProcessOwner(int processID)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ProcessID = " + processID);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "NO OWNER";
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

    }
    
    
}
