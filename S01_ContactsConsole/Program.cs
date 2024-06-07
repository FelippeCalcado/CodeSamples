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

            //  string filePath, string property, string oldValue, string newValue
            // JsonUtils.EditItemInJson<Contact>(file, "ContactName", "One", "Ten");

            AppDialogue.OpeningOptions();


            /*
            Contact C4 = new Contact()
            {
                ContactID = 4,
                ContactName = "Fourth"
            };

            //JsonUtils.CreateItemInJson(file, C4);
            List<Contact> CL = JsonUtils.ReadJson<List<Contact>>(file);
            foreach (Contact c in CL)
            {
                ConsoleTexts.WriteMessage(c.ContactName);
            }
            JsonUtils.DeleteItemInJson(file, C4, "ContactID", "4");

            ConsoleTexts.PauseConsole();
            List<Contact> CL2 = JsonUtils.ReadJson<List<Contact>>(file);
            foreach (Contact c in CL2)
            {
                ConsoleTexts.WriteMessage(c.ContactName);
            }

            ConsoleTexts.WriteMessage(CL2.Count.ToString());
            */


        }
    }
}
