using Helper;

namespace bb103_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("hevva", 50, "qorxu");
            Book book2 = new Book("ali ve nino", 50, "eylence");
            Book book3 = new Book("adem", 10, "drama");
            Library library = new Library();
            library.AddBook(book);
            library.AddBook(book2);
            library.AddBook(book3);
            var getbook = library.GetBook("adem");
            Console.WriteLine(getbook.Name+ " " + getbook.Price);

            

        }
    }
}