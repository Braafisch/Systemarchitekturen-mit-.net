using System;
using System.Globalization;
using System.IO;

namespace aufgabe7
{
    class booking
    {
        private double money;
        private string usecase;
        private DateTime date;
        private const string path = "./bookings.csv";

        public booking(string date, string usecase, string money) 
        {
            try {
                this.money = Double.Parse(money, new CultureInfo("de-DE"));
                this.usecase = usecase;
                this.date = DateTime.Parse(date);
            }
            catch {
                throw new FormatException("Wrong input!");
            }        
        }

        private void AddBooking()
        {
            using (var fs = File.Open(path, FileMode.Append))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Flush();
                    writer.WriteLine("{0};{1};{2}", date.ToString("dd.MM.yyyy"), usecase, money.ToString());
                }
            }
        }
        public void Confirm()
        {
            string desision;
            Console.WriteLine("Add Booking? [j/N]");
            switch(Console.ReadLine())
            {
                case "j": 
                    AddBooking();
                    break;
                case "N":
                    break;
                default:
                    throw new FormatException("Wrong input!");
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 4 && args[0] == "add")
            {
                var book = new booking(args[1], args[2], args[3]);
                book.Confirm();
            }
            else
            {
                throw new FormatException("Something went wrong with your booking");
            }
        }
    }
}
