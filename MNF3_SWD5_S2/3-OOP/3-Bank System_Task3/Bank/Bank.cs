
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System;
using System.Collections.Generic;

namespace Bank
{
    internal class Bank
    {
        public string BankName { get; set; }
        public int BranchCode { get; set; }

        public List<Customer> ListOfCustomer { get; set; } = new List<Customer>();

        public Bank(string name, int code)
        {
            BankName = name;
            BranchCode = code;
        }

        // Add New Customer
        public void AddCustomer(Customer customer)
        {
            ListOfCustomer.Add(customer);
        }

        // Search Customer 
        public Customer SearchCustomer(string _NameOrNationalId)
        {
            foreach (Customer item in ListOfCustomer)
            {
                if (_NameOrNationalId == item.NationalId
                    || _NameOrNationalId.ToLower() == item.FullName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        // Update Customer
        public bool UpdateCustomer(int _ID, string _Name, DateTime _BirthDate)
        {
            foreach (var item in ListOfCustomer)
            {
                if (item.ID == _ID)
                {
                    item.FullName = _Name;
                    item.BirthDate = _BirthDate;
                    return true;
                }
            }
            return false;
        }

        // Delete Customer
        public bool DeleteCustomer(int _ID)
        {
            Customer customer;
            foreach (var item in ListOfCustomer)
            {
                if (item.ID == _ID)
                    customer = item;
            }
            customer = null;

            if (customer != null)
            {
                ListOfCustomer.Remove(customer);
                return true;
            }
            return false;
        }
        //Deposit
        public bool Deposit(string nationalId, int accountNumber, double amount)
        {
            var cust = ListOfCustomer.FirstOrDefault(c => c.NationalId == nationalId);
            var acc = cust?.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (acc == null) return false;

            acc.Deposit(amount);
            return true;
        }

        //Withdraw
        public bool Withdraw(string nationalId, int accountNumber, double amount)
        {
            var cust = ListOfCustomer.FirstOrDefault(c => c.NationalId == nationalId);
            var acc = cust?.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (acc == null) return false;

            return acc.Withdraw(amount); 
        }


        //Show all Customers 
        public void ShowAllCustomers()
        {
            if (ListOfCustomer.Count == 0)
            {
                Console.WriteLine("No customers yet.");
                return;
            }

            foreach (var customer in ListOfCustomer)
            {
                Console.WriteLine(customer);
                foreach (var account in customer.Accounts)
                {
                    account.ShowAccountInfo();
                    Console.WriteLine("----------------");
                }
                Console.WriteLine("===================================");
            }
        }


       // Open Account(Saving / Current)
        public bool OpenAccount(string nationalId, string accountType)
        {
            Customer customer;

            foreach (var item in ListOfCustomer)
            {
                if (nationalId == item.NationalId)
                {
                    customer = item;
                    break;
                }
            }
            customer = null;


            if (customer == null)
            {
                Console.WriteLine("Customer not found!");
                return false;
            }

            Account newAccount;

            if (accountType.ToLower() == "saving")
            {
                newAccount = new SavingAccount();
            }
            else if (accountType.ToLower() == "current")
            {
                newAccount = new CurrentAccount();
            }
            else
            {
                Console.WriteLine("Invalid account type! Use 'Saving' or 'Current'.");
                return false;
            }

            customer.Accounts.Add(newAccount);
            Console.WriteLine($"{accountType} account opened successfully for {customer.FullName}, Account Number = {newAccount.AccountNumber}");
            return true;
        }

    }
}



