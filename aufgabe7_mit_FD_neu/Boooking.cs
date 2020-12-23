using System;
using System.IO;

namespace aufgabe7_mit_FD_neu
{
    class Booking
    {
        public string Path;
        public Booking(string path) => Path = path;
        public void AddBooking(Entry entry)
        {
            using (var fs = File.Open(Path, FileMode.Append))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Flush();
                    writer.WriteLine("{0};{1};{2}", entry.Date.ToString("dd.MM.yyyy"), entry.Usecase, entry.Money);
                }
            }
        }
        public class Entry
        {
            public DateTime Date;
            public string Usecase;
            public decimal Money;
            public Entry(DateTime date, string usecase, decimal money)
            {
                Date = date;
                Usecase = usecase;
                Money = money;
            }
        }
    }
}