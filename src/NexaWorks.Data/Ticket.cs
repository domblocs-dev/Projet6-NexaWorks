namespace NexaWorks.Data;

public class Ticket
{
    public int Id { get; set; }
    public DateOnly DateCreation { get; set; }
    public DateOnly? DateResolution { get; set; }
    public string Probleme { get; set; } = null!;
    public string? Resolution { get; set; }

    public int StatutId { get; set; }
    public Statut Statut { get; set; } = null!;

    public int CompatibiliteId { get; set; }
    public Compatibilite Compatibilite { get; set; } = null!;
}
