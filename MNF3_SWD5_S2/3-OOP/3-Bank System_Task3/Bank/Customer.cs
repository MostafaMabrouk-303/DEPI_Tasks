using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Bank
{
    internal class Customer
    {
        static int _idCounter = 0;

        public int ID { get; }
        public string NationalId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

       public List<Account> Accounts { get; set; } = new List<Account>(); 

        public Customer(string _NationalId,string _Name, DateTime _BirthDate)
        {
            ID = ++_idCounter;
            NationalId = _NationalId;
            FullName= _Name;
            BirthDate= _BirthDate;

            
        }

        public override string ToString()
        {
            return $"Customer ID = {ID} \n National Id = {NationalId} \n Name = {FullName} \n BirhtTime = {BirthDate} \n Number Of Accounts  {Accounts.Count}";
        }
    }
}
