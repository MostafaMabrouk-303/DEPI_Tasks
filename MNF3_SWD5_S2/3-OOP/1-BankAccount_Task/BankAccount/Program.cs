namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            //Create  BankAccount objects using different constructors
            
            BankAccount B1= new BankAccount();
            BankAccount B2 = new BankAccount("MostafaMabrouk","12345678993456","01286674711","Cairo",3000.11);
            BankAccount B3= new BankAccount("Mohamed Ali", "12345678993455", "01066674711");


            // Call ShowAccountDetails() for each to display their info.
            B1.ShowAccountDetails(B1);
            B2.ShowAccountDetails(B2);
            B3.ShowAccountDetails(B3);




            Console.ReadLine();
        }
    }
}
