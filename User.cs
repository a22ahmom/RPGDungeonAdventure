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
    }
}
