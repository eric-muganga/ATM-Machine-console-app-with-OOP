using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_system
{
    internal class User
    {
       

        public string FullName { get; set; }

        public long AccountNumber { get; set; }

        public long CardNumber { get; set; }

        public decimal Balance { get; set; }
        public int Pin { get; set; }

        public bool IsLocked { get; set; }
        public int LoginAttempts { get; set; }



        //public User(string fullName, long accountNumber, long cardNumber, bool isLocked, int pin, decimal balance)
        //{
        //    this.FullName = fullName;
        //    this.AccountNumber = accountNumber;
        //    this.CardNumber = cardNumber;
        //    this.IsLocked = isLocked;
        //    this.Pin = pin;
        //    this.Balance = balance;
        //}

        //public bool AuthenticateUser(long cardNumber, int pin)
        //{
        //    if (accounts.ContainsKey(cardNumber))
        //    {
        //        User user = accounts[cardNumber];
        //        return user.Pin == pin;
        //    }
        //    return false;
        //}
    }
}
