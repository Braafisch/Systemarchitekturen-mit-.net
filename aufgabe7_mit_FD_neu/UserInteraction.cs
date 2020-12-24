using System;
using System.Collections.Generic;
using System.Linq;

namespace aufgabe7_mit_FD_neu
{
    class UserInteraction
    {
        public void CheckEntry(IEnumerable<string> args,
                               Action<IEnumerable<string>> onAdd,
                               Action onWrongInput,
                               Action onMissingArg)
        {
            if (args.First() == "add" && args.Count() == 4)
            {
                onAdd(args.Skip(1));
            }
            else if (args.Count() == 4)
            {
                onWrongInput(); 
            }
            else
            {
                onMissingArg();
            }
        }
        public void Confirm(Action<Booking.Entry> onConfirm,
                            Action onReject,
                            Booking.Entry entry)
        {
            Console.WriteLine("Add Booking? [y/N]");
            switch (Console.ReadLine().Trim().ToUpper())
            {
                case "Y":
                    onConfirm(entry);
                    break;
                case "":
                case "N":
                    onReject();
                    break;
                default:
                    Console.Error.WriteLine("Wrong Input!");
                    break;
            }
        }
        public void PrintErr()
        {
            Console.Error.WriteLine("Wrong Input!");
        }
        public void PrintMissingErr()
        {
            Console.Error.WriteLine("Missing Argument!");
        }
    }
}