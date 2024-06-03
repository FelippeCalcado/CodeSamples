using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U01_Utility;

namespace S01_ContactsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleTexts.SetUnicodeConsole();
            ConsoleTexts.WriteTitle("Contacts");
            ConsoleTexts.WriteSubtitle("Choose an option");
            for (int i = 1;  i < 11; i++)
            {
                ConsoleTexts.WriteMessage($"{i}. Contact number {i}");
            }
        }
    }
}
