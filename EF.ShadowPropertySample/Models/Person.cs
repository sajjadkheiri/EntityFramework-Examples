namespace EF.ShadowPropertySample.Models;

internal class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; private set; }
    public int Age { get; set; }
    public bool? IsActive { get; set; }
    public Teacher Teacher { get; set; }
}
