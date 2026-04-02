using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirsrEF.Models
{
    public class Product
    {
        public int ProductId { set; get; }

        [Required]
        public string ProductName { set; get; }

        [Display(Name ="who buyed")]

        public int CustomerId { set; get; }
        [ForeignKey("CustomerId")]


        public Customer Customer { set; get; }
    }
}
