using System;
using System.Collections.Generic;
using System.Linq;

namespace aufgabe8
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
        public void Confirm(Action<Entry> onConfirm,
                            Action onReject,
                            Entry entry)
        {
            Console.WriteLine("Add booking? [y/N]");
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
                    PrintErr();
                    break;
            }
        }
        public void PrintOutput(List<Entry> entries)
        {
            foreach(Entry entry in entries)
            {
                Console.WriteLine("{0} {1} {2}", entry.date.ToString("dd.MM.yyyy"), entry.usecase, entry.money.ToString());
            }
        }
        public void PrintErr()
        {
            Console.Error.WriteLine("Wrong input!");
        }
        public void PrintMessage()
        {
            Console.Error.WriteLine("Nothing was found!");
        }
    }
}