

using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

string text = "";
string path = "";
string[] command;
Console.WriteLine("Запущена командная строка Windows.\n" +
    "Для вывода информации о доступных командах, введите help.");
Console.WriteLine();

while (true)
{   
    Console.WriteLine("PATH: " + path + "");
    Console.Write("Введите команду: ");
    text = Console.ReadLine();
    command = text.Split(' ');
    Console.WriteLine();
    switch (command[0])
    {
        case "help":
            Console.WriteLine("Выберите справку по командам из доступных:\n" +
                "file - Команды файловой системы.\n" +
                "net - Сетевые команды Windows.\n");
            break;
        case "file":
            Console.WriteLine("Введите название команды из списка доступных:\n" +
                "drive - Вывод списка существующих дисков.\n" +
                "dir - Вывод списка файлов на диске.\n" +
                "cd - Переход в директорию.\n" +
                "opf - Открытие файла.\n" +
                "cdir - Создание директории.\n" +
                "del - Удаление объект.\n" +
                "cfile - Создание файла.\n" +
                "infodr - Информация о диске.\n" +
                "infodir - Информация о директории.\n" +
                "infofile - Информация о файле.\n" +
                ".. - Возврат на папку ниже.\n" +
                "...- Возврат к корневому диску.\n");
            break;
        case "net":
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Введите название команды из списка доступных:\n" +
                "ip - Вывод привязанных хостов к указанному IP, вывод привязанных IP к указанному хосту.\n" +
                "ping - Проверка скорости передачи пакетов данных.\n" +
                "gmac - Вывод MAC-Адресов, используемых ПК.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            break;
        case "drive":
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Список доступных дисков:");
            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                Console.WriteLine(drive.Name);
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            break;
        case "dir":

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Список доступных файлов и папок:");
            if (Directory.Exists(path)) {
                foreach (DirectoryInfo info in new DirectoryInfo(path).GetDirectories())
                {
                    if ((info.Attributes & FileAttributes.System) == 0 && (info.Attributes & FileAttributes.Hidden) == 0)
                    {
                        Console.WriteLine(info.Name);
                    }
                }
                foreach (FileInfo info in new DirectoryInfo(path).GetFiles())
                {
                    if ((info.Attributes & FileAttributes.System) == 0 && (info.Attributes & FileAttributes.Hidden) == 0)
                    {
                        Console.WriteLine(info.Name);
                    }
                }
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            break;
        case "cd":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (path == "")
                {
                    if (Directory.Exists(command[1]))
                    {
                        path = command[1];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Такого пути не существует.");
                    }
                }
                else
                {
                    if (Directory.Exists(Path.Combine(path, command[1])))
                    {
                        path = Path.Combine(path, command[1]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Такого пути не существует.");
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "opf":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (File.Exists(Path.Combine(path, command[1])) && (new FileInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.Hidden) == 0 && (new FileInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.System) == 0)
                {
                    try
                    {
                        Process start = new Process();
                        start.StartInfo.FileName = Path.Combine(path, command[1]);
                        start.StartInfo.UseShellExecute = true;
                        start.Start();
                    }
                    catch (IOException error)
                    {
                        Console.WriteLine("Ошибка открытия: " + error);
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "cdir":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (path != "")
                {
                    Directory.CreateDirectory(Path.Combine(path, command[1]));
                }
                else
                {
                    Console.WriteLine("Error: Такого пути не существует.");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "cfile":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (path != "")
                {
                    File.Create(Path.Combine(path, command[1])).Close();
                }
                else
                {
                    Console.WriteLine("Error: Такого пути не существует.");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "infodr":
            if (command.Length > 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (path != "")
                {
                    if (path.Length > 3)
                    {
                        if (Directory.Exists(path))
                        {
                            Console.WriteLine("Название диска : " + new DriveInfo(new DirectoryInfo(path).Root.ToString()).Name + "\n" +
                            "Том диска: " + new DriveInfo(new DirectoryInfo(path).Root.ToString()).VolumeLabel + "\n" +
                            "Формат диска: " + new DriveInfo(new DirectoryInfo(path).Root.ToString()).DriveFormat + "\n" +
                            "Общий объём памяти: " + new DriveInfo(new DirectoryInfo(path).Root.ToString()).TotalSize + "\n" +
                            "Свободный объём памяти: " + new DriveInfo(new DirectoryInfo(path).Root.ToString()).TotalFreeSpace + "\n");
                        }
                        else
                        {
                            Console.WriteLine("Error: Такого пути не существует.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Название диска : " + new DriveInfo(path).Name + "\n" +
                            "Том диска: " + new DriveInfo(path).VolumeLabel + "\n" +
                            "Формат диска: " + new DriveInfo(path).DriveFormat + "\n" +
                            "Общий объём памяти: " + new DriveInfo(path).TotalSize + "\n" +
                            "Свободный объём памяти: " + new DriveInfo(path).TotalFreeSpace + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Вы не выбрали ни одного диска.");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "infodir":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (Directory.Exists(Path.Combine(path, command[1])))
                {
                    Console.WriteLine("Название папки: " + new DirectoryInfo(Path.Combine(path, command[1])).Name + "\n" +
                        "Полный путь к папке: " + new DirectoryInfo(Path.Combine(path, command[1])).FullName + "\n" +
                        "Время последнего изменения: " + new DirectoryInfo(Path.Combine(path, command[1])).LastWriteTime + "\n");
                }
                else
                {
                    Console.WriteLine("Error: Такого пути не существует.");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "infofile":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (File.Exists(Path.Combine(path, command[1])))
                {
                    Console.WriteLine("Название файла: " + new FileInfo(Path.Combine(path, command[1])).Name + "\n" +
                        "Полный путь к файлу: " + new FileInfo(Path.Combine(path, command[1])).FullName + "\n" +
                        "Размер файла в байтах: " + new FileInfo(Path.Combine(path, command[1])).Length + "\n" +
                        "Тип файла: " + new FileInfo(Path.Combine(path, command[1])).Extension + "\n" +
                        "Время последнего изменения: " + new FileInfo(Path.Combine(path, command[1])).LastWriteTime + "\n");
                }
                else
                {
                    Console.WriteLine("Error: Такого пути не существует.");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "..":
                if (path.Length > 3)
                {
                    if (Directory.Exists(path))
                    {
                        path = new DirectoryInfo(path).Parent.ToString();
                    }
                }
                else
                {
                    path = "";
                }
            break;
        case "...":
                if (path.Length > 3)
                {
                    if (Directory.Exists(path))
                    {
                        path = new DirectoryInfo(path).Root.ToString();
                    }
                }
                else
                {
                    path = "";
                }
            break;
        case "del":
            if (command.Length > 1)
            {
                if (command.Length > 0)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine();
                    if (path == "")
                    {
                        if ((new DirectoryInfo(command[1]).Attributes & FileAttributes.System) == 0 && (new DirectoryInfo(command[1]).Attributes & FileAttributes.Hidden) == 0 && (new DirectoryInfo(command[1]).Attributes & FileAttributes.ReadOnly) == 0)
                        {
                            if ((new DirectoryInfo(command[1]).Attributes & FileAttributes.Directory) == 0)
                            {
                                if (!command[1].Contains("System") && !command[1].Contains("system") && !command[1].Contains("FM-Silver") && !command[1].Contains("Документы") && !command[1].Contains("Изображения") && !command[1].Contains("Корзина"))
                                {
                                    File.Delete(command[1]);
                                }
                                else
                                {
                                    Console.WriteLine("\nДанный путь запрещён.");
                                }
                            }
                            else
                            {
                                if (!command[1].Contains("System") && !command[1].Contains("system") && !command[1].Contains("FM-Silver") && !command[1].Contains("Документы") && !command[1].Contains("Изображения") && !command[1].Contains("Корзина"))
                                {
                                    Console.WriteLine("Вы уверены, что хотите удалить данную папку ?\n |Y - Да|N - Нет|");
                                    if (Console.ReadKey().Key == ConsoleKey.Y)
                                    {
                                        Directory.Delete(command[1], true);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nОтмена удаления.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Данный путь запрещён.");
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.System) == 0 && (new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.Hidden) == 0 && (new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.ReadOnly) == 0)
                        {
                            if ((new DirectoryInfo(command[1]).Attributes & FileAttributes.Directory) == 0)
                            {
                                if (!command[1].Contains("System") && !command[1].Contains("system") && !command[1].Contains("FM-Silver") && !command[1].Contains("Документы") && !command[1].Contains("Изображение") && !command[1].Contains("Корзина"))
                                {
                                    Console.WriteLine("Вы уверены, что хотите удалить данный файл ?\n |Y - Да|N - Нет|");
                                    if (Console.ReadKey().Key == ConsoleKey.Y)
                                    {
                                        File.Delete(Path.Combine(path, command[1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Отмена удаления.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Данный путь запрещён.");
                                }
                            }
                            else
                            {
                                if (!command[1].Contains("System") && !command[1].Contains("system") && !command[1].Contains("FM-Silver") && !command[1].Contains("Документы") && !command[1].Contains("Изображение") && !command[1].Contains("Корзина"))
                                {
                                    Console.WriteLine("Вы уверены, что хотите удалить данную папку ?\n |Y - Да|N - Нет|");
                                    if (Console.ReadKey().Key == ConsoleKey.Y)
                                    {
                                        Directory.Delete(Path.Combine(path, command[1]), true);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Отмена удаления.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Данный путь запрещён.");
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "ip":
            if (command.Length > 1)
            {
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(command[1]);
                    Console.WriteLine("Имя хоста: " + host.HostName);
                    Console.WriteLine("Доступные IP: ");
                    foreach(IPAddress ip in host.AddressList)
                    {
                        Console.WriteLine("IP: " + ip.ToString());
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка: неверное имя хоста.");
                }
            }
            break;
        case "ping":
            if (command.Length > 1)
            {
                int time;
                if (command.Length == 3)
                {
                    try
                    {
                        time = Convert.ToInt32(command[2]);
                        Ping png = new Ping();
                        for (int i = 0; i < time; i++)
                        {
                            PingReply pr = await png.SendPingAsync(command[1]);
                            Console.WriteLine("IP: " + pr.Address + " - Хост: " + command[1] + " - Статус: " + pr.Status + " - Объём данных: " + pr.Buffer.Length + " байт - Время: " + pr.RoundtripTime + " мс");

                        }
                    }
                    catch(FormatException err)
                    {
                        Console.WriteLine("Ошибка: " + err);
                    }
                    catch (SocketException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                    catch (ArgumentException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                    catch (InvalidOperationException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                    catch(IndexOutOfRangeException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                }
                else if (command.Length == 2)
                {
                    try
                    {
                        Ping png = new Ping();
                        for (int i = 0; i < 15; i++)
                        {
                            PingReply pr = await png.SendPingAsync(command[1]);
                            Console.WriteLine("IP: " + pr.Address + " - Хост: " + command[1] + " - Статус: " + pr.Status + " - Объём данных: " + pr.Buffer.Length + " байт - Время: " + pr.RoundtripTime + " мс");

                        }
                    }
                    catch (FormatException err)
                    {
                        Console.WriteLine("Ошибка: " + err);
                    }
                    catch (SocketException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                    catch (ArgumentException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                    catch (InvalidOperationException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                    catch (IndexOutOfRangeException error)
                    {
                        Console.WriteLine("Ошибка: " + error);
                    }
                }
            }
            break;
        case "gmac":
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        Console.WriteLine("[Имя: " + nic.Name + "]-[Описание:" + nic.Description + "]-[MAC:"+nic.GetPhysicalAddress().ToString()+"]");
                    }
                }
            break;
    }
}

