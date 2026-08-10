namespace NexaWorks.Data;

public class Compatibilite
{
    public int Id { get; set; }

    public int VersionId { get; set; }
    public Version Version { get; set; } = null!;

    public int OSId { get; set; }
    public OS OS { get; set; } = null!;
}
