using LINQtoObject;
using System.Threading.Tasks;
using static LINQtoObject.SampleData;

namespace SolofLinq_2
{
    internal class SortingClass
    {

        public static void FindBooksSorted(IEnumerable<Book> Result)
        {
            short SortingMehtod, DescOrAsc;

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("------------------Sortting Way--------------------");
            Console.WriteLine("1 .Book Title");
            Console.WriteLine("2 .Book PageCount");
            Console.WriteLine("3 .Book Price");
            Console.WriteLine("4 .Book Isbn");
            Console.WriteLine("5 .Book Subject");
            Console.WriteLine("---------------------------------------------------------");
            Console.Write("Enter Number for Way of Sorting : ");
            SortingMehtod = short.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("1.ASC");
            Console.WriteLine("2.DESC");

            Console.WriteLine("---------------------------------------------------------");
            Console.Write("Enter Number of Sorting way : ");
            DescOrAsc = short.Parse(Console.ReadLine());

            //var Result = Books;

            switch (SortingMehtod)
            {
                //By Title
                case 1:
                    if (DescOrAsc == 1)
                    {
                        Result = Result.OrderBy(p => p.Title);
                    }
                    else
                    {
                        Result = Result.OrderByDescending(p => p.Title);
                    }


                    break;

                // By PageCount
                case 2:
                    if (DescOrAsc == 1)
                    {
                        Result = Result.OrderBy(p => p.PageCount);
                    }
                    else
                    {
                        Result = Result.OrderByDescending(p => p.PageCount);
                    }


                    break;


                //By Price
                case 3:
                    if (DescOrAsc == 1)
                    {
                        Result = Result.OrderBy(p => p.Price);
                    }
                    else
                    {
                        Result = Result.OrderByDescending(p => p.Price);
                    }


                    break;


                //By Isbn
                case 4:
                    if (DescOrAsc == 1)
                    {
                        Result = Result.OrderBy(p => p.Isbn);
                    }
                    else
                    {
                        Result = Result.OrderByDescending(p => p.Isbn);
                    }


                    break;


                //By Subject
                case 5:
                    if (DescOrAsc == 1)
                    {
                        Result = Result.OrderBy(p => p.Subject.Name);
                    }
                    else
                    {
                        Result = Result.OrderByDescending(p => p.Subject.Name);
                    }


                    break;


            }

            Console.Clear();
            if (Result.Count() == 0)
            {
                Console.WriteLine("there is No Exist Books ");
                return;
            }
            Console.WriteLine($"there are {Result.Count()} Books After Sorting : ");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var item in Result)
                Console.WriteLine(item.Title);
            

        }







    }
}
