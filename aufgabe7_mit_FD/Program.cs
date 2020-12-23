using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace aufgabe7_mit_FD
{
    class Program
    {

        private const string path = "booking.csv";

        private void CheckIfFirstElementIsAdd(IEnumerable<string> args, 
                                              Action<IEnumerable<string>> onAdd,
                                              Action onNotAdd)
        {
            if (args.First() == "add")
            {
                onAdd(args.Skip(1));
            }
            else
            {
                onNotAdd();
            }
        }
        static void Main(string[] args)
        {
            var Booking = new Program();
            Booking.Run(args);
        }
        internal void Run(IEnumerable<string> args)
        {
            CheckIfFirstElementIsAdd(args: args,
                                     onAdd: AddBooking,
                                     onNotAdd: PrintErr);
        }
        private void AddBooking(IEnumerable<string> remaning)
        {
            PrintConfirmMessage();
            CheckIfInputIsJ(Input: Console.ReadLine(),
                            remaning,
                            onNotJ: () => {},
                            onJ: AddToCSV);
        }
        private void PrintConfirmMessage()
        {
            Console.WriteLine("Add Booking? [j/N]");
        }
        private void CheckIfInputIsJ(string Input, 
                                     IEnumerable<string> remaning, 
                                     Action onNotJ, 
                                     Action<IEnumerable<string>> onJ)
        {
            if (Input == "j")
            {
                onJ(remaning);
            }
            else 
            {
                onNotJ();
            }
        }
        private void AddToCSV(IEnumerable<string> remaning)
        {
            using (var fs = File.Open(path, FileMode.Append))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Flush();
                    writer.WriteLine("{0};{1};{2}", ConvertDateTimeToString(ConvertToDateTime(remaning.First())), remaning.ElementAt(1), ConvertDoubleToString(ConvertToDouble(remaning.Last())));
                }
            }
        }
        private double ConvertToDouble(string element)
        {
            return Double.Parse(element, new CultureInfo("de-DE"));
        }
        private string ConvertDoubleToString(double money)
        {
            return money.ToString();
        }
        private DateTime ConvertToDateTime(string element)
        {
            return DateTime.ParseExact(element,"d.M.yyyy", CultureInfo.InvariantCulture);
        }
        private string ConvertDateTimeToString(DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
        private void PrintErr()
        {
            Console.Error.WriteLine("Missing add!");
        }
    }
}
