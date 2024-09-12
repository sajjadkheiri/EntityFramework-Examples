using Microsoft.EntityFrameworkCore;

namespace EF.Index;

[Index(nameof(Name), IsUnique = true, Name = "IX_Name_DataAnnotation")]
public class DataAnnotationIndex
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
