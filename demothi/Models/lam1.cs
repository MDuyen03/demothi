using System.ComponentModel.DataAnnotations;

namespace demothi.Models;

public class lam1
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
}