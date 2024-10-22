using System.Xml.Serialization;

class Program
{
    static async Task Main(string[] args)
    {
        //Task1
        List<int> randomNumbers = new List<int>();
        Task1.Generate(randomNumbers);

        List<int> primeNumbers = randomNumbers.Where(Task1.IsPrime).ToList();

        List<int> fibonacciNumbers = randomNumbers.Where(Task1.IsFibonacci).ToList();

        File.WriteAllLines("PrimeNumbers.txt", primeNumbers.Select(n => n.ToString()));

        File.WriteAllLines("FibonacciNumbers.txt", fibonacciNumbers.Select(n => n.ToString()));
        Console.WriteLine($"Всего сгенерированных чисел: {randomNumbers.Count}");
        Console.WriteLine($"Простые числа: {primeNumbers.Count}");
        Console.WriteLine($"Чисел Фибоначи: {fibonacciNumbers.Count}");
        //Task2
        string filePath = "text.txt";
        string initialText = "Hello world! Привет мир!";

        var task2 = new Task2(filePath, initialText);

        Console.Write("Введите слово для поиска: ");
        string searchWord = Console.ReadLine();

        Console.Write("Введите слово для замены: ");
        string replaceWord = Console.ReadLine();

        task2.ReplaceWords(searchWord, replaceWord);
        //Task3
        string textFilePath = "text.txt";
        string moderationWordsFilePath = "moderation_words.txt";

        var moderator = new Moderator(textFilePath, moderationWordsFilePath);

        await moderator.ModerateAsync();
        //Task4
        string directoryPath = @"D:\DataForUser";
        string searchPattern = "*.txt";
        bool deleteFiles = true;
        var searcherDeleter = new FileSearcherDeleter();
        searcherDeleter.SearchFiles(directoryPath, searchPattern, deleteFiles);
        //Task5
        string file = "numbers.txt";
        var random = new Random();
        var numbers = Enumerable.Range(1, 100000).Select(_ => random.Next(-99999, 99999)).ToList();
        File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));
        var analyzer = new NumberAnalyzer(filePath);
        analyzer.Analyze();
    }
}