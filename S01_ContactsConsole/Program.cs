using S01_ContactsConsole.Models;
using S01_ContactsConsole.UserInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U01_Utility;

namespace S01_ContactsConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleTexts.SetUnicodeConsole();
            ConsoleTexts.WriteTitle("Contacts");
            AppDialogue.OpeningOptions();
        }
    }
}
