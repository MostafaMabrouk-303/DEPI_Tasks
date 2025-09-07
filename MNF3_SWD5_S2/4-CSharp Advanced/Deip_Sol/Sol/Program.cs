namespace Sol
{

    static class Extentions
    {
        public static int CalcExtentionMethod(this int X , int Y, Func<int,int,int> Operation)
        {
          
            return Operation(X, Y);

        }


    }




    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Number 1 : ");
            int X=int.Parse(Console.ReadLine());


            Console.Write("Enter Number 2 : ");
            int Y=int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("1. + ");
            Console.WriteLine("2. - ");
            Console.WriteLine("3. * ");
            Console.WriteLine("4. / ");
            Console.WriteLine("5. % ");
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Choice Number of OPeration : ");
            short Op = short.Parse(Console.ReadLine());

            Console.WriteLine("-------------------------------------------------");

            int Result = 0;

            switch (Op)
            {
                case 1:
                    Result = X.CalcExtentionMethod(Y, (X, Y) => X + Y);

                break;

                case 2:
                    Result = X.CalcExtentionMethod(Y, (X, Y) => X - Y);

                break;

                case 3:
                    Result = X.CalcExtentionMethod(Y, (X, Y) => X * Y);

                break;

                case 4:
                    Result = X.CalcExtentionMethod(Y, (X, Y) => X / Y);

                break;

                case 5:
                    Result = X.CalcExtentionMethod(Y, (X, Y) => X % Y);

                break;

                default:
                    Console.WriteLine("Choice correct OPeration ");
                break;
            }




           
            Console.WriteLine($"Result = {Result}");
            Console.WriteLine("-------------------------------------------------");


            Console.ReadLine();
        }


    }
}
