using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.Design;
using System.Globalization;

using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We will Create a Bank System  ");
            Console.Write("Enter Name of Bank : ");
            string BName = Console.ReadLine();

            Console.Write("Enter Branch Code of Bank : ");
            int BCode = int.Parse(Console.ReadLine());

            Bank bank = new Bank(BName, BCode);

            short Choice = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Main Menu-------------------");
                Console.WriteLine("Choice an Operation : ");
                Console.WriteLine("  1.Add New Customer");
                Console.WriteLine("  2.Open Account (Saving / Current)");
                Console.WriteLine("  3.Search Customer");
                Console.WriteLine("  4.Update Customer");
                Console.WriteLine("  5.Deposit");
                Console.WriteLine("  6.Withdraw");
                Console.WriteLine("  7.Show All Customers");
                Console.WriteLine("  8.Delete Customer");
                Console.WriteLine("  0.Exit");
                Console.WriteLine("------------------------------------------");
                Console.Write("Enter Your Choice  :  ");
                Choice = short.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------------");
                Console.Clear();

                switch (Choice)
                {
                    // Add New Customer
                    case 1:
                        Console.Write("Enter Your National ID : ");
                        string Nid = Console.ReadLine();

                        Console.Write("Enter Your Name : ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Your Birth Date : ");
                        DateTime BDate = DateTime.Parse(Console.ReadLine());

                        Customer C1 = new Customer(Nid, name, BDate);
                        bank.AddCustomer(C1);

                        Console.WriteLine("Customer Added Successfully :)");
                        break;



                      //  OPen Account Saving / Current Account
                    case 2:
                        Console.Write("Enter Customer National ID: ");
                        string custNid = Console.ReadLine();

                        Console.Write("Enter Account Type (Saving / Current): ");
                        string accType = Console.ReadLine();

                        bank.OpenAccount(custNid, accType);



                     break;


                    // Search Customer 
                    case 3:
                        Console.Write("Enter National Id Or Name : ");
                        string NidOrName = Console.ReadLine();

                        Customer found = bank.SearchCustomer(NidOrName);

                        if (found != null)
                        {
                            Console.WriteLine("Customer is Exist ");
                            Console.WriteLine(found);
                        }
                        else
                        {
                            Console.WriteLine("Customer isn't Exist ");
                        }
                        break;


                    // Update Customer
                    case 4:
                        Console.Write("Enter Customer ID : ");
                        int _CustomerID = int.Parse(Console.ReadLine());

                        Console.Write("Enter new Name : ");
                        string _Name = Console.ReadLine();

                        Console.Write("Enter new Birth Date : ");
                        DateTime _BDate = DateTime.Parse(Console.ReadLine());

                        string Result = bank.UpdateCustomer(_CustomerID, _Name, _BDate) ? "Update Done ": "Customer isn't Exist ❌";

                        Console.WriteLine(Result);
                        break;

                    // Deposit
                    case 5:
                        {
                            
                            Console.Write("Enter National ID: ");
                            string nidDep = Console.ReadLine();
                            Console.Write("Enter Account Number: ");
                            int accDep = int.Parse(Console.ReadLine());
                            Console.Write("Enter Amount to Deposit: ");
                            double dep = double.Parse(Console.ReadLine());
                            Console.WriteLine(bank.Deposit(nidDep, accDep, dep) ? "Deposit Done" : "Deposit Failed");

                         
                        }break;
                     // Withdraw
                    case 6:
                        {
                        
                            Console.Write("Enter National ID: ");
                            string nidWit = Console.ReadLine();

                            Console.Write("Enter Account Number: ");
                            int accWit = int.Parse(Console.ReadLine());

                            Console.Write("Enter Amount to Withdraw: ");
                            double wit = double.Parse(Console.ReadLine());

                            Console.WriteLine(bank.Withdraw(nidWit, accWit, wit) ? "Withdraw Done" : "Withdraw Failed");

                        }break;

                    //Show all Customers info 
                    case 7:
                        {
                            Console.WriteLine("All Customers Accounts Info");
                            bank.ShowAllCustomers();
                        }
                        break;

                     //Delete 
                    case 8:
                        {
                            Console.Write("Enter Customer ID : ");
                            int _CustID = int.Parse(Console.ReadLine());

                            string R = bank.DeleteCustomer(_CustID) ? "Deleted Successfully " : "Customer Doesn't Exist ";

                            Console.WriteLine(R);

                        }
                        break;
                    // Exit
                    default:
                        return;
                }

                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}








