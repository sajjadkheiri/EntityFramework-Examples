namespace EF.Relationship.Infrastructure.DTO;

public class PersonInputDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int GroupId { get; set; }
}