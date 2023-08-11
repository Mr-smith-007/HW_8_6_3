using HW_8_6_3;
using System;
using System.IO;


namespace HW_8_6_3;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к каталогу");
        string path = Console.ReadLine();
        long sizeBefore = DirectorySize.Size(path);
        Console.WriteLine($"Исходный размер папки: {sizeBefore} байт");
        DirectoryRemover.Cleanup(path);
        long sizeAfter = DirectorySize.Size(path);
        long difSize = sizeBefore - sizeAfter;
        Console.WriteLine($"Освобождено: {difSize} байт");
        Console.WriteLine($"Текущий размер папки: {sizeAfter} байт");

    }
}