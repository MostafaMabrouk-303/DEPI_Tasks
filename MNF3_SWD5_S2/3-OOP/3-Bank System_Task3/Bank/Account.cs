
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank
{
    internal abstract class Account
    {

        static int _AccountNum = 0;

        public int AccountNumber { get; }  

        public double CurrentBalance { get; set; }

        public DateTime OpenedDate { get; set; }

        public Account()
        {
            AccountNumber = ++_AccountNum;
            OpenedDate = DateTime.Now;
        }

        // Deposit
        public void Deposit(double Amount)
        {
            if(Amount > 0)
            {
                CurrentBalance += Amount;
                Console.WriteLine($"Done ..! , Deosit {Amount} to Current Balance Successfully :) ");
            }
            else
            {
                Console.WriteLine($"Cant Add {Amount} Must be > 0 ");
            }
        }

        //Withdraw
        public virtual bool Withdraw(double Amount)
        {
            if (Amount > 0 && Amount<=CurrentBalance)
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

        public virtual void ShowAccountInfo()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Account Number = {AccountNumber}");
            Console.WriteLine($"Current Balance = {CurrentBalance}");
            Console.WriteLine($"Opened Date= {OpenedDate}");
            Console.WriteLine("------------------------------------------------");


        }


    }
}
