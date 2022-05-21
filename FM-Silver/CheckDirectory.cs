using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Silver
{
    internal class CheckDirectory
    {

        private List<object> AllFiles = new List<object>(); //Список, хранящий объекты DirectoryInfo и FileInfo, получаемые из метода setInfo().

        public void setInfo(string path)// Заполнение списка AllFiles директориями и файлами, хранящимися в указанном пути.
        {

            if (Directory.Exists(path))
            {
                AllFiles.Clear();
                if (path.Length > 3)
                {
                    foreach (FileSystemInfo fileInfo in new DirectoryInfo(path).GetFileSystemInfos())
                    {
                        if ((fileInfo.Attributes & FileAttributes.Directory) == 0)
                        {
                            AllFiles.Add((FileInfo)fileInfo);

                        }
                        else if ((fileInfo.Attributes & FileAttributes.System) == 0 && (fileInfo.Attributes & FileAttributes.Hidden) == 0)
                        {
                            AllFiles.Add((DirectoryInfo)fileInfo);
                        }
                    }
                }
                else if(path.Length == 3)
                {
                    if (new DriveInfo(path).DriveType.ToString() == "Fixed")
                    {
                        foreach (var dir in new DirectoryInfo(path).GetDirectories())
                        {
                            if ((dir.Attributes & FileAttributes.System) == 0 && (dir.Attributes & FileAttributes.Hidden) == 0 && dir.Name.Contains("FM-"))
                            {
                                AllFiles.Add(dir);
                            }
                        }
                    }
                    else
                    {
                        foreach (FileSystemInfo fileInfo in new DirectoryInfo(path).GetFileSystemInfos())
                        {
                            if ((fileInfo.Attributes&FileAttributes.Directory)==0)
                            {
                                    AllFiles.Add((FileInfo)fileInfo);
                                
                            }
                            else if((fileInfo.Attributes & FileAttributes.System) == 0&&(fileInfo.Attributes&FileAttributes.Hidden)==0)
                            {
                                    AllFiles.Add((DirectoryInfo)fileInfo);
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
        public List<string> getDF()// Вывод имён директорий и файлов из списка AllFiles.
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
        public List<string> getStats()//Вывод информации о директориях и файлах, хранящихся в списке AllFiles.
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
        public string getPath(string name)// Получение пути к директории или файлу.
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
        public string getParentPath(string path)//Получение родительского пути.
        {
            string parentPath = "";
            if (Directory.Exists(new DirectoryInfo(path).Parent.ToString()))
            {
                parentPath = new DirectoryInfo(path).Parent.ToString();
                return parentPath;
            }
            return parentPath;
        }
        public string getRootPath(string path)//Получение корневого пути.
        {
            return new DirectoryInfo(path).Root.ToString();
        }
        public string getName(string path)//Получение имени файла или директории, находящегося по переданному пути.
        {
            if (path != null && path != "")
            {
                return new DirectoryInfo(path).Name;
            }
            return "";
        }
        public void getInfo(string path)//Получение полной информации о директории или файле, по указанному пути.
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
        public string getType(string path)//Получение типа объекта, находящегося по пути (Directory или File)
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


        public void moveToDelete(string path, string delPath, string logPath)//Удаление в корзину.
        {
            if (!Directory.Exists(Path.Combine(delPath, getName(path))))
            {
                if (getType(path)=="File")
                {
                    new WorksWithFile().writeInFile(logPath, "Перемещён в корзину", new FileInfo(path).Name, new FileInfo(path).FullName, DateTime.Now.ToString());
                    File.Move(path, Path.Combine(delPath, getName(path)));
                }
                else
                {
                    new WorksWithFile().writeInFile(logPath, "Перемещён в корзину", new DirectoryInfo(path).Name, new DirectoryInfo(path).FullName, DateTime.Now.ToString());
                    Directory.Move(path, Path.Combine(delPath, getName(path)));
                }
            }
            else
            {
                MessageBox.Show("Проверьте корзину, такой файл уже был удалён.");
            }
        }
        public void Delete(string path, string logPath)//Полное удаление.
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
        public void cleanDeleteDIR(string path, string logDir, string logFile)//Очистка корзины.
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
        public void past(string oldPath, string newPath, string type, string logDir, string logFile)//Вставка вырезанного/скопированного объекта.
        {
            string name = getName(oldPath);

                if (!Directory.Exists(Path.Combine(newPath, name)) &&!File.Exists(Path.Combine(newPath, name)))
                {
                    if (getType(oldPath) == "File")
                    {
                        if (type == "cut")
                        {
                            File.Move(oldPath, Path.Combine(newPath, name));
                            new WorksWithFile().writeInFile(logFile, "Вырезан", name, oldPath, name, Path.Combine(newPath, name), DateTime.Now.ToString());
                        }
                        else
                        {
                            File.Copy(oldPath, Path.Combine(newPath, name));
                            new WorksWithFile().writeInFile(logFile, "Скопирован", name, oldPath, name, Path.Combine(newPath, name), DateTime.Now.ToString());
                        }
                    }
                    else
                    {
                        if (type == "cut")
                        {
                            Directory.Move(oldPath, Path.Combine(newPath, name));
                            new WorksWithFile().writeInFile(logDir, "Вырезан", name, oldPath, name, Path.Combine(newPath, name), DateTime.Now.ToString());
                        }
                        else
                        {
                            CopyDirectory(oldPath, newPath, true);
                            new WorksWithFile().writeInFile(logDir, "Скопирован", name, oldPath, name, Path.Combine(newPath, name), DateTime.Now.ToString());
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Файл с таким именем уже существует.");
                }
        }
        public void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            string newPath = Path.Combine(destinationDir, getName(sourceDir));
            var dir = new DirectoryInfo(sourceDir);
            
            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(newPath);

            foreach(FileInfo file in dir.GetFiles())
            {
                string newFilePath = Path.Combine(newPath, file.Name);
                file.CopyTo(newFilePath);
            }

            if (recursive)
            {
                foreach(DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(newPath, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
