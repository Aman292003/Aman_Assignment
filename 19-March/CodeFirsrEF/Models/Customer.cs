using System.ComponentModel.DataAnnotations;

namespace CodeFirsrEF.Models
{
    public class Customer
    {
        public int CustomerId { set; get; }

        [Required]
        public string CustomerName { set; get; }

        public ICollection<Product> products { set; get; }
    }
}
