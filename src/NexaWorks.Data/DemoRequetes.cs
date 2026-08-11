// Les 20 demandes de la liste, exprimées comme 20 jeux de paramètres
// de la MÊME requête ObtenirTickets. C'est un fichier de DONNÉES ;
// la boucle qui les exécute et les affiche est écrite dans Program.cs.

namespace NexaWorks.Data;

// Un cas = un titre + les paramètres à passer à ObtenirTickets
public record Cas(
    string Titre,
    string? Statut = null,
    string? Produit = null,
    string? Version = null,
    DateOnly? DateDebut = null,
    DateOnly? DateFin = null,
    string[]? MotsCles = null);

public static class DemoRequetes
{
    // Valeurs d'exemple : produit "Trader en Herbe", version "1.2",
    // période du 01/01/2026 au 30/06/2026, mot-clé "écran".
    public static readonly Cas[] LesVingtCas =
    {
        new("1. En cours (tous les produits)",
            Statut: "En cours"),
        new("2. En cours, un produit (toutes versions)",
            Statut: "En cours", Produit: "Trader en Herbe"),
        new("3. En cours, un produit (une version)",
            Statut: "En cours", Produit: "Trader en Herbe", Version: "1.2"),
        new("4. Rencontrés sur une période, un produit (toutes versions)",
            Produit: "Trader en Herbe",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30)),
        new("5. Rencontrés sur une période, un produit (une version)",
            Produit: "Trader en Herbe", Version: "1.2",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30)),
        new("6. En cours, mots-clés (tous les produits)",
            Statut: "En cours", MotsCles: new[] { "écran" }),
        new("7. En cours, un produit, mots-clés (toutes versions)",
            Statut: "En cours", Produit: "Trader en Herbe", MotsCles: new[] { "écran" }),
        new("8. En cours, un produit, mots-clés (une version)",
            Statut: "En cours", Produit: "Trader en Herbe", Version: "1.2", MotsCles: new[] { "écran" }),
        new("9. Période, un produit, mots-clés (toutes versions)",
            Produit: "Trader en Herbe",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30),
            MotsCles: new[] { "écran" }),
        new("10. Période, un produit, mots-clés (une version)",
            Produit: "Trader en Herbe", Version: "1.2",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30),
            MotsCles: new[] { "écran" }),
        new("11. Résolus (tous les produits)",
            Statut: "Résolu"),
        new("12. Résolus, un produit (toutes versions)",
            Statut: "Résolu", Produit: "Trader en Herbe"),
        new("13. Résolus, un produit (une version)",
            Statut: "Résolu", Produit: "Trader en Herbe", Version: "1.2"),
        new("14. Résolus sur une période, un produit (toutes versions)",
            Statut: "Résolu", Produit: "Trader en Herbe",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30)),
        new("15. Résolus sur une période, un produit (une version)",
            Statut: "Résolu", Produit: "Trader en Herbe", Version: "1.2",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30)),
        new("16. Résolus, mots-clés (tous les produits)",
            Statut: "Résolu", MotsCles: new[] { "écran" }),
        new("17. Résolus, un produit, mots-clés (toutes versions)",
            Statut: "Résolu", Produit: "Trader en Herbe", MotsCles: new[] { "écran" }),
        new("18. Résolus, un produit, mots-clés (une version)",
            Statut: "Résolu", Produit: "Trader en Herbe", Version: "1.2", MotsCles: new[] { "écran" }),
        new("19. Résolus sur une période, un produit, mots-clés (toutes versions)",
            Statut: "Résolu", Produit: "Trader en Herbe",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30),
            MotsCles: new[] { "écran" }),
        new("20. Résolus sur une période, un produit, mots-clés (une version)",
            Statut: "Résolu", Produit: "Trader en Herbe", Version: "1.2",
            DateDebut: new DateOnly(2026, 1, 1), DateFin: new DateOnly(2026, 6, 30),
            MotsCles: new[] { "écran" }),
    };
}
