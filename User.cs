using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class User
    {
        private User[] list = new User[1];
        private string username;
        private string pin;

        public bool AddUser(User user)
        {
            list.Append(user);
            return true;
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
    }
}
