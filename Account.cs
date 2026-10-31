using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace RPGDungeonAdventure
{
    internal class Account
    {
        private string readUsername;
        private string readPIN;
        private string readPINAgain;
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
                    isLoggedIn = true;
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

            int initialMoneyAmount = 0;            

            if (readPIN == readPINAgain)
            {
                User user = new User(readUsername, readPIN, initialMoneyAmount);
                
                userManager.AddUser(user, numOfUsers);       

                Console.WriteLine("Account has been successfully created!");
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

            User[] list = userManager.GetUsers();

            for (int i = 0; i <= numOfUsers; i++)
            {
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

                    AccountObjectives();

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
                        TransactionHistory();
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

            Deposit deposit = new Deposit(readUsername, newBalance);

            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                if (readUsername == list[i].Username)
                {
                    list[i].Balance += newBalance;
                    list[i].Deposit = deposit;
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

            Withdrawal withdrawal = new Withdrawal(readUsername, newBalance);

            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                if (readUsername == list[i].Username)
                {
                    list[i].Balance -= newBalance;
                    list[i].Withdrawal = withdrawal;
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

            TransferMoney tf = new TransferMoney(readAccount, readRecipient, amount);

            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                if (readUsername == list[i].Username)
                {
                    list[i].TransferMny = tf;

                    Console.WriteLine(list[i].Username);
                    Console.WriteLine(list[i].PIN);
                    Console.WriteLine(list[i].Balance);

                    Console.WriteLine(list[i].TransferMny.AccountSender);
                    Console.WriteLine(list[i].TransferMny.AccountReceiver);
                    Console.WriteLine(list[i].TransferMny.AmountTransferred);
                }

                if (readRecipient == list[i].Username)
                {
                    list[i].TransferMny = tf;
                }

                bool checkAccount = readAccount == list[i].Username;
                bool checkRecipient = readRecipient == list[i].Username;

                if (checkAccount)
                {
                    if (list[i].Balance != 0)
                    {
                        list[i].Balance -= amount;

                        Console.WriteLine("Transfer successfull :)");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Unable to transfer money due to insufficient amount");
                        Console.WriteLine();
                    }
                }

                if (checkRecipient)
                {
                    list[i].Balance += amount;
                }                
            }
        }

        private void TransactionHistory()
        {
            User[] list = userManager.GetUsers();

            for (int i = 0; i < numOfUsers; i++)
            {
                if (readUsername == list[i].Username)
                {
                    var table = new ConsoleTable("Sender", "Receiver", "Amount Transferred", "Source Account", "Amount deposited", "Source Account", "Amount Withdrawn");

                    table.AddRow(
                        list[i].TransferMny.AccountSender,
                        list[i].TransferMny.AccountReceiver,
                        list[i].TransferMny.AmountTransferred,
                        list[i].Deposit.SourceAccount,
                        list[i].Deposit.DepositAmount,
                        list[i].Withdrawal.SourceAccount,
                        list[i].Withdrawal.WithdrawalAmount);

                    table.Write(Format.MarkDown);                    
                }
            }
        }
    }
}