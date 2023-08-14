using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_system
{
    public enum SecureMenu
    {
        CheckBalance = 1,
        PlaceDeposit,
        MakeWithdrawal,
        ViewTransaction,
        Logout
    }

    internal class DTTBankATM : IAuthenticateUser, IAccount, ITransaction
    {
        private User accountHolder;
        //private long accountNumber = 1010101010;
        private List<User> accounts;
        private Dictionary<int, Transaction> transactions;
        private const decimal minimumAmountKept = 5000;
        private readonly DTT_Bank_ATMscreen dTT_Bank_ATMscreen;

        public DTTBankATM()
        {
            dTT_Bank_ATMscreen = new DTT_Bank_ATMscreen();
            
        }

        public void Run()
        {
            DTT_Bank_ATMscreen.MainMenu();
            AuthenticateUser();
            DTT_Bank_ATMscreen.WelcomeCustomer(accountHolder.FullName);
            DTT_Bank_ATMscreen.PressEnterToContinue();
            while (true)
            {
                DTT_Bank_ATMscreen.SecureMenu();
                SecureMenuDTT();
            }
        }

        public void InitialiseData()
        {
            accounts = new List<User>()
            {
                new User(){FullName = "Eric Muganga", AccountNumber =  1000000000, CardNumber = 12121212, IsLocked = false, Pin = 1234, Balance = 30210345 },

                new User(){FullName = "Angela Uwera", AccountNumber =  1897652342, CardNumber = 12345678, IsLocked = false, Pin = 1367, Balance = 10045621 },

                new User(){FullName = "Hope Gatete", AccountNumber = 4567892945, CardNumber = 12459900, IsLocked = false, Pin = 9870, Balance =  2023498 }
            };

            transactions = new Dictionary<int, Transaction>();
        }
            

        public void AuthenticateUser()
        {
            bool loginValidity = false;
            while (loginValidity == false)
            {
                User currentUser = DTT_Bank_ATMscreen.UserLoginForm();
                DTT_Bank_ATMscreen.Login();
                foreach(User account in accounts)
                {
                    accountHolder = account;
                    if (currentUser.CardNumber.Equals(accountHolder.CardNumber))
                    {
                        accountHolder.LoginAttempts++;
                        if (currentUser.Pin.Equals(accountHolder.Pin))
                        {
                            accountHolder = account;
                            if (accountHolder.IsLocked || accountHolder.LoginAttempts > 3)
                            {
                                DTT_Bank_ATMscreen.PrintAccountLocked();
                            }
                            else
                            {
                                accountHolder.LoginAttempts = 0;
                                loginValidity = true;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Card number or pin.");
                        }
                    }
                    

                    if (loginValidity == false)
                    {
                        //Console.WriteLine("Invalid Card number or pin.");
                        accountHolder.IsLocked = accountHolder.LoginAttempts == 3;
                        if(accountHolder.IsLocked)
                        {
                            DTT_Bank_ATMscreen.PrintAccountLocked();
                            Console.WriteLine("Please take your card.");
                            Console.ReadKey();
                            DTT_Bank_ATMscreen.MainMenu();
                        }
                    }
                }
                
                
            }

            
        }

        private void SecureMenuDTT()
        {
            switch (Validator.Convert<int>("your option"))
            {
                case (int)SecureMenu.CheckBalance:
                    CheckBalance();
                    DTT_Bank_ATMscreen.PressEnterToContinue();
                    break;

                case (int)SecureMenu.PlaceDeposit:
                    Deposit();
                    DTT_Bank_ATMscreen.PressEnterToContinue();
                    break;

                case (int)SecureMenu.MakeWithdrawal:
                    Withdraw();
                    DTT_Bank_ATMscreen.PressEnterToContinue();
                    break;

                case (int)SecureMenu.ViewTransaction:
                    ViewTransaction();
                    DTT_Bank_ATMscreen.PressEnterToContinue();
                    break;

                case (int)SecureMenu.Logout:
                    DTT_Bank_ATMscreen.Logout();
                    Console.WriteLine("You have successfully logged out. Please take your card.");
                    Console.ReadKey();
                    Run();
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
        public void CheckBalance()
        {
            Console.WriteLine($"You account Balance is: {DTT_Bank_ATMscreen.currency} {accountHolder.Balance}");
        }

        public void Deposit()
        {
            decimal amount = (decimal)Validator.Convert<decimal>("amount you want to deposit");
            int transactionID = GetNextTransactionID();
            accountHolder.Balance += amount;
            transactions[transactionID] = new Transaction(transactionID, DateTime.Now, TransactionType.Deposit, amount);
            Console.WriteLine($"You have deposited:{DTT_Bank_ATMscreen.currency} {amount}. Your current Balance is: {DTT_Bank_ATMscreen.currency} {accountHolder.Balance}");
        }

        

        //public void TransactionHistory()
        //{
        //    foreach (Transaction transaction in transactions.Values)
        //    {
        //        Console.WriteLine($"Transaction ID: {transaction.TransactionID}, held on {transaction.TransactionDate}, transaction type {transaction.TransactionType} Amount {transaction.Amount}");
        //    }
        //}

        public void ViewTransaction()
        {
            foreach (Transaction transaction in transactions.Values)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionID}, held on {transaction.TransactionDate}, transaction type {transaction.TransactionType} Amount {transaction.Amount}");
            }
        }

        public void Withdraw()
        {
            decimal amount = (decimal)Validator.Convert<decimal>("amount you want to withdraw");
            if ((accountHolder.Balance > amount) && ((accountHolder.Balance - amount) > minimumAmountKept))
            {
                int transactionID = GetNextTransactionID();
                accountHolder.Balance -= amount;
                transactions[transactionID] = new Transaction(transactionID, DateTime.Now, TransactionType.Withdrawal, amount);
                Console.WriteLine($"You have withdrawn: {DTT_Bank_ATMscreen.currency} {amount}. Your current Balance is: {DTT_Bank_ATMscreen.currency} {accountHolder.Balance}");
            }
        }

        private int GetNextTransactionID()
        {
            return transactions.Count + 1;
        }

        
        //private long GetAccountNumber()
        //{
        //    return accountNumber+123;
        //}
    }
}
