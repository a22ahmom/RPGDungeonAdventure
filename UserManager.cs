using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class UserManager
    {
        private User[] list = new User[5];

        public bool AddUser(User user, int numOfUsers)
        {
            for (int i = 0; i <= numOfUsers; i++)
            {
                if (list[i] == null)
                {
                    list[i] = user;
                }
            }
            return true;
        }

        public User[] GetUsers()
        {            
            //for (int i = 0; i <= numOfUsers; i++)
            //{
            //    Console.WriteLine(list[i].Username);
            //}
            return list;
        }

        public User GetUser(User user, int numOfUsers)
        {
            for (int i = 0; i < numOfUsers; i++)
            {
                if (list[i].Username == user.Username)
                {
                    return user;
                }
            }
            return user;
        }
    }
}
