using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demothi.Models;

public class lam1
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
}
// dotnet aspnet-codegenerator controller -name lam2Controller -m lam2 -dc demothi.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
