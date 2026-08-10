namespace NexaWorks.Data;

public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;

    public List<Version> Versions { get; set; } = new();
}
