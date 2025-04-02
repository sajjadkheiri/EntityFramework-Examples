namespace EF.Relationship.Domain.Model;

public class Post
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; } = DateTime.Now;

    // Many-To-Many
    public List<PostTag> PostTags { get; set; }
}