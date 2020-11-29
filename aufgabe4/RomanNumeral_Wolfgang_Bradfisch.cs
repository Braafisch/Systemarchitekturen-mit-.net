using System;
using System.Linq;

namespace aufgabe4
{
    public struct RomanNumeral
    {
        private readonly string letters;

        public RomanNumeral(string letters)
        {
            this.letters = letters;
        }

        public RomanNumeral(char letter)
        {
            this.letters = letter.ToString();
        }

        private Int32 ConvertToInt32(char letter)
        {
            switch(letter)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;     
                default: throw new ArgumentException("Invalid roman number" + letters);         
            }
        }
        public Int32 ToInt32()
        {
            var number = 0;
            var curr = 0;
            var count = 0;
            var prev = 0;
            var prevprev = 0;

            foreach(var letter in letters.Reverse())
            {   
                curr = ConvertToInt32(letter);
                number += (curr < prev ? -curr  :  curr);
                count += (curr == prev ? 1 : -count);
                
                if (count >= 3 || count == 1 && (prev < prevprev || Math.Log10(curr) % 1 != 0) || curr < prev / 10 || curr == prev / 2 || curr < prev && prev == prevprev)
                    throw new ArgumentException("Invalid roman number " + letters);
                prevprev = prev;         
                prev = curr; 
            }
            return number;
        }

        public override string ToString()
        {
            return letters ?? string.Empty;
        }

        internal static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var num = new RomanNumeral(arg);
                try
                {
                    Console.WriteLine("{0} -> {1}", num.ToString(), num.ToInt32());
                }
                catch (FormatException e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
        }
    }
}
