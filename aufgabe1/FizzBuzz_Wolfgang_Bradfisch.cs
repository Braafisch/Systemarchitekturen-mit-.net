using System;

namespace aufgabe1
{
    public class FizzBuzz
    {
        private static int GetNumber()
        {
            int number;
            do
            {
                Console.Write("Gib eine Zahl ein: ");
                number = Convert.ToInt32(Console.ReadLine());
                if (number < 1)
                    Console.WriteLine($"{number} ist zu klein");
                else if (100 < number)
                    Console.WriteLine($"{number} ist zu groß");
            } while (number < 1 || 100 < number);
            return number;
        }
        private static void Output(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if ((number % 3) == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }
        public static void Main()
        {
            Console.WriteLine("Gib eine Zahl zwischen 1 und 100 ein");
            Output(GetNumber());
        }
    }
}