using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class Account
    {
        private string username;
        private int pin;
        private int balance;

        
        public void InitializeProgram()
        {
            Console.WriteLine("================================");
            Console.WriteLine("        C# Banking System       ");
            Console.WriteLine("================================");
            Console.WriteLine();

            Console.WriteLine("Welcome to C# Bank");
            Console.WriteLine();

            MenuOptions();
        }

        private void MenuOptions()
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            Console.Write("Choose an option: ");
            string menuOptionSelected = Console.ReadLine();
            Console.WriteLine();

            switch (menuOptionSelected)
            {
                case "1":
                    Console.WriteLine("You selected option 1");
                    break;
                case "2":
                    Console.WriteLine("You selected option 2");
                    break;
                case "3":
                    Console.WriteLine("You selected option 3");
                    break;
                default:
                    Console.WriteLine("Couldn't select an option!");
                    break;
            }
        }

    }
}
