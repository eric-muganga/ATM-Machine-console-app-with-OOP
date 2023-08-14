using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_system
{
    internal interface IAccount
    {
        void CheckBalance();
        void Deposit();
        void Withdraw();

        //void TransactionHistory();
    }
}
