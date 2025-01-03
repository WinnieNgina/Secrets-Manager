using DemoApplication.Models;

namespace DemoApplication.Repository;

public interface IPersonRepository
{
    Task AddPersonAsync(Person person);
    Task<IEnumerable<Person>> GetPeopleAsync();
}
