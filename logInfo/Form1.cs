using System.IO.Pipes;

namespace logInfo
{
    public partial class Form1 : Form
    {
        NamedPipeClientStream pipeClientStream;
        public Form1()
        {
            InitializeComponent();
            connect();
        }

        public void connect()
        {
            Thread start = new Thread(startCheck);
            start.Start();
        }
        private void disconnect(object sender, EventArgs e)
        {
            pipeClientStream.Dispose();
            pipeClientStream.Close();
        }
        public void startCheck()
        {
            while (true)
            {
                pipeClientStream = new NamedPipeClientStream(".", "testPipe", PipeDirection.In);
                pipeClientStream.Connect();
                string message;
                var stream = new StreamReader(pipeClientStream);
               
                message = stream.ReadLine();

                if (message != null && message != "")
                {
                    if (message == "Close")
                    {
                        break;
                    }
                    else
                    {
                        listBox1.Items.Add(message);
                        listBox1.Update();
                    }
                }
                Thread.Sleep(1000);
            }
            Close();
        }
    }
   

}