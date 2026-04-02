namespace CodeFirsrEF.Models
{
    public class Author
    {
        public int Id { get; set; } 
        public string? AuthorName { set; get; }

        public IList<Course> Courses { get; set; }
    }
}
