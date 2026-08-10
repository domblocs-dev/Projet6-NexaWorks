namespace NexaWorks.Data;

public class Version
{
    public int Id { get; set; }
    public string Numero { get; set; } = null!;

    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;
}
