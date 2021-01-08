using System;
using System.Collections.Generic;
using System.Linq;

namespace aufgabe8
{
    class StartParameter
    {
        public void CheckEntry(IEnumerable<string> args,
                               Action<IEnumerable<string>> onAdd,
                               Action onWrongInput,
                               Action<IEnumerable<string>> onList)
        {
            if (args.First() == "add" && args.Count() == 4)
            {
                onAdd(args.Skip(1));
            }
            else if (args.First() == "list" && args.Count() <= 3)
            {
                onList(args.Skip(1));
            }
            else
            {
                onWrongInput();
            }
        }
    }
}