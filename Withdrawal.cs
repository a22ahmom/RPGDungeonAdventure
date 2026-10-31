using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDungeonAdventure
{
    internal class Withdrawal
    {
        private string sourceAccount;
        private int withdrawalAmount;

        public Withdrawal(string sourceAcc, int withdrawalAmt)
        {
            this.sourceAccount = sourceAcc;
            this.withdrawalAmount = withdrawalAmt;
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

        public int WithdrawalAmount
        {
            get
            {
                return withdrawalAmount;
            }
            set
            {
                withdrawalAmount = value;
            }
        }
    }
}
