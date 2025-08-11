using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {

        public const string BankCode = "BNK001";
        public readonly DateTime CreatedDate = DateTime.Now;

        private int _accountNumber;
        private string _fullName;
        private string _nationalID;
        private string _phoneNumber;
        private double _balance;
        private string _address;


        public int AccountNumber
        {
            get { return _accountNumber; }
            set {_accountNumber = value;}
        }

        //Must not be null or empty. 
        public string FullName {
            get { return _fullName; }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _fullName = value;
                else
                    Console.WriteLine( "Invalid Name !!");
                
            }
        }

        //Must be exactly 14 digits. 
        public string NationalID
        {
            get 
            {
                return _nationalID;
            }
            set
            {
                if (value.Length==14)
                    _nationalID = value;
                else
                    Console.WriteLine("Invalid..NationalID Must be 14 Digit !!");

            }
        }

        //Must start with "01" and be 11 digits long.
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value.Length == 11 & value[0]==0 & value[1] == 1)
                    _phoneNumber = value;
                else
                    Console.WriteLine("Invalid PhoneNumber !!");

            }
        }

        //Must be greater than or equal to 0. 
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value >= 0)
                    _balance = value;
                else
                    Console.WriteLine("Invalid Balance !!");
            }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


        //Default 1 
        public BankAccount()
        {
            _accountNumber = 1;
            _fullName = "ClientName";
           _nationalID= "12345678910123";
            _phoneNumber = "01234567891";
            _balance = 10.0;
            _address = "Cairo";
        }

        //Accepts full name, national ID, phone number, address, and balance
        public BankAccount(string FullName, string NationalID, string PhoneNumber, string Address, double Balance)
        {
            _fullName = FullName;
            _nationalID = NationalID;
            _phoneNumber = PhoneNumber;
            _address = Address;
            _balance = Balance;

        }


        //Overloaded constructor
        public BankAccount(string FullName, string NationalID, string PhoneNumber)
        {
            _fullName = FullName;
            _nationalID = NationalID;
            _phoneNumber = PhoneNumber;
            _balance = 0;

        }


        //Method 1 ShowAccountDetails()
        public virtual void ShowAccountDetails()
        {
            Console.WriteLine("--------------------[Account Details]------------------------");

            Console.WriteLine($"Bank Code      : {BankCode}");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Full Name      : {FullName}");
            Console.WriteLine($"National ID    : {NationalID}");
            Console.WriteLine($"Phone Number   : {PhoneNumber}");
            Console.WriteLine($"Address        : {Address}");
            Console.WriteLine($"Craeted Date   : {CreatedDate}");
            Console.WriteLine($"Balance        : {Balance}");



            Console.WriteLine("-------------------------------------------------------------");

        }

        //Method 2   IsValidNationalID()  
        public bool IsValidNationalID(string NationalID)
        {
            return NationalID.Length==14 ? true : false;
        }

        //Method 3   IsValidPhoneNumber()   

        public bool IsValidPhoneNumber(string PhoneNumber)
        {
            return PhoneNumber[0] == 0 & PhoneNumber[1] == 1 & PhoneNumber.Length==11 ? true : false;
        }


        public virtual decimal CalculateInterest()
        {
            return 0;
        }



    }
}
