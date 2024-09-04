using System.ComponentModel.DataAnnotations.Schema;

namespace EF.ConfigurationSample;

[NotMapped]
public class Contact
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
}
