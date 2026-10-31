using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class User
    {
        private string username;
        private string pin;
        private int balance = 0;
        TransferMoney transferMny = new TransferMoney(null, null, 0);
        Deposit deposit = new Deposit(null, 0);
        Withdrawal withdrawal = new Withdrawal(null, 0);

        public User(string username, string pin, int balance, TransferMoney transferMoney = null, Deposit deposit = null, Withdrawal withdrawal = null)
        {
            this.username = username;
            this.pin = pin;
            this.balance = balance;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string PIN
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }

        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public TransferMoney TransferMny
        {
            get
            {
                return transferMny;
            }
            set
            {
                transferMny = value;
            }
        }

        public Deposit Deposit
        {
            get
            {
                return deposit;
            }
            set
            {
                deposit = value;
            }
        }

        public Withdrawal Withdrawal
        {
            get
            {
                return withdrawal;
            }
            set
            {
                withdrawal = value;
            }
        }
    }
}
