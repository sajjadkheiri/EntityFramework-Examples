namespace EF.Relationship.Domain.Model;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; } = DateTime.Now;

    // One-To-Many Relationship

    public List<Person> Person { get; set; }
}