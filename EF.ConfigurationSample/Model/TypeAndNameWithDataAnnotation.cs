using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF.ConfigurationSample;

public class TypeAndNameWithDataAnnotation
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }
    public bool IdValid { get; set; }
    
    [Precision(14,4)]
    public decimal Price { get; set; }
    
    [Unicode(false)]
    [MaxLength(10)]
    public string Code { get; set; }
}
