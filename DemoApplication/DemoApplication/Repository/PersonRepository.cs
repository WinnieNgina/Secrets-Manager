using DemoApplication.DataAccess;
using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoApplication.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly DataContext _context;
    public PersonRepository(DataContext context)
    {
        _context = context;
    }
    public async Task AddPersonAsync(Person person)
    {
        var result = await _context.People.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Person>> GetPeopleAsync()
    {
        return await _context.People
                              .AsNoTracking()
                              .ToListAsync();
    }

}
