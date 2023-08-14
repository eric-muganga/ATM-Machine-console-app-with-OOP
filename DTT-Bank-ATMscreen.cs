using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_system
{
    internal class DTT_Bank_ATMscreen
    {
        internal const string currency = "UGX ";
        public static void MainMenu()
        {
            // clearing the console buffer and display information
            Console.Clear();

            // setting the title to display in the console title bar
            Console.Title = "DTT Bank ATM Machine";
            
            Console.WriteLine(" ---------------------------- ");
            Console.WriteLine("|   Welcome to DTT Bank ATM  |");
            Console.WriteLine("|          services          |");
            Console.WriteLine("|                            |");
            Console.WriteLine("|   Please Insert  your card |");
            Console.WriteLine("|                            |");
            Console.WriteLine(" ---------------------------- ");

            
        }

        internal static User UserLoginForm()
        {
            User currentUser = new User();

            currentUser.CardNumber = (long)Validator.Convert<long>("your cardNumber");
            currentUser.Pin = (int)Validator.Convert<int>("your pin");
            return currentUser;
        }

        internal static void Login()
        {
            Console.WriteLine("\n Checking Card and pin.....");
        }

        internal static void PrintAccountLocked()
        {
            Console.Clear();
            Console.WriteLine("You Debit card is locked.!!! \nPlease visit a nearby Branch " +
                "to unlock your card");
            Console.WriteLine("Thank you for using DTT Bank ATM services");
            //currentUser.IsLocked = true;
        }

        internal static void WelcomeCustomer(string fullName)
        {
            Console.WriteLine($"Welcome back, {fullName}");
            
        }

        internal static void SecureMenu()
        {
            Console.Clear();
            Console.WriteLine(" ------------------------------- ");
            Console.WriteLine("|   Welcome to the secure Menu  |");// customer name
            Console.WriteLine("|                               |");
            Console.WriteLine("|     1.Check Balance           |");
            Console.WriteLine("|     2.Cash Deposit            |");
            Console.WriteLine("|     3.Withdrawal              |");
            Console.WriteLine("|     4.Transactions History    |");
            Console.WriteLine("|     5.Logout                  |");
            Console.WriteLine("|                               |");
            Console.WriteLine(" ------------------------------- ");
        }

        internal static void Logout()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using DTT Bank ATM services");
            
        }

        internal static void PressEnterToContinue()
        {
            Console.Write("\nPress enter to continue: ");
            Console.ReadKey();
        } 

    }
}
