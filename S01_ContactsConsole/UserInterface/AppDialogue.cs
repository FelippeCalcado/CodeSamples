using S01_ContactsConsole.BL;
using S01_ContactsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using U01_Utility;

namespace S01_ContactsConsole.UserInterface
{
    public static class AppDialogue
    {
        public static void Opening(string subtitle)
        {
            ConsoleTexts.WriteTitle("Contacts");
            ConsoleTexts.WriteSubtitle(subtitle);
        }
        public static void MainMenu()
        {
            Console.Clear();

            Opening("hello! Welcome to your list of contacts.");

            ConsoleTexts.WriteSubtitle("Choose an option below.");
            ConsoleTexts.BlockSeparator();
            ConsoleTexts.WriteOption(1, "Create a contact");
            ConsoleTexts.WriteOption(2, "Display all Contacts");
            ConsoleTexts.WriteOption(3, "Find a contact by name");
            ConsoleTexts.WriteOption(4, "Edit a contact");
            ConsoleTexts.WriteOption(5, "Delete a contact");
            ConsoleTexts.WriteOption(6, "Exit");

            ConsoleTexts.BlockSeparator();
            Console.Write("Option: ");
            string answer = Console.ReadLine();

            UIManager.MainMenuDecisions(answer);
        }

        public static void UpdateMenu()
        {
            Console.Clear();
            Opening("Update");
            Contact contact = UIManager.GetContactByPropertyValue();
            //List<Contact> contacts = JsonUtils.ReadJson<List<Contact>>(UIManager.GetDataPath());
            Console.WriteLine(contact.ContactID);
            Console.WriteLine(contact.ContactName);
            Console.WriteLine(contact.PhoneNumber);
        }
    }
}
