using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NumberAnalyzer
{
    private string _filePath;

    public NumberAnalyzer(string filePath)
    {
        _filePath = filePath;
    }

    public void Analyze()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        try
        {
            var numbers = File.ReadAllLines(_filePath).Select(int.Parse).ToList();

            int positiveCount = numbers.Count(n => n > 0);
            int negativeCount = numbers.Count(n => n < 0);
            int twoDigitCount = numbers.Count(n => n >= 10 && n < 100 || n <= -10 && n > -100);
            int fiveDigitCount = numbers.Count(n => n >= 10000 && n < 100000 || n <= -10000 && n > -100000);

            Console.WriteLine($"Количество положительных чисел: {positiveCount}");
            Console.WriteLine($"Количество отрицательных чисел: {negativeCount}");
            Console.WriteLine($"Количество двузначных чисел: {twoDigitCount}");
            Console.WriteLine($"Количество пятизначных чисел: {fiveDigitCount}");

            SaveNumbersToFile(numbers.Where(n => n > 0), "positive_numbers.txt");
            SaveNumbersToFile(numbers.Where(n => n < 0), "negative_numbers.txt");
            SaveNumbersToFile(numbers.Where(n => n >= 10 && n < 100 || n <= -10 && n > -100), "two_digit_numbers.txt");
            SaveNumbersToFile(numbers.Where(n => n >= 10000 && n < 100000 || n <= -10000 && n > -100000), "five_digit_numbers.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
        }
    }
    private void SaveNumbersToFile(IEnumerable<int> numbers, string fileName)
    {
        File.WriteAllLines(fileName, numbers.Select(n => n.ToString()));
    }
}
