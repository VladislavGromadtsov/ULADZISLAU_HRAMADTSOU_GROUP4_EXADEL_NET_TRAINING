namespace ProductManager.Core.Models;

public class Audit
{
    public DateTime CreatedOn { get; set; }
    public int Version { get; set; } = 1;
}
