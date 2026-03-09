using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFdemo.Models
{
    internal class Author
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public List<Course> courses { set; get; }

    }
}
