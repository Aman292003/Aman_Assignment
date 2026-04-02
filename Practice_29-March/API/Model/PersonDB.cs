using Microsoft.EntityFrameworkCore;    
namespace API.Model
{
    public class PersonDB : DbContext

    {
        public PersonDB(DbContextOptions<PersonDB> options) : base(options)
        {

        }
       public  DbSet<Person> Persons { get; set; }
    }
}
