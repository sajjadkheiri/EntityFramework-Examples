namespace EF.Entities;

public class Discount
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public string Name { get; set; }
    public decimal NewPrice { get; set; }
}
