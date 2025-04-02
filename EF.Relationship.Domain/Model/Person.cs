namespace EF.Relationship.Domain.Model;

public class Person()
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
    // One-To-Many Relationship

    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    
}