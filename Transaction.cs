using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_system
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
    internal class Transaction
    {
        //private int transactionID = 0;
        //public DateTime GetDateTime() { return DateTime.Now; }

        //public int TransactionID { get { return transactionID; } set { transactionID = value; } }
        public int TransactionID { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public TransactionType TransactionType { get; set; }

        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Transaction(int transactionID, DateTime transactionDate, TransactionType TransactionType, decimal amount)
        {
            this.TransactionID = transactionID;
            this.TransactionDate = transactionDate;
            this.Amount = amount; 
            this.TransactionType = TransactionType;
        }
    }
}
