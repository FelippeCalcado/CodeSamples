using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01_ContactsConsole.Models
{
    public class ContactList
    {
        public int ContactListID { get; set; }
        public ICollection<Contact> ContactsList { get; set; } = new HashSet<Contact>();
    }
}
