using S01_ContactsConsole.BL;
using S01_ContactsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U01_Utility;

namespace S01_ContactsConsole.UserInterface
{
    public static class AppDialogue
    {
        public static void Opening()
        {
            U01_Utility.ConsoleTexts.WriteTitle("Contacts");
            ConsoleTexts.WriteSubtitle("hello! Welcome to your list of contacts.");
        }
        public static void OpeningOptions()
        {
            Console.Clear();
            Opening();
            ConsoleTexts.WriteSubtitle("Choose an option below.");
            ConsoleTexts.BlockSeparator();
            ConsoleTexts.WriteMessage("1    Display all Contacts.");
            ConsoleTexts.WriteMessage("2    Find a contact by name.");

            string answer = Console.ReadLine();
            UIManager.GetUserChoice(answer);
        }
    }
}
