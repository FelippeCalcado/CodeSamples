using S01_ContactsConsole.BL;
using S01_ContactsConsole.Data;
using S01_ContactsConsole.Models;
using S01_ContactsConsole.UserInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U01_Utility;

namespace S01_ContactsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitialData initialData = new InitialData();
            initialData.FeedData(UIManager.GetDataPath());
            ConsoleTexts.SetUnicodeConsole();
            AppDialogue.MainMenu();
            
        }
    }
}
