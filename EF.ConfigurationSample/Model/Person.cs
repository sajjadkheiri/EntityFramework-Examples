using System.ComponentModel.DataAnnotations.Schema;

namespace EF.ConfigurationSample;

public class Person
{
    public Person(string lastName)
    {
        LastName = lastName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; private set; }
    public int Age { get; set; }
    public bool? IsActive { get; set; }
    public string GetStringAge { get; }
    public Teacher Teacher { get; set; }

    // [NotMapped]
     public List<Contact> Contacts { get; set; }
}
