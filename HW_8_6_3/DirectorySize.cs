using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8_6_3
{
    static class DirectorySize
    {
        public static long Size(string dirName)
        {
            long sizeSum = 0;
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (dir.Exists)
            {
                try
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                        sizeSum += file.Length;
                    }
                    foreach (var di in dir.GetDirectories())
                    {
                        sizeSum += Size(di.FullName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
            }
            else
                Console.WriteLine("Каталога не существует");

            return sizeSum;
        }

    }
}
