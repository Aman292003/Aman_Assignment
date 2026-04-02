using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFdemo.Models
{
    internal class Product
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public decimal Price { set; get; }

        public int CategoryId { set; get; }

        public Category category { set; get; }
    }
}
