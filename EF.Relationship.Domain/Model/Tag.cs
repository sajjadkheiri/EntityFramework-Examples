namespace EF.Relationship.Domain.Model;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Many-To-Many
    public virtual List<PostTag> PostTags { get; set; }
}