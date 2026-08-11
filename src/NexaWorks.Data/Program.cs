using NexaWorks.Data;

using var context = new NexaWorksContext();
Seed.Initialiser(context);

Console.WriteLine("=== Démonstration des 20 requêtes (une seule méthode paramétrée) ===\n");

foreach (var cas in DemoRequetes.LesVingtCas)
{
    var resultats = Requetes.ObtenirTickets(context,
        cas.Statut, cas.Produit, cas.Version, cas.DateDebut, cas.DateFin, cas.MotsCles);

    Console.WriteLine($"{cas.Titre} : {resultats.Count} ticket(s)");

    foreach (var t in resultats)
        Console.WriteLine($"   #{t.Id,-2} {t.Compatibilite.Version.Produit.Nom} " +
                          $"{t.Compatibilite.Version.Numero} / {t.Compatibilite.OS.Nom} [{t.Statut.Nom}]");

    Console.WriteLine();
}