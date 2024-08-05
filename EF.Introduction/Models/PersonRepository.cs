using Microsoft.EntityFrameworkCore;

namespace EF.Introduction;

public class PersonRepository
{
    public void Insert(string firstName, string lastName)
    {
        Person person = new()
        {
            FirstName = firstName,
            LastName = lastName
        };

        PersonDbContex dbContex = new();

        dbContex.Add(person);
        dbContex.SaveChanges();
    }

    public void Update(int id, string firstName, string lastName)
    {
        PersonDbContex dbContex = new();

        Person person = dbContex.People.Find(id);

        if (person is not null)
        {
            person.FirstName = firstName;
            person.LastName = lastName;

            dbContex.SaveChanges();
        }
    }

    public void GetAll()
    {
        PersonDbContex dbContex = new();

        var people = dbContex.People.AsNoTracking();

        foreach (var person in people)
        {
            Console.WriteLine($"Id : {person.Id} | FirstName : {person.FirstName} | LastName : {person.LastName}");
        }
    }

    public void Delete(int id)
    {
        PersonDbContex dbContex = new();

        var person = dbContex.People.Find(id);

        if (person is not null)
        {
            dbContex.People.Remove(person);
            dbContex.SaveChanges();
        }
    }
}
