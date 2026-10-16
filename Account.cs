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
        private string[] allUsernames;
        private string[] allPINs;
        //User[] listOfUsers = new User[1];
        User user = new User();
        bool loop = true;

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
                    //Console.WriteLine("You selected option 1");
                    CreateAccount();
                    break;
                case "2":
                    //Console.WriteLine("you selected option 2");
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

            
            user.Username = readUsername;
            user.PIN = readPIN;
            user.AddUser(user);

            Console.WriteLine("Account has been successfully created!");
            Console.WriteLine();

            //Instantiating array of objects
            //object[] objArray = new object[5];
        }

        private void LoginIntoAccount()
        {
            Console.Write("Enter username: ");
            string read_username = Console.ReadLine();


            Console.Write("Enter PIN: ");
            string read_PIN = Console.ReadLine();
            Console.WriteLine();

            

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

            

            Console.WriteLine("Account Holder: " + user.Username);
            Console.WriteLine();

        }

    }
}
