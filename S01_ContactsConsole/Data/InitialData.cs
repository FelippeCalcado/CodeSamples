using S01_ContactsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U01_Utility;

namespace S01_ContactsConsole.Data
{
    public class InitialData
    {
        public void SeedContactList(string file)
        {
            Address address1 = new Address()
            {
                AddressID = 1,
                Street = "Alpha"
            };

            Address address2 = new Address()
            {
                AddressID = 2,
                Street = "Beta"
            };

            Address address3 = new Address()
            {
                AddressID = 3,
                Street = "Gamma"
            };

            Contact contact1 = new Contact()
            {
                ContactID = 1,
                ContactName = "One",
                Addresses = new List<Address>()
            };

            contact1.Addresses.Add(address1);
            contact1.Addresses.Add(address2);


            Contact contact2 = new Contact()
            {
                ContactID = 2,
                ContactName = "Two",
                Addresses = new List<Address>()

            };

            contact2.Addresses.Add(address2);

            Contact contact3 = new Contact()
            {
                ContactID = 3,
                ContactName = "Three",
                Addresses = new List<Address>()
            };

            contact3.Addresses.Add(address3);

            List<Contact> contactList = new List<Contact>() { contact1, contact2, contact3 };

            JsonUtils.CreateJson(contactList, file);

        }
        public void FeedData(string file)
        {
            try
            {
                List<Contact> contactList = JsonUtils.ReadJson<List<Contact>>(file);
                if (contactList.Count == 0)
                {
                    SeedContactList(file);
                };
            }
            catch
            {
                SeedContactList(file);
            }

            
        }
    }



}
