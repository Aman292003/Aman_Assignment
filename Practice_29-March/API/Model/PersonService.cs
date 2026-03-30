using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class PersonService : IPersonService
    {
        private readonly PersonDB _context;

        public PersonService(PersonDB context)
        {
            _context = context;
        }
        public async Task<Person> Add(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> Delete(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return false;
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if(person == null)
            {
                return null;
            }
            return person;
            
        }

        public async Task<Person> Update( Person person)
        {
            int id = person.PersonId;
            var existingPerson = await _context.Persons.FindAsync(id);
            if (existingPerson == null)
            {
                return null;
            }
            existingPerson.Name = person.Name;
            existingPerson.Age = person.Age;
           
            existingPerson.Email = person.Email;
            existingPerson.Phone = person.Phone;
            await _context.SaveChangesAsync();

            return existingPerson;

        }
    }
}
