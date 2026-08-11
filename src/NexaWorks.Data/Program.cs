using NexaWorks.Data;

using var context = new NexaWorksContext();
Seed.Initialiser(context);


Afficher("Problèmes EN COURS (tous produits)",
    Requetes.ObtenirTickets(context, statut: "En cours"));

Afficher("Problèmes RÉSOLUS de Trader en Herbe, version 1.2",
    Requetes.ObtenirTickets(context, statut: "Résolu", produit: "Trader en Herbe", version: "1.2"));

Afficher("Problèmes contenant le mot-clé « batterie »",
    Requetes.ObtenirTickets(context, motsCles: new[] { "batterie" }));

Afficher("Problèmes rencontrés en juin 2026 (tous produits)",
    Requetes.ObtenirTickets(context,
        dateDebut: new DateOnly(2026, 6, 1),
        dateFin: new DateOnly(2026, 6, 30)));

// Fonction locale d'affichage d'une liste de tickets
void Afficher(string titre, List<Ticket> tickets)
{
    Console.WriteLine();
    Console.WriteLine($"=== {titre} : {tickets.Count} résultat(s) ===");
    foreach (var t in tickets)
        Console.WriteLine($"  #{t.Id,-2} {t.Compatibilite.Version.Produit.Nom} " +
                          $"{t.Compatibilite.Version.Numero} / {t.Compatibilite.OS.Nom} [{t.Statut.Nom}]");
}




