using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace aufgabe8
{
    public class DataStorage
    {
        public string path;
        public DataStorage(string path) => this.path = path;
        public void AddBooking(Entry entry)
        {
            using (var fs = File.Open(path, FileMode.Append))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.WriteLine("{0};{1};{2}", entry.date.ToString("dd.MM.yyyy"), entry.usecase, entry.money);
                }
            }
        }
        public List<Entry> GetData()
        {
            List<Entry> entries = new List<Entry>();
            using (var fs = File.Open(path, FileMode.Open))
            {
                using (var reader = new StreamReader(fs))
                {
                    string line;
                    IEnumerable<string> lineArray;
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                            break;
                        if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                        {
                            lineArray = line.Split(";");
                            var date = DateTime.ParseExact(lineArray.First(), "d.M.yyyy", CultureInfo.InvariantCulture);
                            var usecase = lineArray.ElementAt(1);
                            var money = Decimal.Parse(lineArray.Last(), new CultureInfo("de-DE"));
                            var entry = new Entry(date, usecase, money);
                            entries.Add(entry);
                        }
                    }
                }
            }
            return entries;
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
    public class Filter
    {
        public int month;
        public int year;
        public Filter()
        {
            var now = DateTime.Now;
            this.month = now.Month;
            this.year = now.Year;
        }
        public Filter(int month)
        {
            var now = DateTime.Now;
            this.month = month;
            this.year = now.Year;
        }
        public Filter(int month, int year)
        {
            this.month = month;
            this.year = year;
        }
        public void SearchEntries(List<Entry> entries,
                                  Action<List<Entry>> onFiltered,
                                  Action onEmpty)
        {
            var filteredEntries = new List<Entry>();
            foreach (Entry entry in entries)
            {
                var month = entry.date.Month;
                var year = entry.date.Year;
                if (year == this.year && month == this.month)
                {
                    filteredEntries.Add(entry);
                }
            }
            if (filteredEntries.Any())
            {
                onFiltered(filteredEntries);
            }
            else
            {
                onEmpty();
            }
        }
    }
}