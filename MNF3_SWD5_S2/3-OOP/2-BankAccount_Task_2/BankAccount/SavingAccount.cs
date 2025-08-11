using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class SavingAccount : BankAccount
    {
          public decimal InterestRate { set; get; }

        public SavingAccount(string fullName, string nationalID, string phoneNumber, string address, double balance, decimal interestRate)
          : base(fullName, nationalID, phoneNumber, address, balance)
        {
            InterestRate = interestRate;
        }

        public override decimal CalculateInterest()
        {

            return (decimal)Balance * InterestRate / 100;
        }


        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"InterestRate  : {InterestRate}");
            Console.WriteLine($"CalculateInterest  : {CalculateInterest()}");
            Console.WriteLine("-------------------------------------------------------------");

        }

    }
}
