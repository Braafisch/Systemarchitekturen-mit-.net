using System;
using System.IO;

namespace aufgabe7_mit_FD_neu
{
    class Booking
    {
        public string path;
        public Booking(string path) => this.path = path;
        public void AddBooking(Entry entry)
        {
            using (var fs = File.Open(path, FileMode.Append))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Flush();
                    writer.WriteLine("{0};{1};{2}", entry.date.ToString("dd.MM.yyyy"), entry.usecase, entry.money);
                }
            }
        }
        public class Entry
        {
            public DateTime date;
            public string usecase;
            public decimal money;
            public Entry(DateTime date, string usecase, decimal money)
            {
                this.date = date;
                this.usecase = usecase;
                this.money = money;
            }
        }
    }
}