using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class Deposit
    {
        private string sourceAccount;
        private int depositAmount;

        public Deposit(string sourceAcc, int depositAmt)
        {
            this.sourceAccount = sourceAcc;
            this.depositAmount = depositAmt;
        }

        public string SourceAccount
        {
            get
            {
                return sourceAccount;
            }
            set
            {
                sourceAccount = value;
            }
        }

        public int DepositAmount
        {
            get
            {
                return depositAmount;
            }
            set
            {
                depositAmount = value;
            }
        }
    }
}
