using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileSearcherDeleter
{
    public void SearchFiles(string directoryPath, string searchPattern, bool deleteFiles)
    {
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Папка не найдена.");
            return;
        }
        try
        {
            var files = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);

            foreach (var file in files)
            {
                if (deleteFiles)
                {
                    File.Delete(file);
                    Console.WriteLine($"Удален файл: {file}");
                }
                else
                {
                    Console.WriteLine($"Найден файл: {file}");
                }
            }

            if (files.Length == 0)
            {
                Console.WriteLine("Файлы по указанной маске не найдены.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при поиске/удалении файлов: {ex.Message}");
        }
    }
}
