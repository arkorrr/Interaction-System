using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Task2
{
    private string filePath;

    public Task2(string filePath, string initialText)
    {
        this.filePath = filePath;
        File.WriteAllText(this.filePath, initialText);
    }

    public void ReplaceWords(string searchWord, string replaceWord)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        try
        {
            string fileContent = File.ReadAllText(filePath);

            int count = Regex.Matches(fileContent, searchWord).Count;

            if (count > 0)
            {
                fileContent = fileContent.Replace(searchWord, replaceWord);

                File.WriteAllText(filePath, fileContent);

                Console.WriteLine($"Все вхождения '{searchWord}' были заменены на '{replaceWord}'.");
                Console.WriteLine($"Найдено и заменено {count} вхождений.");
            }
            else
            {
                Console.WriteLine($"Слово '{searchWord}' не найдено в файле.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
        }
    }

}



