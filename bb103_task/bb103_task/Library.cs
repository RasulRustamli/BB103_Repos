using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb103_task
{
    internal class Library
    {
        Book[] Books=new Book[0];
        public void AddBook(Book book)
        {
            Array.Resize(ref Books, Books.Length+1);
            Books[Books.Length-1] = book;
        }
        public Book GetBook(string name)
        {
            foreach (Book item in Books)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
