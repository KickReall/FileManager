using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Silver
{
    internal class CheckDirectory
    {

        private List<object> AllFiles = new List<object>();

        public void setInfo(string path)
        {

            if (Directory.Exists(path))
            {
                AllFiles.Clear();
                if (path.Length > 3)
                {
                        foreach (FileSystemInfo fileInfo in new DirectoryInfo(path).GetFileSystemInfos())
                        {
                                if (fileInfo.Attributes == FileAttributes.Directory)
                                {
                                    AllFiles.Add((DirectoryInfo)fileInfo);
                                }
                                else 
                                {
                                    AllFiles.Add((FileInfo)fileInfo);
                                }
                        }
                }
                else if(path.Length == 3)
                {
                    if (new DriveInfo(path).DriveType.ToString() == "Fixed")
                    {
                        foreach (var dir in new DirectoryInfo(path).GetDirectories())
                        {
                            if (dir.Attributes==FileAttributes.Directory&&dir.Name.Contains("FM-"))
                            {
                                AllFiles.Add(dir);
                            }
                        }
                    }
                    else
                    {
                        foreach (FileSystemInfo fileInfo in new DirectoryInfo(path).GetFileSystemInfos())
                        {
                                if (fileInfo.Attributes == FileAttributes.Directory)
                                {
                                    AllFiles.Add((DirectoryInfo)fileInfo);
                                }
                                else
                                {
                                    AllFiles.Add((FileInfo)fileInfo);
                                }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пути не существует.");
            }
        }
        public List<string> getDF()
        {
            List<string> df = new List<string>();

            foreach (object file in AllFiles)
            {
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    df.Add(((DirectoryInfo)file).Name);
                }
                else
                {
                    df.Add(((FileInfo)file).Name);
                }
            }
            return df;
        }
        public List<string> getStats()
        {
            List<string> stats = new List<string>();
            foreach (object file in AllFiles)
            {
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    stats.Add("DIR\t\t    [" + ((DirectoryInfo)file).LastWriteTime + "]");
                }
                else
                {
                    if ((((FileInfo)file).Length / Math.Pow(2, 30)) < 1)
                    {
                        if ((((FileInfo)file).Length / Math.Pow(2, 30)) < 0.0001)
                        {
                            if ((((FileInfo)file).Length / Math.Pow(2, 30)) < 0.0000001)
                            {
                                stats.Add("File" + ((FileInfo)file).Extension + "\t [" + ((FileInfo)file).Length + " Байт]\t    [" + ((FileInfo)file).LastWriteTime + "]");
                            }
                            else
                            {
                                stats.Add("File" + ((FileInfo)file).Extension + "\t [" + Math.Round(((FileInfo)file).Length / Math.Pow(2, 10), 2) + " Кб]\t    [" + ((FileInfo)file).LastWriteTime + "]");
                            }

                        }
                        else
                        {
                            stats.Add("File" + ((FileInfo)file).Extension + "\t [" + Math.Round(((FileInfo)file).Length / Math.Pow(2, 20), 2) + " Мб]\t    [" + ((FileInfo)file).LastWriteTime.Date + "]");
                        }
                    }
                    else
                    {
                        stats.Add("File" + ((FileInfo)file).Extension + "\t [" + Math.Round(((FileInfo)file).Length / Math.Pow(2, 30), 2) + " Гб]\t    [" + ((FileInfo)file).LastWriteTime.Date + "]");
                    }
                }
            }
            return stats;
        }
        public string getPath(string name)
        {
            string path = "";
            foreach (object file in AllFiles)
            {
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    if (((DirectoryInfo)file).Name == name)
                    {
                        path = ((DirectoryInfo)file).FullName;
                    }
                }
                else
                {
                    if (((FileInfo)file).Name == name)
                    {
                        path = ((FileInfo)file).FullName;
                    }
                }
            }
            return path;
        }
        public string getParentPath(string path)
        {
            string parentPath = "";
            if (Directory.Exists(new DirectoryInfo(path).Parent.ToString()))
            {
                parentPath = new DirectoryInfo(path).Parent.ToString();
                return parentPath;
            }
            return parentPath;
        }
        public string getRootPath(string path)
        {
            return new DirectoryInfo(path).Root.ToString();
        }
        public string getName(string path)
        {
            if (path != null && path != "")
            {
                return new DirectoryInfo(path).Name;
            }
            return "";
        }
        public void getInfo(string path)
        {
            if (getType(path) == "File")
            {
                MessageBox.Show(
                        "Имя файла: " + new FileInfo(path).Name + "\n" +
                        "Полное имя файла: " + new FileInfo(path).FullName + "\n" +
                        "Родительский каталог: " + new FileInfo(path).DirectoryName + "\n" +
                        "Размер файла: " + new FileInfo(path).Length + "\n" +
                        "Расширение файла: " + new FileInfo(path).Extension);

            }
            else
            {
                MessageBox.Show(
                                        "Имя каталога: " + new DirectoryInfo(path).Name + "\n" +
                                        "Полное имя каталога: " + new DirectoryInfo(path).FullName + "\n" +
                                        "Корневой каталог: " + new DirectoryInfo(path).Root + "\n" +
                                        "Родительский каталог: " + new DirectoryInfo(path).Parent + "\n" +
                                        "Время создания: " + new DirectoryInfo(path).CreationTime + "\n" +
                                        "Время последнего использования: " + new DirectoryInfo(path).LastAccessTime + "\n" +
                                        "Время последнего изменения: " + new DirectoryInfo(path).LastWriteTime);
            }
        }
        public string getType(string path)
        {
            if (new DirectoryInfo(path).Attributes == FileAttributes.Directory)
            {
                return "Directory";
                
            }
            else
            {
                return "File";
            }
        }


        public void moveToDelete(string path, string delPath, string logPath)
        {
            if (!Directory.Exists(delPath + "\\" + getName(path)))
            {
                if (getType(path)=="File")
                {
                    new WorksWithFile().writeInFile(logPath, "Перемещён в корзину", new FileInfo(path).Name, new FileInfo(path).FullName, DateTime.Now.ToString());
                    File.Move(path, delPath + "\\" + getName(path));
                }
                else
                {
                    new WorksWithFile().writeInFile(logPath, "Перемещён в корзину", new DirectoryInfo(path).Name, new DirectoryInfo(path).FullName, DateTime.Now.ToString());
                    Directory.Move(path, delPath + "\\" + getName(path));
                }
            }
            else
            {
                MessageBox.Show("Проверьте корзину, такой файл уже был удалён.");
            }
        }
        public void Delete(string path, string logPath)
        {
            if (getType(path) == "File")
            {
                new WorksWithFile().writeInFile(logPath, "Удалён", new FileInfo(path).Name, new FileInfo(path).FullName, DateTime.Now.ToString());
                File.Delete(path);
                
            }
            else
            {
                new WorksWithFile().writeInFile(logPath, "Удалён", new DirectoryInfo(path).Name, new DirectoryInfo(path).FullName, DateTime.Now.ToString());
                Directory.Delete(path, true);
            }
        }
        public void cleanDeleteDIR(string path, string logDir, string logFile)
        {
            foreach (var dir in new DirectoryInfo(path).GetDirectories())
            {
                new WorksWithFile().writeInFile(logDir, "Удалён из корзины", dir.Name, dir.FullName, DateTime.Now.ToString());
                dir.Delete(true);
            }
            foreach (var file in new DirectoryInfo(path).GetFiles())
            {
                new WorksWithFile().writeInFile(logDir, "Удалён из корзины", file.Name, file.FullName, DateTime.Now.ToString());
                file.Delete();
            }
        }
        public void past(string oldPath, string newPath, string type, string logDir, string logFile)
        {
            string name = getName(oldPath);

                if (!Directory.Exists(newPath + "\\" + name)&&!File.Exists(newPath + "\\" + name))
                {
                    if (getType(oldPath) == "File")
                    {
                        if (type == "cut")
                        {
                            File.Move(oldPath, newPath + "\\" + name);
                            new WorksWithFile().writeInFile(logFile, "Вырезан", name, oldPath, name, newPath + "\\" + name, DateTime.Now.ToString());
                        }
                        else
                        {
                            File.Copy(oldPath, newPath + "\\" + name);
                            new WorksWithFile().writeInFile(logFile, "Скопирован", name, oldPath, name, newPath + "\\" + name, DateTime.Now.ToString());
                        }
                    }
                    else
                    {
                        if (type == "cut")
                        {
                            Directory.Move(oldPath, newPath + "\\" + name);
                            new WorksWithFile().writeInFile(logDir, "Вырезан", name, oldPath, name, newPath + "\\" + name, DateTime.Now.ToString());
                        }
                        else
                        {
                            Directory.Move(oldPath, newPath + "\\" + name);
                            new WorksWithFile().writeInFile(logDir, "Скопирован (Вырезан)", name, oldPath, name, newPath + "\\" + name, DateTime.Now.ToString());
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Файл с таким именем уже существует.");
                }
        }


        

      
       

       

       


       
    
    }
}
