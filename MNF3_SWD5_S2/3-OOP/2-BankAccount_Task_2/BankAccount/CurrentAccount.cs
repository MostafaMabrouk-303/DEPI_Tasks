using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class CurrentAccount : BankAccount
    {

        public decimal OverdraftLimit { get; set; }



        public CurrentAccount(string fullName, string nationalID, string phoneNumber, string address, double balance, decimal overdraftLimit)
           : base(fullName, nationalID, phoneNumber, address, balance)
        {
            OverdraftLimit = overdraftLimit;
        }



        public override decimal CalculateInterest()
        {
            return 0;
        }


        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();

            Console.WriteLine($"OverdraftLimit  : {OverdraftLimit}");
            Console.WriteLine("-------------------------------------------------------------");

        }

    }
}
