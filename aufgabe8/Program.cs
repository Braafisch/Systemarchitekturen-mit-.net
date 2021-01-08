using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace aufgabe8
{
    class Program
    {
        private string path = "booking.csv";
        internal UserInteraction UserInteraction;
        internal DataStorage DataStorage;
        internal StartParameter StartParameter;
        internal Program()
        {
            StartParameter = new StartParameter();
            UserInteraction = new UserInteraction();
            DataStorage = new DataStorage(path);
        }
        static void Main(string[] args)
        {
            new Program().Run(args);
        }
        internal void Run(IEnumerable<string> args)
        {
            StartParameter.CheckEntry(args: args,
                                       onAdd: AddEntry,
                                       onWrongInput: UserInteraction.PrintErr,
                                       onList: List
                                       );
        }
        private void AddEntry(IEnumerable<string> remaning)
        {
            var date = DateTime.ParseExact(remaning.First(), "d.M.yyyy", CultureInfo.InvariantCulture);
            var usecase = remaning.ElementAt(1);
            var money = Decimal.Parse(remaning.Last(), new CultureInfo("de-DE"));
            UserInteraction.Confirm(onConfirm: DataStorage.AddBooking,
                                    onReject: () => { },
                                    entry: new Entry(date, usecase, money)
                                    );
        }
        private void List(IEnumerable<string> args)
        {
            Filter filter;
            List<Entry> entries = DataStorage.GetData();
            
            switch (args.Count())
            {
                case 1:
                    filter = new Filter(Convert.ToInt32(args.First()));
                    break;
                case 2:
                    filter = new Filter(Convert.ToInt32(args.First()), Convert.ToInt32(args.Last()));
                    break;
                default:
                    filter = new Filter();
                    break;
            }
            filter.SearchEntries(entries: entries,
                                 onFiltered: UserInteraction.PrintOutput,
                                 onEmpty: UserInteraction.PrintMessage);
        }
    }
}
