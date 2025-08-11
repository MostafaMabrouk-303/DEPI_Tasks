namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SavingAccount s1 = new SavingAccount("Mostafa", "1111111111111", "01011111111", "cairo", 330, 20);
           // s1.ShowAccountDetails();

            CurrentAccount c1 = new CurrentAccount("Mohamed", "22222222222222", "01222222222", "cairo", 330, 10);
            //c1.ShowAccountDetails();


            List<BankAccount> BankList = new List<BankAccount> { c1, s1 };

            foreach (BankAccount b in BankList)
            {
               b.ShowAccountDetails();
                Console.WriteLine($"CalculateInterest : {b.CalculateInterest()}");
            }


            Console.ReadLine();
        }
    }
}
