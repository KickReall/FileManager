using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Silver
{
    internal class WorksWithFile
    {
        public void writeInFile(string logPath, string action, string name, string fullname, string time)
        {
            StreamWriter write = new StreamWriter(logPath, true);
            write.WriteLine("[" + action + "]-[" + name + "]-[" + fullname + "]-[" + time + "]");
            write.Close();
        }
        public void writeInFile(string logPath, string action, string oldname, string oldfullname, string newname, string newfullname,string time)
        {
            StreamWriter write = new StreamWriter(logPath, true);
            write.WriteLine("[" + action + "]-[" + oldname + "]-[" + oldfullname + "]>>>>[" + newname + "]-[" + newfullname + "]-[" + time + "]");
            write.Close();
        }
    }
}
