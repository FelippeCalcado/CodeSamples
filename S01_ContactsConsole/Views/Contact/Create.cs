using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S01_ContactsConsole.UserInterface;
using S01_ContactsConsole.Models;
using U01_Utility;

namespace S01_ContactsConsole.Views.Contact
{
    public class Create
    {
        public static Models.Contact ConfirmData(Models.Contact contact)
        {
            Console.Clear();
            AppDialogue.Opening("Create Contact");
            ConsoleTexts.WriteMessage("Name: " + contact.ContactName);
            ConsoleTexts.WriteMessage("Phone number: " + contact.PhoneNumber);

            string[] options =
            {
                "Save",
                "Clear",
                "Cancel"
            };

            int n = 1;
            foreach (string option in options)
            {
                U01_Utility.ConsoleTexts.WriteOption(n, option);
                n++;
            }

            Console.Write("Option: ");
            string answer = Console.ReadLine();
            if(answer == "1")
            {
                return contact;
            }
            else if(answer == "2")
            {
                return Dialogue();
            }
            else if (answer == "3")
            {
                AppDialogue.MainMenu();
            }
            else
            {
                Console.Clear();
                ConsoleTexts.WriteMessage("Invalid option.");
                ConfirmData(contact);
            }
            return contact;
        }

        public static Models.Contact Dialogue()
        {
            Console.Clear();
            AppDialogue.Opening("Create Contact");

            string contactsName;
            string contactsPhone;

            ConsoleTexts.WriteMessage("Write Contact´s name.");
            Console.Write("Name: ");
            contactsName = Console.ReadLine();

            ConsoleTexts.WriteMessage("Write Contact´s phone number.");
            Console.Write("Phone number: ");
            contactsPhone = Console.ReadLine();

            
            Models.Contact contact = new Models.Contact()
            {
                ContactName = contactsName,
                PhoneNumber = contactsPhone
            };

            Models.Contact contact_confirmed = ConfirmData(contact);

            return contact_confirmed;
        }
    }
}
