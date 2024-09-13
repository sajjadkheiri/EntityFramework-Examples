using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Naming;

[Table("Tbl_Car", Schema = "ef2")]
public class Car
{
    public int Id { get; set; }

    [Column("Car_Name")]
    public string Name { get; set; }
}
