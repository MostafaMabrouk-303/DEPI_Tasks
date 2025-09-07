
using LINQtoObject;
using System.Diagnostics;
using System.Linq;
using static LINQtoObject.SampleData;

namespace SolofLinq_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///1-Display book title and its ISBN.           
            ///foreach (var book in Books)
            ///    Console.WriteLine($"Book Title: {book.Title} , Book ISBN: {book.Isbn}");
            ///

            ///2-Display the first 3 books with price more than 25.
            /// var Result = Books.Where(B => B.Price > 25).Take(3).ToList();
            /// foreach (var book in Result)
            ///     Console.WriteLine(book);

            ///3-Display Book title along with its publisher name. (Using 2 methods).
            ///1.
            ///var Result = Books.Select
            ///    (b => new { BookTitle = b.Title, PublisherName = b.Publisher.Name });
            ///2.
            ///var Result = from b in Books
            ///             select new { BookTitle = b.Title, PublisherName = b.Publisher.Name };
            ///foreach (var b in Result)
            ///    Console.WriteLine($"\"{b.BookTitle}\" Published By \"{b.PublisherName}\"");

            ///4-Find the number of books which cost more than 20.        
            /// var Result = Books.Where(B => B.Price > 20).Count();
            ///Console.WriteLine($"Number Of Books = {Result}");

            ///5-Display book title, price and subject name sorted by its subject name ascending and by its price descending.           
            ///var Result = (from b in Books
            ///              orderby b.Subject.Name
            ///              orderby b.Price descending
            ///              select new { Title = b.Title, Price = b.Price, Subject = b.Subject });
            ///foreach (var B in Result)
            ///    Console.WriteLine($"Title = {B.Title} , Price = {B.Price} , Subject = {B.Subject} .");

            ///6-Display All subjects with books related to this subject. (Using 2 methods).
            ///1.
            /// var Result = from b in Books
            ///              group b by b.Subject;
            /// 
            /// foreach (var group in Result)
            /// {
            ///     Console.WriteLine(group.Key);
            /// 
            ///     foreach (var book in group)
            ///     {
            ///         Console.WriteLine($"............{book.Title}");
            ///     }
            /// }
            /// 
            /// 2.
            /// var Result = Books.GroupBy(b=>b.Subject).ToList();
            /// 
            /// foreach (var group in Result)
            /// {
            ///     Console.WriteLine(group.Key);
            /// 
            ///     foreach (var book in group)
            ///     {
            ///      Console.WriteLine($"............{book.Title}");
            ///     }
            /// }

            ///7-Try to display book title & price (from book objects) returned from GetBooks Function.
            /// var Result = GetBooks();
            /// foreach (var obj in Result)
            /// {
            ///     Book b = (Book)obj;
            ///     Console.WriteLine($"Book Title : {b.Title} , Book Price = {b.Price}\n");
            /// }

            ///8-Display books grouped by publisher & Subject.
            ///  var Result = from b in Books
            ///               group b by b.Publisher
            ///              into Group
            ///               from g in Group
            ///               group g by g.Subject;
            /// 
            /// foreach (var group in Result)
            /// {
            ///     Console.WriteLine(group.Key);
            ///
            ///         foreach (var item in group)
            ///         {
            ///     Console.WriteLine($"{item.Publisher} :: {item.Price}");
            ///         }
            /// }

            ///Bonus
            /// string PublisherName;
            /// 
            /// string[] PublishersNAme = Publishers.Select(p => p.Name).ToArray();
            /// 
            /// Console.Write("Publishers Names : ");
            /// foreach (var pup in PublishersNAme)
            ///     Console.Write($"{pup} ..");
            /// 
            /// Console.WriteLine("\n---------------------------------------------------------");
            /// 
            /// 
            /// Console.Write("Enter Publisher Name : ");
            /// PublisherName = Console.ReadLine();
            /// 
            /// 
            /// if (!PublishersNAme.Contains(PublisherName))
            /// {
            ///     Console.WriteLine("this Publisher isn't Exist !!");
            ///     return ;
            /// }
            /// 
            /// var Result = Books.Where(b => b.Publisher.Name == PublisherName);
            /// 
            /// SortingClass.FindBooksSorted(Result);


            Console.ReadLine();
        }
    }
}
