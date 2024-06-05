using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U01_Utility
{
    public class ConsoleTexts
    {
        public static void SetUnicodeConsole()
        {

            // Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");

            Console.OutputEncoding = Encoding.UTF8;

            // Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");

        }
        public static void WriteTitle(string title)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(new string('-', 50));

            Console.WriteLine(title.ToUpper());

            Console.WriteLine(new string('-', 50));

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
