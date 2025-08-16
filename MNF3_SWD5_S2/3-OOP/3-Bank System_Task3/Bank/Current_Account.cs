
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class CurrentAccount : Account
    {
        public double overdraft_limit { get; set; }

        public CurrentAccount(double overdraftLimit = 5000)
        {
            overdraft_limit = overdraftLimit;
        }

        public override bool Withdraw(double Amount)
        {
            if (Amount > 0 && Amount <= overdraft_limit)
            {

                CurrentBalance -= Amount;
                Console.WriteLine($"Done ..! , Withdrawit {Amount} to Current Balance is {CurrentBalance} ");

                return true;
            }
            else
            {
                Console.WriteLine($"Cant Withdraw {Amount} Must be > 0 && <= Current Balance");
                return false;
            }
        }


        public override void ShowAccountInfo()
        {
            base.ShowAccountInfo();
            Console.WriteLine($"overdraft_limit = {overdraft_limit}");
            Console.WriteLine("------------------------------------------------");
        }
    }
}
