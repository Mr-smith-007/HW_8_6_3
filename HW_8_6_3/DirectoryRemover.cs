using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8_6_3
{
    static class DirectoryRemover
    {
        public static void Cleanup(string dirName)
        {
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (dir.Exists)
            {
                try
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                        if (AccsessTime(file))
                            file.Delete();
                    }
                    foreach (var di in dir.GetDirectories())
                    {
                        Cleanup(di.FullName);
                        if (AccsessTime(di) && (di.GetFiles().Length == 0 && di.GetDirectories().Length == 0))
                            di.Delete(true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
            }
            else
                Console.WriteLine("Каталога не существует");
        }
        public static bool AccsessTime(FileSystemInfo x)
        {
            bool old;
            DateTime time1 = DateTime.Now;
            DateTime time2 = x.LastAccessTime;
            TimeSpan timeInterval = TimeSpan.FromMinutes(30);
            TimeSpan dif = time1.Subtract(time2);
            if (dif > timeInterval)
                old = true;
            else
                old = false;
            return old;
        }
    }
}
