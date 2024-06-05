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
            /* List */
            /*
            ContactList contactsList = new ContactList()
            {
                ContactListID = 1
            };

            Address address1 = new Address()
            {
                AddressID = 1,
                Street = "Street Alpha"
            };

            Address address2 = new Address()
            {
                AddressID = 2,
                Street = "Street Beta"
            };

            Address address3 = new Address()
            {
                AddressID = 3,
                Street = "Street Gamma"
            };

            Address address4 = new Address()
            {
                AddressID = 4,
                Street = "Street Delta"
            };



            Contact contact1 = new Contact()
            {
                ContactID = 1,
                ContactName = "One"
            };

            Contact contact2 = new Contact()
            {
                ContactID = 2,
                ContactName = "two"
            };

            Contact contact3 = new Contact()
            {
                ContactID = 3,
                ContactName = "three"
            };

            contact1.Addresses.Add(address1);
            contact1.Addresses.Add(address2);
            contact2.Addresses.Add(address3);
            contact3.Addresses.Add(address4);

            contactsList.ContactsList.Add(contact1);
            contactsList.ContactsList.Add(contact2);
            contactsList.ContactsList.Add(contact3);

            string contactFile = "C:\\DEV2024\\RumosSamples\\CodeSamples\\S01_ContactsConsole\\JsonFiles\\ContactsList.json";
            JsonUtils.CreateJson(contactsList, contactFile);
            ContactList CL = JsonUtils.ReadJson(contactFile, contactsList);

            
            foreach(Contact contact in CL.ContactsList)
            {
                Console.WriteLine( "Contact Id:" + contact.ContactID);
                Console.WriteLine( "Contact Name:" + contact.ContactName);
                foreach(Address address in contact.Addresses)
                {
                    Console.WriteLine("Address:" + address.Street);
                }
                ConsoleTexts.BlockSeparator();
                
            }
        */
        }
    }
}
