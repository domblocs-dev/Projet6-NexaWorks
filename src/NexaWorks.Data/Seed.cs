namespace NexaWorks.Data;

public static class Seed
{
    public static void Initialiser(NexaWorksContext context)
    {
        // Garde-fou : si la base contient déjà des produits, on ne refait rien
        if (context.Produit.Any())
            return;

        // 1. Les OS, rangés dans un dictionnaire par leur nom
        var osParNom = new Dictionary<string, OS>();
        foreach (var nom in DonneesInitiales.SystemesExploitation)
        {
            var os = new OS { Nom = nom };
            osParNom[nom] = os;
            context.OS.Add(os);
        }

        // 2. Les statuts, rangés par nom
        var statutParNom = new Dictionary<string, Statut>();
        foreach (var nom in DonneesInitiales.Statuts)
        {
            var statut = new Statut { Nom = nom };
            statutParNom[nom] = statut;
            context.Statut.Add(statut);
        }

        // 3. Les produits, rangés par nom
        var produitParNom = new Dictionary<string, Produit>();
        foreach (var nom in DonneesInitiales.Produits)
        {
            var produit = new Produit { Nom = nom };
            produitParNom[nom] = produit;
            context.Produit.Add(produit);
        }

        // 4. Les versions, reliées à leur produit (via le dictionnaire), rangées par (produit, numéro)
        var versionParCle = new Dictionary<(string, string), Version>();
        foreach (var v in DonneesInitiales.Versions)
        {
            var version = new Version
            {
                Numero = v.Numero,
                Produit = produitParNom[v.Produit]
            };
            versionParCle[(v.Produit, v.Numero)] = version;
            context.Version.Add(version);
        }

        // 5. Les compatibilités, reliées à une version et un OS, rangées par (produit, numéro, OS)
        var compatParCle = new Dictionary<(string, string, string), Compatibilite>();
        foreach (var c in DonneesInitiales.Compatibilites)
        {
            var compat = new Compatibilite
            {
                Version = versionParCle[(c.Produit, c.Numero)],
                OS = osParNom[c.OS]
            };
            compatParCle[(c.Produit, c.Numero, c.OS)] = compat;
            context.Compatibilite.Add(compat);
        }

        // 6. Les tickets, reliés à leur statut et à la bonne compatibilité
        foreach (var t in DonneesInitiales.Tickets)
        {
            var ticket = new Ticket
            {
                DateCreation = t.DateCreation,
                DateResolution = t.DateResolution,
                Probleme = t.Probleme,
                Resolution = t.Resolution,
                Statut = statutParNom[t.Statut],
                Compatibilite = compatParCle[(t.Produit, t.Numero, t.OS)]
            };
            context.Ticket.Add(ticket);
        }

        // 7. Un seul enregistrement : EF insère dans le bon ordre et attribue les Id
        context.SaveChanges();
    }
}