using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace aufgabe7_mit_FD_neu
{
    class Program
    {
        private string path = "booking.csv";
        internal UserInteraction UserInteraction;
        internal Booking Booking;
        internal Program()
        {
            UserInteraction = new UserInteraction();
            Booking = new Booking(path);
        }
        static void Main(string[] args)
        {
            new Program().Run(args);
        }
        internal void Run(IEnumerable<string> args)
        {
            UserInteraction.CheckEntry(args: args,
                                       onAdd: AddEntry,
                                       onWrongInput: UserInteraction.PrintErr,
                                       onMissingArg: UserInteraction.PrintMissingErr
                                       );
        }
        private void AddEntry(IEnumerable<string> remaning)
        {
            var date = DateTime.ParseExact(remaning.First(),"d.M.yyyy", CultureInfo.InvariantCulture);
            var usecase = remaning.ElementAt(1);
            var money = Decimal.Parse(remaning.Last(), new CultureInfo("de-DE"));
            UserInteraction.Confirm(onConfirm: Booking.AddBooking,
                                    onReject: () => {},
                                    entry: new Booking.Entry(date, usecase, money)
                                    );
        }
    }
}
