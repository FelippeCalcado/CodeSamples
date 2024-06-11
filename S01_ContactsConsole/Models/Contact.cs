using S01_ContactsConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace S01_ContactsConsole.Models
{
    public class Contact : IContact
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
