using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb103_task
{
    internal class Book:Product
    {
        public string Genre { get; set; }
        public Book(string name, double price,string genre) : base(name, price)
        {
            Genre = genre;
        }

    
    }
}
