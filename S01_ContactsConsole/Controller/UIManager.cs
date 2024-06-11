using S01_ContactsConsole.Models;
using S01_ContactsConsole.Views;
using S01_ContactsConsole.UserInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using U01_Utility;

namespace S01_ContactsConsole.BL
{
    public static class UIManager
    {
        public static string GetDataPath()
        {
            string Settings = "..\\..\\JsonFiles\\Settings.json";
            Dictionary<string, string> dataFile = JsonUtils.ReadJson<Dictionary<string, string>>(Settings);
            string DataFilePath = dataFile["DataFilePath"];
            return DataFilePath;
        }

        public static int GetId()
        {
            List<Contact> contactList = JsonUtils.ReadJson<List<Contact>>(GetDataPath());
            List<int> ids = new List<int>();

            foreach (Contact cont in contactList)
            {
                ids.Add(cont.ContactID);
            }
            return ids.Max() + 1;


        }
        public static void CreateContact()
        {

            Contact contact =  Views.Contact.Create.Dialogue();

            contact.ContactID = GetId();

            JsonUtils.CreateItemInJson(GetDataPath(), contact);
            AppDialogue.MainMenu();
        }






        /* Ongoing Review */
        public static Contact SetProp(PropertyInfo prop, Contact contact)
        {
            Dictionary<string, string> cctData = new Dictionary<string, string>();
            string q = $"Write value for{prop.Name}.";
            string answer = Console.ReadLine();
            PropertyInfo prp = typeof(Contact).GetProperty(prop.Name);
            try
            {
                Console.Clear();
                Console.WriteLine("b1");
                cctData[prop.Name] = answer;
                prop.SetValue(contact, answer);
                Console.WriteLine("b2");
            }
            catch
            {
                try
                {
                    Console.WriteLine("c1");
                    int ans = Convert.ToInt32(answer);
                    cctData[prop.Name] = answer;
                    prop.SetValue(contact, answer);
                    Console.WriteLine("c2");

                }
                catch
                {
                    Console.WriteLine("Invalid value insert a namber.");

                    answer = Console.ReadLine();
                    Console.WriteLine("d1");
                    switch (answer)
                    {
                        case "1":
                            SetProp(prp, contact);
                            break;

                        case "2":
                            AppDialogue.MainMenu();
                            break;
                    }
                    Console.WriteLine("d2");

                }
            }

            return contact;
        }


        public static Contact InstantiateContact()
        {
            Contact contact = new Contact();
            Dictionary<string, string> cctData = new Dictionary<string, string>();
            foreach (PropertyInfo prop in typeof(Contact).GetProperties())
            {
                Console.Clear();

                foreach (KeyValuePair<string, string> kvp in cctData)
                {
                    Console.WriteLine(kvp.Key, kvp.Value);
                }
                ConsoleTexts.BlockSeparator();

                if (prop.Name == "ContactID")
                {
                    List<Contact> contacts = JsonUtils.ReadJson<List<Contact>>(GetDataPath());

                    List<int> ids = new List<int>();
                    foreach (Contact ctc in contacts)
                    {
                        ids.Add(ctc.ContactID);
                    }

                    int id = ids.Max();
                    contact.ContactID = id + 1;
                }
                else
                {
                    if (prop.PropertyType != typeof(List<>))
                    {
                        Console.WriteLine("a1a");
                        SetProp(prop, contact);
                    }
                }
            }
            return contact;
        }
        public static void MainMenuDecisions(string answer)
        {

            string DataFilePath = GetDataPath();

            List<Contact> CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);

            switch (answer)
            {
                case "1":
                    CreateContact();
                    break;

                case "2":
                    CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Contacts");

                    foreach (Contact contact in CL)
                    {
                        Console.WriteLine("Id: " + contact.ContactID);
                        Console.WriteLine("Name: " + contact.ContactName);
                        Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                        foreach (Address address in contact.Addresses)
                        {
                            Console.WriteLine(" " + address.Street);
                        }
                        ConsoleTexts.BlockSeparator();
                    }
                    ConsoleTexts.PauseConsole();
                    AppDialogue.MainMenu();

                    break;

                case "3":
                    CL = JsonUtils.ReadJson<List<Contact>>(DataFilePath);
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Contacts");
                    ConsoleTexts.WriteSubtitle("Write Contact´s name.");

                    string name = Console.ReadLine();
                    Console.Clear();
                    ConsoleTexts.WriteTitle("Contacts");
                    List<Contact> contacts = new List<Contact>();
                    foreach (Contact contact in CL)
                    {
                        if (contact.ContactName == name)
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
                    AppDialogue.MainMenu();
                    break;

                case "4":
                    AppDialogue.UpdateMenu();
                    ConsoleTexts.PauseConsole();
                    AppDialogue.MainMenu();



                    /*
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
                    AppDialogue.MainMenu();*/
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
                            AppDialogue.MainMenu();
                        }
                        else
                        {
                            ConsoleTexts.WriteMessage("Contact not found. Press any key to continue.");
                            ConsoleTexts.PauseConsole();
                            AppDialogue.MainMenu();
                        }
                    }

                    break;

                case "6":
                    ConsoleTexts.TerminateConsole();
                    break;
            }
        }


        // Get

        public static Contact GetContactByPropertyValue()
        {
            List<Contact> contacts = JsonUtils.ReadJson<List<Contact>>(GetDataPath());

            var propInfo = typeof(Contact).GetProperties();
            List<PropertyInfo> propInfoList = typeof(Contact).GetProperties().ToList();
            List<string> propNames = new List<string>();

            foreach (PropertyInfo p in propInfo)
            {
                propNames.Add(p.Name);
            }

            for (int i = 0; i < propInfoList.Count; i++)
            {
                ConsoleTexts.WriteOption(i + 1, propInfoList[i].Name);
            }


            Console.Write("Option: ");
            int answer = ConvertStringOptionToInt();
            PropertyInfo opProp = propInfoList[answer - 1];

            Console.Write("Insert the value to search: ");

            string pValue = Console.ReadLine().ToString();
            foreach (PropertyInfo p in propInfo)
            {
                if (opProp.Name == p.Name)
                {
                    foreach (Contact contact in contacts)
                    {
                        if (pValue == p.GetValue(contact, null).ToString())
                        {
                            return contact;
                        }
                    }

                }

                ConsoleTexts.WriteMessage("Invalid value, Try again.");
                GetContactByPropertyValue();
            }
            return null;
        }

        public static int ConvertStringOptionToInt()
        {
            int ans = 0;
            string answer = Console.ReadLine();
            try
            {
                ans = Convert.ToInt16(answer);
                return ans;
            }
            catch
            {
                ConsoleTexts.WriteMessage("Invalid value, insert a number within the options range.");
                ConvertStringOptionToInt();
            };
            return ans;
        }
    }
}
