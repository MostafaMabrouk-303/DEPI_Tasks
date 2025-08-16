using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SavingAccount : Account
    {
        public double interest_rate { get; set; }

        public SavingAccount(double interestRate = 0.05) 
        {
            interest_rate = interestRate;
        }

        public void ApplyInterest()
        {
            double interest = CurrentBalance * interest_rate;
            Deposit(interest);  
            Console.WriteLine($"Interest {interest} added at rate {interest_rate * 100}%");
        }

        public override void ShowAccountInfo()
        {
            base.ShowAccountInfo();
            Console.WriteLine($"Interest Rate= {interest_rate*100} %");
            Console.WriteLine("------------------------------------------------");
        }

    }
}
