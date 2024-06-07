using S01_ContactsConsole.Models;
using S01_ContactsConsole.UserInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U01_Utility;

namespace S01_ContactsConsole.BL
{
    public static class UIManager
    {
        public static void GetUserChoice(string answer)
        {
            string Settings = "..\\..\\JsonFiles\\Settings.json";
            Dictionary<string, string> dicSample = new Dictionary<string, string>();

            Dictionary<string, string> dataFile = U01_Utility.JsonUtils.ReadJson< Dictionary<string, string>>(Settings);
            string DataFilePath = dataFile["DataFilePath"];
            List<Contact> CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);

            switch(answer)
            {
                case "1":
                    CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Contacts");
                    ConsoleTexts.WriteSubtitle("Create Contact");

                    ConsoleTexts.WriteSubtitle("Write Contact´s name.");
                    string name = Console.ReadLine();
                    List<int> ids = new List<int>();
                    foreach(Contact contact in CL)
                    {
                        ids.Add(contact.ContactID);
                    }
                    int id = ids.Max();
                    Contact newContact = new Contact()
                    {
                        ContactID = id + 1,
                        ContactName = name,
                    };
                    JsonUtils.CreateItemInJson<Contact>(DataFilePath, newContact);


                    ConsoleTexts.PauseConsole();
                    AppDialogue.OpeningOptions();

                    break;

                case "2":
                    CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Contacts");

                    foreach(Contact contact in CL)
                    {
                        Console.WriteLine(contact.ContactName);
                        foreach(Address address in contact.Addresses)
                        {
                            Console.WriteLine(" " + address.Street);
                        }
                        ConsoleTexts.BlockSeparator();
                    }
                    ConsoleTexts.PauseConsole();
                    AppDialogue.OpeningOptions();

                    break;

                case "3":
                    CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Contacts");
                    ConsoleTexts.WriteSubtitle("Write Contact´s name.");

                    name = Console.ReadLine();
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Contacts");
                    List<Contact> contacts = new List<Contact>();
                    foreach(Contact contact in CL)
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
                            Console.WriteLine("ID: " + contact.ContactID);
                            Console.WriteLine("Name: " + contact.ContactName);
                            int ad = 1;
                            foreach (Address address in contact.Addresses)
                            {
                                Console.WriteLine($"Address #{ad}: " + address.Street);
                                ad++;
                            }
                            ConsoleTexts.BlockSeparator();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        ConsoleTexts.WriteTitle("Contacts");
                        ConsoleTexts.WriteSubtitle("Name not found.");
                        ConsoleTexts.TerminateConsole();

                    }
                    ConsoleTexts.PauseConsole();
                    AppDialogue.OpeningOptions();
                    break;

                case "4":
                    CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Edit Contact");
                    ConsoleTexts.WriteSubtitle("Write Contact´s name.");
                    name = Console.ReadLine();
                    ConsoleTexts.WriteSubtitle("Write Contact´s property name.");
                    string prop = Console.ReadLine();
                    ConsoleTexts.WriteSubtitle("Write Contact´s new property value.");
                    string newValue = Console.ReadLine();
                    Console.Clear();
                    JsonUtils.EditItemInJson<Contact>(DataFilePath, prop, name, newValue);

                    ConsoleTexts.PauseConsole();
                    AppDialogue.OpeningOptions();
                    break;

                case "5":
                    CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Edit Contact");
                    ConsoleTexts.WriteSubtitle("Write Contact´s name.");
                    name = Console.ReadLine();

                    foreach (Contact contact in CL)
                    {
                        if (contact.ContactName == name)
                        {
                            Console.Clear();
                            ConsoleTexts.WriteTitle("Contacts");
                            Console.Clear();
                            JsonUtils.DeleteItemInJson<Contact>(DataFilePath, contact, "ContactName", name);
                            AppDialogue.OpeningOptions();
                        }
                        else
                        {
                            ConsoleTexts.WriteMessage("Contact not found. Press any key to continue.");
                            ConsoleTexts.PauseConsole();
                            AppDialogue.OpeningOptions();
                        }
                    }

                    break;
            }
        }
    }
}
