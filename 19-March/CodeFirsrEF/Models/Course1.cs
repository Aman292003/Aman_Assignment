using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirsrEF.Models
{
    public class Course1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   
        
        public int Id { set; get; }
        
        [Required]
        [Column("Stitle" ,TypeName = "varchar")]
        public string Title { set; get; }

        public string Description { set; get; }

        public float fullprice { set; get; }

        public Author1 author { set; get; }
       
        [ForeignKey("Author")]

        public int AuthorId { set; get; }
    }
}
