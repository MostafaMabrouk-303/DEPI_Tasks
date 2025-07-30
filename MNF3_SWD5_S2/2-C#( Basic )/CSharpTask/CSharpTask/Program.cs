namespace CSharpTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int FirstNumber, SecondNumber;
            char OPeration;

            Console.WriteLine("Hello!\r");
            Console.Write("Input the First Number:");
            FirstNumber = int.Parse(Console.ReadLine());

            Console.Write("Input the Secound Number:");
            SecondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What do you want to do with those numbers?");
            Console.WriteLine("[A]dd\r\n[S]ubtract\r\n[M]ultiply");
            Console.WriteLine("\t------------------------------------------------");
            OPeration = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("\t------------------------------------------------");

            switch (OPeration)
            {

                case 'A':
                    Console.WriteLine($"\t\t\t{FirstNumber} + {SecondNumber} = {FirstNumber+ SecondNumber}");
                    break;


                case 'S':
                    Console.WriteLine($"\t\t\t{FirstNumber} - {SecondNumber} = {FirstNumber - SecondNumber}");
                    break;


                case 'M':
                    Console.WriteLine($"\t\t\t{FirstNumber} * {SecondNumber} = {FirstNumber * SecondNumber}");
                    break;


                default:
                    Console.WriteLine("Invalid option"); break;

            }

            Console.WriteLine("\t------------------------------------------------");



            Console.WriteLine("Press any key to close");
            Console.ReadLine();

        }
    }
}
