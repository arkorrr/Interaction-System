using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Moderator
{
    private string _textFilePath;
    private string _moderationWordsFilePath;

    public Moderator(string textFilePath, string moderationWordsFilePath)
    {
        _textFilePath = textFilePath;
        _moderationWordsFilePath = moderationWordsFilePath;
    }

    public async Task ModerateAsync()
    {
        if (!File.Exists(_textFilePath))
        {
            Console.WriteLine("Файл с текстом не найден.");
            return;
        }

        if (!File.Exists(_moderationWordsFilePath))
        {
            Console.WriteLine("Файл со словами для модерации не найден.");
            return;
        }

        try
        {
            string[] moderationWords = await File.ReadAllLinesAsync(_moderationWordsFilePath);

            string textContent = await File.ReadAllTextAsync(_textFilePath);

            foreach (var word in moderationWords)
            {
                textContent = Regex.Replace(textContent, word, new string('*', word.Length), RegexOptions.IgnoreCase);
            }

            await File.WriteAllTextAsync(_textFilePath, textContent);

            Console.WriteLine("Модерация завершена.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файлов: {ex.Message}");
        }
    }
}
