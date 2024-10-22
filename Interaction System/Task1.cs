using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Task1
{
    public Task1() {}
    public static void Generate(List<int> array)
    {
        Random rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            array.Add(rand.Next(1, 1000));
        }
    }
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
    public static bool IsFibonacci(int number)
    {
        int a = 0;
        int b = 1;

        while (b < number)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return b == number || number == 0;
    }
}