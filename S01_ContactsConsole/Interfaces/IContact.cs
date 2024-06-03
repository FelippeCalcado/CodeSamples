using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace S01_ContactsConsole.Interfaces
{
    internal interface IContact
    {
        int ContactID { get; set; }
        string ContactName { get; set; }
        

    }
}
