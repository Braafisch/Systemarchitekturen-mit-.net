using System;

namespace aufgabe6
{
    class ROT13
    {
        private readonly string input { get; private set; }
        public ROT13(string input) => this.input = input;

        private string convert_ger_char(string ger_string)
        {
            var eng_string = "";
            foreach(var character in ger_string)
            {
                var value = Convert.ToInt32(character);
                switch (value)
                {
                    case 228:
                        eng_string += "ae";
                        break;
                    case 246:
                        eng_string += "ue";
                        break;
                    case 252:
                        eng_string += "oe";
                        break;
                    case 196:
                        eng_string += "AE";
                        break;
                    case 214:
                        eng_string += "OE";
                        break;
                    case 220:
                        eng_string += "UE";
                        break;
                    case 223:
                        eng_string += "SS";
                        break;
                    default:
                        eng_string += character;
                        break;
                }
            }
            return eng_string;
        }
        private char convert(char character)
        {
            character = Char.ToUpper(character);
            var value = Convert.ToInt32(character);
            value = (value + 13 - 65) % 26;
            return Convert.ToChar(value + 65); 
        }
        public string encrypt()
        {
            var result = "";
            var eng_input = convert_ger_char(input);
            foreach(var character in eng_input)
            {
                result += Char.IsLetter(character) ? convert(character) : character;
            }
            return result;
        }
        public override string ToString()
        {
            return input ?? string.Empty;
        }
        
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var rot13 = new ROT13();
                Console.WriteLine("{0} -> {1}", rot13.ToString(), rot13.encrypt());
            }
            
        }
    }
}
