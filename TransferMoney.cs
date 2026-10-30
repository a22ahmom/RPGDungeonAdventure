using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class TransferMoney
    {
        private string accountSender;
        private string accountReceiver;
        private int amountTransferred;

        public TransferMoney(string accSender, string accReceiver, int amTransferred)
        {
            this.accountSender = accSender;
            this.accountReceiver = accReceiver;
            this.amountTransferred = amTransferred;
        }
        public string AccountSender
        {
            get
            {
                return accountSender;
            }
            set
            {
                accountSender = value;
            }
        }

        public string AccountReceiver
        {
            get
            {
                return accountReceiver;
            }
            set
            {
                accountReceiver = value;
            }
        }

        public int AmountTransferred
        {
            get
            {
                return amountTransferred;
            }
            set
            {
                amountTransferred = value;
            }
        }
    }
}
