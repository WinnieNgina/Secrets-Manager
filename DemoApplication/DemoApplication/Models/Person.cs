using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Models;

public class Person
{
    public int Id { get; set; }
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(100)]
    [EmailAddress]
    public required string Email { get; set; }

}
