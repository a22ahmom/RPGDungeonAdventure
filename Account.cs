using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class Account
    {
        private string readUsername;
        private string readPIN;
        private string readPINAgain;
        private int balance;
        
        UserManager userManager = new UserManager();
        private bool loop = true;
        private bool accountCreation = true;
        private int numOfUsers = 0;

        public void InitializeProgram()
        {
            Console.WriteLine("================================");
            Console.WriteLine("        C# Banking System       ");
            Console.WriteLine("================================");
            Console.WriteLine();

            Console.WriteLine("Welcome to C# Bank");
            Console.WriteLine();           

            while (loop)
            {
                MenuOptions();
            }            
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
                    while (accountCreation)
                    {
                        CreateAccount();                        
                    }
                    accountCreation = true;
                    break;
                case "2":
                    LoginIntoAccount();
                    break;
                case "3":
                    Console.WriteLine("You've been successfully logged out. See you again soon!");
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Couldn't select an option!");
                    break;
            }
        }

        private void CreateAccount()
        {
            Console.Write("Enter username: ");
            readUsername = Console.ReadLine();

            Console.Write("Enter PIN: ");
            readPIN = Console.ReadLine();

            Console.Write("Re-type PIN: ");
            readPINAgain = Console.ReadLine();
            Console.WriteLine();

            if (readPIN == readPINAgain)
            {
                User user = new User();
                user.Username = readUsername;
                user.PIN = readPIN;
                
                userManager.AddUser(user, numOfUsers);                

                Console.WriteLine("Account has been successfully created!");
                Console.WriteLine();

                userManager.GetUsers(numOfUsers);
                Console.WriteLine();

                accountCreation = false;
                numOfUsers++;
            }
            else
            {
                Console.WriteLine("PINs do not match. Try again!");
                Console.WriteLine();
            }           
        }

        private void LoginIntoAccount()
        {
            Console.Write("Enter username: ");
            string read_username = Console.ReadLine();

            Console.Write("Enter PIN: ");
            string read_PIN = Console.ReadLine();
            Console.WriteLine();

            User user = new User();

            if (read_username == user.Username && read_PIN == user.PIN)
            {
                Console.WriteLine("Login successful!");
                Console.WriteLine();
                AccountObjectives();
            }
            else
            {
                Console.WriteLine("Account does not exist");
                Console.WriteLine();
            }                     
        }

        private void AccountObjectives()
        {
            Console.WriteLine("================================");
            Console.WriteLine("         YOUR ACCOUNT           ");
            Console.WriteLine("================================");
            Console.WriteLine();

            User user = new User();

            Console.WriteLine("Account Holder: " + user.Username);
            Console.WriteLine();
        }
    }
}
