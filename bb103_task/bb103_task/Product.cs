using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb103_task
{
    internal class Product
    {
        public string Name { get; set; }
        private double _price;

        public double Price
        {
            get { return _price; }
            set {
                if(value>0)
                {
                    _price = value;
                }
            }
        }
        private int _count;

        public int Count
        {
            get { return _count; }
            set {
                if(value>0)
                {
                    _count = value;
                }
            }
        }
        public Product(string name,double price )
        {
            Name = name;
            Price = price;
        }


    }
}
