using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U01_Utility
{
    public class ConsoleTexts
    {
        public static int LineLength()
        {
            return 100;
        }
        public static void SetUnicodeConsole()
        {

            // Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");

            Console.OutputEncoding = Encoding.UTF8;

            // Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");

        }
        public static void WriteTitle(string title)
        {
            int titleLength = title.Length;
            int semiMidSpace = (LineLength() - titleLength)/2;

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(new string('-', LineLength()));

            Console.Write(new string(' ', semiMidSpace));
            Console.Write(title.ToUpper());
            Console.Write(new string(' ', semiMidSpace));
            Console.Write("\n");

            Console.WriteLine(new string('-', LineLength()));

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

        }

        public static void WriteSubtitle(string subtitle)
        {

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(subtitle);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

        }

        public static void WriteOption(int number, string option)
        {
            string esp = " ";
            string separator = ". ";
            int lineLenght = LineLength();
            int wordsLenght = esp.Length + number.ToString().Length + option.Length + separator.Length;
            int emptySpace = lineLenght - wordsLenght;
            string complement = new string(' ', emptySpace);
            string emptyLine = new string(' ', lineLenght);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(emptyLine + "\n");
            Console.Write(esp + number + ". ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(option);
            Console.Write(complement + "\n");
            Console.Write(emptyLine + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }

        public static void WriteMessage(string message)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

        }

        public static void BlockSeparator(string separator = "\n")
        {

            Console.Write(separator);

        }

        public static void PauseConsole()
        {

            Console.ReadKey();

        }

        public static void TerminateConsole()
        {

            Console.ForegroundColor = ConsoleColor.Red;


            Console.Write("\n\n\nPrime qualquer tecla para saíres.");

            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
