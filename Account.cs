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
        private int balance = 0;
        UserManager userManager = new UserManager();
        private bool loop = true;
        private bool accountCreation = true;
        private bool isLoggedIn = true;
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
                    AccountObjectives();
                    break;
                case "3":
                    Console.WriteLine("You've successfully exited the program. See you again soon!");
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

                //userManager.GetUsers(numOfUsers);
                //Console.WriteLine();

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

            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                //Console.WriteLine(numOfUsers);
                if (read_username == list[i].Username && read_PIN == list[i].PIN)
                {
                    readUsername = read_username;

                    Console.WriteLine("Login successful!");
                    Console.WriteLine();

                    Console.WriteLine("================================");
                    Console.WriteLine("         YOUR ACCOUNT           ");
                    Console.WriteLine("================================");
                    Console.WriteLine();


                    Console.WriteLine("Account Holder: " + list[i].Username);
                    Console.WriteLine();

                    return;
                }

                if (read_username != list[i].Username && read_PIN != list[i].PIN)
                {
                    Console.WriteLine("Account does not exist");
                    Console.WriteLine();
                }
            }                                
        }

        private void AccountObjectives()
        {
            while (isLoggedIn)
            {
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Transfer Money");
                Console.WriteLine("5. Transaction History");
                Console.WriteLine("6. Logout");
                Console.WriteLine();

                Console.Write("Choose an option: ");
                string optionSelected = Console.ReadLine();
                Console.WriteLine();

                switch (optionSelected)
                {
                    case "1":
                        CheckBalance();
                        break;
                    case "2":
                        DepositMoney();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        TransferMoney();
                        break;
                    case "5":
                        break;
                    case "6":
                        Console.WriteLine("You're logged out!");
                        Console.WriteLine();
                        isLoggedIn = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void CheckBalance()
        {
            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                if (readUsername == list[i].Username)
                {
                    Console.WriteLine("Available Balance: " + list[i].Balance);
                    Console.WriteLine();
                }
            }
        }

        private void DepositMoney()
        {
            Console.Write("Enter amount: ");
            string readAmount = Console.ReadLine();
            Console.WriteLine();

            int newBalance = int.Parse(readAmount);

            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                if (readUsername == list[i].Username)
                {
                    list[i].Balance += newBalance;
                }
            }

            Console.WriteLine("Deposit successfull :)");
            Console.WriteLine();
        }

        private void WithdrawMoney()
        {
            Console.Write("Enter amount: ");
            string readAmount = Console.ReadLine();
            Console.WriteLine();

            int newBalance = int.Parse(readAmount);

            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                if (readUsername == list[i].Username)
                {
                    list[i].Balance -= newBalance;
                }
            }

            Console.WriteLine("Withdraw successfull :)");
            Console.WriteLine();
        }

        private void TransferMoney()
        {
            Console.Write("From account: ");
            string readAccount = Console.ReadLine();
            Console.WriteLine();

            Console.Write("To recipient: ");
            string readRecipient = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Amount: ");
            string readAmount = Console.ReadLine();
            Console.WriteLine();

            int amount = int.Parse(readAmount);
            //balance -= amount;

            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                bool checkAccount = readAccount == list[i].Username;
                bool checkRecipient = readRecipient == list[i].Username;

                if (checkAccount)
                {
                    list[i].Balance -= amount;
                }

                if (checkRecipient)
                {
                    list[i].Balance += amount;
                }                
            }

            Console.WriteLine("Transfer successfull :)");
            Console.WriteLine();
        }
    }
}