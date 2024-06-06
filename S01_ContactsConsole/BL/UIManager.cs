using S01_ContactsConsole.Models;
using S01_ContactsConsole.UserInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01_ContactsConsole.BL
{
    public static class UIManager
    {
        public static void GetUserChoice(string answer)
        {
            string Settings = "..\\..\\JsonFiles\\Settings.json";
            Dictionary<string, string> dicSample = new Dictionary<string, string>();
            ContactList sample = new ContactList();

            Dictionary<string, string> dataFile = U01_Utility.JsonUtils.ReadJson< Dictionary<string, string>>(Settings);
            ContactList CL = U01_Utility.JsonUtils.ReadJson<ContactList>(dataFile["DataFilePath"]);

            switch(answer)
            {
                case "1":
                    Console.Clear();
                    U01_Utility.ConsoleTexts.WriteTitle("Contacts");

                    foreach(Contact contact in CL.ContactsList)
                    {
                        Console.WriteLine(contact.ContactName);
                        foreach(Address address in contact.Addresses)
                        {
                            Console.WriteLine(" " + address.Street);
                        }
                        U01_Utility.ConsoleTexts.BlockSeparator();
                    }
                    U01_Utility.ConsoleTexts.PauseConsole();
                    AppDialogue.OpeningOptions();

                    break;

                case "2":
                    Console.Clear();
                    U01_Utility.ConsoleTexts.WriteTitle("Contacts");
                    U01_Utility.ConsoleTexts.WriteSubtitle("Write Contact´s name.");

                    string name = Console.ReadLine();
                    Console.Clear();
                    U01_Utility.ConsoleTexts.WriteTitle("Contacts");
                    List<Contact> contacts = new List<Contact>();
                    foreach(Contact contact in CL.ContactsList)
                    {
                        if(contact.ContactName == name)
                        {
                            contacts.Add(contact);
                        }
                    }

                    if (contacts.Count > 0)
                    {
                        foreach (Contact contact in contacts)
                        {
                            Console.WriteLine(contact.ContactName);
                            foreach (Address address in contact.Addresses)
                            {
                                Console.WriteLine(" " + address.Street);
                            }
                            U01_Utility.ConsoleTexts.BlockSeparator();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        U01_Utility.ConsoleTexts.WriteTitle("Contacts");
                        U01_Utility.ConsoleTexts.WriteSubtitle("Name not found.");
                        U01_Utility.ConsoleTexts.TerminateConsole();

                    }
                    U01_Utility.ConsoleTexts.PauseConsole();
                    AppDialogue.OpeningOptions();



                    break;
            }
        }
    }
}
