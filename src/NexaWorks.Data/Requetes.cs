using Microsoft.EntityFrameworkCore;

namespace NexaWorks.Data;

public static class Requetes
{
    public static List<Ticket> ObtenirTickets(
        NexaWorksContext context,
        string? statut = null,
        string? produit = null,
        string? version = null,
        DateOnly? dateDebut = null,
        DateOnly? dateFin = null,
        string[]? motsCles = null)
    {
        // On part de tous les tickets, en chargeant les données liées pour l'affichage
        IQueryable<Ticket> requete = context.Ticket
            .Include(t => t.Statut)
            .Include(t => t.Compatibilite).ThenInclude(c => c.OS)
            .Include(t => t.Compatibilite).ThenInclude(c => c.Version).ThenInclude(v => v.Produit);

        // Filtre statut
        if (statut != null)
            requete = requete.Where(t => t.Statut.Nom == statut);

        // Filtre produit
        if (produit != null)
            requete = requete.Where(t => t.Compatibilite.Version.Produit.Nom == produit);

        // Filtre version
        if (version != null)
            requete = requete.Where(t => t.Compatibilite.Version.Numero == version);

        // Filtre période (sur la date de création)
        if (dateDebut != null)
            requete = requete.Where(t => t.DateCreation >= dateDebut);
        if (dateFin != null)
            requete = requete.Where(t => t.DateCreation <= dateFin);

        // Filtre mots-clés : le problème doit contenir TOUS les mots
        if (motsCles != null)
            foreach (var mot in motsCles)
                requete = requete.Where(t => t.Probleme.Contains(mot));

        // On déclenche l'exécution et on renvoie le résultat
        return requete.ToList();
    }
}