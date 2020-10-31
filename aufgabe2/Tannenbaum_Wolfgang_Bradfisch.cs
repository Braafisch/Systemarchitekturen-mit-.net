using System;

namespace aufgabe2
{
    public class Tannenbaum
    {
        private static string[,] Tanne(int number)
        {
            var hoch = number + 1;
            var breit = number * 2 - 1;
            string[,] array = new string[hoch, breit];
            for (var i = 0; i < number; i++)
            {

                for (var r = 0; r <= i; r++)
                {
                    array[i, number - 1 - r] = "#";
                    array[i, number - 1 + r] = "#";
                }
            }
            array[number, number - 1] = "I";
            return array;
        }
        private static void Tanne_ausgabe(string[,] array, bool spitze)
        {
            var hoch = array.GetLength(0);
            var breit = array.GetLength(1);
            if (true == spitze)
            {
                for(var i = 1; i < hoch - 1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                Console.Write(Environment.NewLine);
            }
            for (var i = 0; i < hoch; i++)
            {
                for (var j = 0; j < breit; j++)
                {
                    if("#" == array[i, j] || "I" == array[i, j])
                    {
                        Console.Write(array[i, j]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
        public static void Main(string[] args)
        {
            var number = Convert.ToInt32(args[0]);
            var stern = false;
            if (1 < args.Length)
            {
                stern = Convert.ToBoolean(args[1]);
            }
            var Baum = Tanne(number);
            Tanne_ausgabe(Baum, stern);
        }
    }
}