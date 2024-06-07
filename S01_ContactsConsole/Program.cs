using S01_ContactsConsole.Data;
using S01_ContactsConsole.Models;
using S01_ContactsConsole.UserInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U01_Utility;

namespace S01_ContactsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string Settings = "..\\..\\JsonFiles\\Settings.json";

            Dictionary<string, string> dataFile = JsonUtils.ReadJson<Dictionary<string, string>>(Settings);
            InitialData initialData = new InitialData();
            string file = dataFile["DataFilePath"];

            initialData.FeedData(file);

            ConsoleTexts.SetUnicodeConsole();
            ConsoleTexts.WriteTitle("Contacts");
            AppDialogue.OpeningOptions();
        }
    }
}
