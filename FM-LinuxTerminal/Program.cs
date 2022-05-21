

using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

string text = "";
string path = "";
string[] command;
Console.WriteLine("Запущен терминал Linux.\n" +
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
                "lsblk - Вывод списка существующих дисков.\n" +
                "ls - Просмотр содержимого каталога.\n" +
                "cd - Переход в директорию.\n" +
                "echo - Открытие файла.\n" +
                "mkdir - Создание директории.\n" +
                "rmdir - Удаление каталога.\n" +
                "rm - Удаление файла\n" +
                "touch - Создание файла.\n" +
                "cd.. - Возврат на папку выше.\n" +
                "cd - Возврат к корневому диску.\n");
            break;
        case "net":
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Введите название команды из списка доступных:\n" +
                "ip - Вывод привязанных хостов к указанному IP, вывод привязанных IP к указанному хосту.\n" +
                "ping - Проверка скорости передачи пакетов данных.\n" +
                "gmac - Вывод MAC-Адресов, используемых ПК.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            break;
        case "lsblk":
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Список доступных дисков:");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                Console.WriteLine(drive.Name);
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            break;
        case "ls":
            
            if (command.Length == 1)
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("Список доступных файлов и папок:");
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
                    Console.WriteLine("-------------------------------------------------------------------------------");
                }
            }
            else
            {
                if (command[1] != "")
                {
                    if (Directory.Exists(command[1]))
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine("Список доступных файлов и папок:");
                        foreach (DirectoryInfo info in new DirectoryInfo(command[1]).GetDirectories())
                        {
                            if ((info.Attributes & FileAttributes.System) == 0 && (info.Attributes & FileAttributes.Hidden) == 0)
                            {
                                Console.WriteLine(info.Name);
                            }
                        }
                        foreach (FileInfo info in new DirectoryInfo(command[1]).GetFiles())
                        {
                            if ((info.Attributes & FileAttributes.System) == 0 && (info.Attributes & FileAttributes.Hidden) == 0)
                            {
                                Console.WriteLine(info.Name);
                            }
                        }
                        Console.WriteLine("-------------------------------------------------------------------------------");
                    }
                }
            }
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
            else
            {

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
            }
            break;
        case "echo":
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
        case "mkdir":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (path == "" && command[1] != "" && command[1] != null)
                {
                    if (Directory.Exists(new DirectoryInfo(command[1]).Parent.ToString()))
                    {
                        Directory.CreateDirectory(command[1]);
                    }
                }
                else
                {
                    if (path != "")
                    {
                        if (Directory.Exists(Path.Combine(path, command[1])))
                        {
                            Directory.CreateDirectory(Path.Combine(path, command[1]));
                        }
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "touch":
            if (command.Length > 1)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine();
                if (path == "" && command[1] != "" && command[1] != null)
                {
                    if (Directory.Exists(new DirectoryInfo(command[1]).Parent.ToString()))
                    {
                        File.Create(command[1]);
                    }
                }
                else
                {
                    if (path != "")
                    {
                        if(File.Exists(Path.Combine(path, command[1])))
                        {
                            File.Create(Path.Combine(path, command[1]));
                        }
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "cd..":
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
        case "rmdir":
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
                    else
                    {
                        if ((new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.System) == 0 && (new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.Hidden) == 0 && (new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.ReadOnly) == 0)
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
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "rm":
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
                                if (!command[1].Contains("System") && !command[1].Contains("system") && !command[1].Contains("FM-Silver") && !command[1].Contains("Документы") && !command[1].Contains("Изображения") && !command[1].Contains("Корзина"))
                                {
                                    File.Delete(command[1]);
                                }
                                else
                                {
                                    Console.WriteLine("\nДанный путь запрещён.");
                                }
                        }
                    }
                    else
                    {
                        if ((new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.System) == 0 && (new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.Hidden) == 0 && (new DirectoryInfo(Path.Combine(path, command[1])).Attributes & FileAttributes.ReadOnly) == 0)
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
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            break;
        case "host":
            if (command.Length > 1)
            {
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(command[1]);
                    Console.WriteLine("Имя хоста: " + host.HostName);
                    Console.WriteLine("Доступные IP: ");
                    foreach (IPAddress ip in host.AddressList)
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
        case "nslookup":
            if (command.Length > 1)
            {
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(command[1]);
                    foreach (IPAddress ip in host.AddressList)
                    {
                        Console.WriteLine("Имя хоста: " + host.HostName);
                        Console.WriteLine("Server: " + ip.ToString());
                        Console.WriteLine("Address: " + ip.Address.ToString());
                        Console.WriteLine("AddressFamily: " + ip.AddressFamily);
                        Console.WriteLine("ScopeId: " + ip.ScopeId);
                        Console.WriteLine("------------------------------------");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка: неверное имя хоста.");
                }
            }
            break;
    }
}


