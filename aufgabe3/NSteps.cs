using System;

namespace aufgabe3
{
    public class NSteps
    {
        public string GetNumber(int x, int y)
        {
            if(x == y || (x - 2) == y)
            {
                return ((x + y) - (x % 2 == 0 ? 0 : 1)).ToString();
            }
            else
            {
                return "No Number";
            }        
        }

        public (int x, int y) GetCoordinates()
        {
            Console.WriteLine("Enter a X and Y value");
            Console.Write("X: ");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y: ");
            var y = Convert.ToInt32(Console.ReadLine());
            return (x, y);
        }

        internal static void Main(string[] args)
        {
            var nstep = new NSteps();

            var cordinates = nstep.GetCoordinates();
            var x = cordinates.x;
            var y = cordinates.y;

            Console.WriteLine(nstep.GetNumber(x, y));
        }
    }
}