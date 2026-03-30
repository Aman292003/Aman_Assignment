using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public int Age { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
