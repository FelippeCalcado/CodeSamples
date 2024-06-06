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
        static async Task Main(string[] args)
        {

            string Settings = "..\\..\\JsonFiles\\Settings.json";

            Dictionary<string, string> dataFile = JsonUtils.ReadJson< Dictionary<string, string>>(Settings);
            InitialData initialData = new InitialData();
            initialData.FeedData(dataFile["DataFilePath"]);
            ContactList CL = JsonUtils.ReadJson<ContactList>(dataFile["DataFilePath"]);



            ConsoleTexts.SetUnicodeConsole();
            ConsoleTexts.WriteTitle("Contacts");


            /*
            Dictionary<string, string> dicSample = new Dictionary<string, string>();
            ContactList sample = new ContactList();


            string newName = "Ten";

            foreach (Contact contact in CL.ContactsList)
            {
                if (contact.ContactName == "One")
                {
                    Contact cont = JsonUtils.EditJson(dataFile["DataFilePath"], contact, "ContactName", newName);
                    CL.ContactsList.Add(cont); ;
                    CL.ContactsList.Remove(contact);
                }
                Console.WriteLine(contact.ContactName);
                ConsoleTexts.PauseConsole();
            }
            */

            AppDialogue.OpeningOptions();
        }
    }
}
