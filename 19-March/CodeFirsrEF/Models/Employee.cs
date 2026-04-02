using System.ComponentModel.DataAnnotations;

namespace CodeFirsrEF.Models
{
    public class Employee
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Please enter Your First Name")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "Please enter Your Last Name")]
        public string LastName { set; get; }

        [Required(ErrorMessage = "Please enter Your Email")]
        [EmailAddress(ErrorMessage ="Enter valid Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Enter Your Age")]
        [Range(0, 100, ErrorMessage = " Enter age b/w 0 to 100 only")]

        public int Age { set; get; }
    }
}
