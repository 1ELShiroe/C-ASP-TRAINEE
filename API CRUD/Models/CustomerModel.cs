using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class CustomerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public String? Name { get; set; }
    public String Role { get; set; } = "MEMBER";
    public String? Password { get; set; }
}
