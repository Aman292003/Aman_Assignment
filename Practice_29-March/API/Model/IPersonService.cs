namespace API.Model
{
    public interface IPersonService
    {
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<Person> Add(Person person);
        Task<Person> Update(Person person);
        Task<bool> Delete(int id);
    }
}
