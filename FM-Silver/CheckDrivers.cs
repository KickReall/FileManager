using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Silver
{
    internal class CheckDrivers
    {
        public List<string> getDrivers() //Вывод названий дисков.
        {
            List<string> drive = new List<string>();
            foreach (DriveInfo dr in DriveInfo.GetDrives())
            {
                if (dr.DriveType != DriveType.CDRom && dr.DriveType != DriveType.Network)
                {
                    drive.Add(dr.Name);
                }
            }
            return drive;
        }
        public List<string> getDriversStats() //Вывод состояния дисков.
        {
            List<string> driveStats = new List<string>();
            foreach (DriveInfo dr in DriveInfo.GetDrives())
            {
                if (dr.DriveType != DriveType.CDRom && dr.DriveType != DriveType.Network)
                {
                    driveStats.Add(dr.DriveType + " [" + Math.Round(dr.TotalFreeSpace / Math.Pow(2, 30), 2) + "/" + Math.Round(dr.TotalSize / Math.Pow(2, 30), 2) + "]");
                }
            }
            return driveStats;
        }


        public bool getCheckReference(string name)
        {
            bool check = false;
            foreach (DriveInfo dr in DriveInfo.GetDrives())
            {
                if (dr.Name == name)
                {
                    check = true;
                    break;
                }

            }
            return check;
        } //Вывод проверки на существование.
        public bool getCheckDriver(string name)
        {
            bool check = false;
            foreach (DriveInfo dr in DriveInfo.GetDrives())
            {
                if (dr.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }//Проверка переданного объекта на соответствие диску.
       

        public void getInfo(string path)
        {
                    double TotalSize = Math.Round(new DriveInfo(path).TotalSize/Math.Pow(2,30),2);
                    double TotalFreeSpace = Math.Round(new DriveInfo(path).TotalFreeSpace / Math.Pow(2, 30), 2);

                    MessageBox.Show(
                        "Имя диска: " + new DriveInfo(path).Name + "\n" +
                        "Тип диска: " + new DriveInfo(path).DriveType + "\n" +
                        "Метка тома: " + new DriveInfo(path).VolumeLabel + "\n" +
                        "Файловая система: " + new DriveInfo(path).DriveFormat + "\n" +
                        "Объём памяти: " + TotalSize + "\n" +
                        "Объём свободной памяти: " + TotalFreeSpace + "\n" +
                        "Объём занятой памяти: " + Math.Round(TotalSize - TotalFreeSpace,2));
        } //Вывод информации о диске.
        public string getPath(string name)
        {
            return new DriveInfo(name).RootDirectory.ToString();
        } //Определение пути к диску.
        public string getType(string name)
        {
            string type = "";
            foreach(DriveInfo dr in DriveInfo.GetDrives())
            {
                if(dr.Name == name)
                {
                    type = dr.DriveType.ToString();
                }
            }
            return type;
        }//Возвращает тип диска, переданного в метод.
    
    }
}
