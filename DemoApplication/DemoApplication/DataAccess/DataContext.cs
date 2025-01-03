using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoApplication.DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Person> People { get; set; }
}
