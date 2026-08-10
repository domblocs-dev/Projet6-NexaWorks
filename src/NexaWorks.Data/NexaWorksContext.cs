using Microsoft.EntityFrameworkCore;

namespace NexaWorks.Data;

public class NexaWorksContext : DbContext
{
    public DbSet<Produit> Produit { get; set; }
    public DbSet<Version> Version { get; set; }
    public DbSet<OS> OS { get; set; }
    public DbSet<Compatibilite> Compatibilite { get; set; }
    public DbSet<Statut> Statut { get; set; }
    public DbSet<Ticket> Ticket { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            @"Server=(localdb)\MSSQLLocalDB;Database=NexaWorks;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Interdit deux fois la même compatibilité (le même couple version + OS)
        modelBuilder.Entity<Compatibilite>()
            .HasIndex(c => new { c.VersionId, c.OSId })
            .IsUnique();

        // Longueurs de texte pour les noms courts
        modelBuilder.Entity<Produit>().Property(p => p.Nom).HasMaxLength(100);
        modelBuilder.Entity<Version>().Property(v => v.Numero).HasMaxLength(50);
        modelBuilder.Entity<OS>().Property(o => o.Nom).HasMaxLength(100);
        modelBuilder.Entity<Statut>().Property(s => s.Nom).HasMaxLength(50);

    }

}
