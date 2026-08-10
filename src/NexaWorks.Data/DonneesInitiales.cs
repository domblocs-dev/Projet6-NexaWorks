// Donnees de remplissage de la base NexaWorks.
// Fichier de DONNEES (transcription des documents du projet).
// La logique de remplissage est ecrite a part.

namespace NexaWorks.Data;

public record VersionSeed(string Produit, string Numero);
public record CompatibiliteSeed(string Produit, string Numero, string OS);
public record TicketSeed(
    string Produit, string Numero, string OS,
    DateOnly DateCreation, DateOnly? DateResolution,
    string Statut, string Probleme, string? Resolution);

public static class DonneesInitiales
{
    public static readonly string[] SystemesExploitation =
    {
        "Windows", "MacOS", "Linux", "Android", "iOS", "Windows Mobile"
    };

    public static readonly string[] Statuts =
    {
        "En cours", "Résolu"
    };

    public static readonly string[] Produits =
    {
        "Trader en Herbe",
        "Maître des Investissements",
        "Planificateur d'Entraînement",
        "Planificateur d'Anxiété Sociale"
    };

    public static readonly VersionSeed[] Versions =
    {
        new("Trader en Herbe", "1.0"),
        new("Trader en Herbe", "1.1"),
        new("Trader en Herbe", "1.2"),
        new("Trader en Herbe", "1.3"),
        new("Maître des Investissements", "1.0"),
        new("Maître des Investissements", "2.0"),
        new("Maître des Investissements", "2.1"),
        new("Planificateur d'Entraînement", "1.0"),
        new("Planificateur d'Entraînement", "1.1"),
        new("Planificateur d'Entraînement", "2.0"),
        new("Planificateur d'Anxiété Sociale", "1.0"),
        new("Planificateur d'Anxiété Sociale", "1.1"),
    };

    public static readonly CompatibiliteSeed[] Compatibilites =
    {
        new("Trader en Herbe", "1.0", "Linux"),
        new("Trader en Herbe", "1.0", "Windows"),
        new("Trader en Herbe", "1.1", "Linux"),
        new("Trader en Herbe", "1.1", "MacOS"),
        new("Trader en Herbe", "1.1", "Windows"),
        new("Trader en Herbe", "1.2", "Linux"),
        new("Trader en Herbe", "1.2", "MacOS"),
        new("Trader en Herbe", "1.2", "Windows"),
        new("Trader en Herbe", "1.2", "Android"),
        new("Trader en Herbe", "1.2", "iOS"),
        new("Trader en Herbe", "1.2", "Windows Mobile"),
        new("Trader en Herbe", "1.3", "MacOS"),
        new("Trader en Herbe", "1.3", "Windows"),
        new("Trader en Herbe", "1.3", "Android"),
        new("Trader en Herbe", "1.3", "iOS"),
        new("Maître des Investissements", "1.0", "MacOS"),
        new("Maître des Investissements", "1.0", "iOS"),
        new("Maître des Investissements", "2.0", "MacOS"),
        new("Maître des Investissements", "2.0", "Android"),
        new("Maître des Investissements", "2.0", "iOS"),
        new("Maître des Investissements", "2.1", "MacOS"),
        new("Maître des Investissements", "2.1", "Windows"),
        new("Maître des Investissements", "2.1", "Android"),
        new("Maître des Investissements", "2.1", "iOS"),
        new("Planificateur d'Entraînement", "1.0", "Linux"),
        new("Planificateur d'Entraînement", "1.0", "MacOS"),
        new("Planificateur d'Entraînement", "1.1", "Linux"),
        new("Planificateur d'Entraînement", "1.1", "MacOS"),
        new("Planificateur d'Entraînement", "1.1", "Windows"),
        new("Planificateur d'Entraînement", "1.1", "Android"),
        new("Planificateur d'Entraînement", "1.1", "iOS"),
        new("Planificateur d'Entraînement", "1.1", "Windows Mobile"),
        new("Planificateur d'Entraînement", "2.0", "MacOS"),
        new("Planificateur d'Entraînement", "2.0", "Windows"),
        new("Planificateur d'Entraînement", "2.0", "Android"),
        new("Planificateur d'Entraînement", "2.0", "iOS"),
        new("Planificateur d'Anxiété Sociale", "1.0", "MacOS"),
        new("Planificateur d'Anxiété Sociale", "1.0", "Windows"),
        new("Planificateur d'Anxiété Sociale", "1.0", "Android"),
        new("Planificateur d'Anxiété Sociale", "1.0", "iOS"),
        new("Planificateur d'Anxiété Sociale", "1.1", "MacOS"),
        new("Planificateur d'Anxiété Sociale", "1.1", "Windows"),
        new("Planificateur d'Anxiété Sociale", "1.1", "Android"),
        new("Planificateur d'Anxiété Sociale", "1.1", "iOS"),
    };

    public static readonly TicketSeed[] Tickets =
    {
        new("Trader en Herbe", "1.0", "Windows",
            new DateOnly(2026, 1, 12), new DateOnly(2026, 1, 27),
            "Résolu", "Sur les postes dont la langue système utilise la virgule comme séparateur décimal (français, allemand), tous les cours de bourse s'affichent à « 0,00 ». L'utilisateur ne peut donc pas suivre ses valeurs.", "Le parsing des prix utilisait la culture système au lieu de InvariantCulture. Le service de cotation renvoie des nombres au format anglo-saxon (point décimal). Correction : forcer CultureInfo.InvariantCulture lors de la désérialisation des prix."),
        new("Trader en Herbe", "1.0", "Linux",
            new DateOnly(2026, 2, 3), null,
            "En cours", "Le graphique de cours ne se rafraîchit pas en temps réel. L'utilisateur doit changer d'onglet puis revenir pour voir la valeur mise à jour. Le problème n'apparaît que sous certains gestionnaires de fenêtres Linux.", null),
        new("Trader en Herbe", "1.1", "MacOS",
            new DateOnly(2026, 3, 18), new DateOnly(2026, 4, 5),
            "Résolu", "Les alertes de seuil de prix (« notifier quand AAPL > 180 $ ») sont envoyées deux fois, à quelques secondes d'intervalle.", "Deux abonnements au flux de prix étaient créés au retour de veille du Mac. Ajout d'une déduplication par identifiant d'alerte et fermeture propre de l'ancien abonnement avant réabonnement."),
        new("Trader en Herbe", "1.2", "iOS",
            new DateOnly(2026, 5, 22), new DateOnly(2026, 6, 9),
            "Résolu", "Sur iPhone SE (petit écran), le clavier numérique masque le champ « quantité » lors de la saisie d'un ordre. L'utilisateur ne voit pas ce qu'il tape.", "La vue de saisie ne remontait pas au-dessus du clavier. Ajout d'un ajustement de la marge basse égale à la hauteur du clavier (keyboardWillShow) et défilement automatique vers le champ actif."),
        new("Trader en Herbe", "1.2", "Windows Mobile",
            new DateOnly(2026, 6, 14), null,
            "En cours", "L'application se ferme brutalement lorsque l'utilisateur ajoute une action à sa liste de suivi et que cette liste contient déjà plus de 50 valeurs. En dessous de 50, aucun souci.", null),
        new("Trader en Herbe", "1.2", "Windows Mobile",
            new DateOnly(2026, 7, 1), new DateOnly(2026, 7, 20),
            "Résolu", "Après avoir vendu une action, le solde du portefeuille ne se met pas à jour à l'écran. Il faut fermer et rouvrir l'application pour voir le bon montant.", "L'événement de vente mettait à jour la base locale mais pas le modèle de vue affiché. Ajout de la notification de changement de propriété (INotifyPropertyChanged) sur le solde du portefeuille."),
        new("Trader en Herbe", "1.3", "Android",
            new DateOnly(2026, 6, 8), null,
            "En cours", "Le widget d'écran d'accueil Android affiche les cours de la veille au lieu des cours du jour. L'application principale, elle, affiche bien les cours à jour.", null),
        new("Trader en Herbe", "1.3", "iOS",
            new DateOnly(2026, 6, 30), new DateOnly(2026, 7, 14),
            "Résolu", "Depuis la mise à jour vers iOS 17, la connexion par Face ID échoue systématiquement et renvoie à l'écran de mot de passe.", "L'API LocalAuthentication renvoyait une nouvelle erreur non gérée sous iOS 17. Mise à jour du SDK et gestion du cas biometryNotAvailable avec repli propre sur le code PIN."),
        new("Maître des Investissements", "1.0", "MacOS",
            new DateOnly(2026, 4, 11), new DateOnly(2026, 5, 2),
            "Résolu", "Le rendement annualisé affiché ignore les dividendes versés. Un portefeuille orienté dividendes paraît donc bien moins performant qu'il ne l'est réellement.", "La formule de rendement ne sommait que les plus-values. Ajout des dividendes encaissés au numérateur du calcul de performance (rendement total)."),
        new("Maître des Investissements", "1.0", "iOS",
            new DateOnly(2026, 4, 19), null,
            "En cours", "L'export PDF du rapport de portefeuille tronque les dernières colonnes du tableau (valorisation et performance) en orientation portrait.", null),
        new("Maître des Investissements", "2.0", "Android",
            new DateOnly(2026, 5, 7), new DateOnly(2026, 5, 25),
            "Résolu", "La synchronisation multi-appareils crée des doublons de transactions : une opération saisie sur téléphone apparaît deux fois après synchronisation avec la tablette.", "L'identifiant de transaction était généré côté client, sans garantie d'unicité entre appareils. Passage à un identifiant serveur (GUID) et fusion idempotente lors de la synchronisation."),
        new("Maître des Investissements", "2.0", "iOS",
            new DateOnly(2026, 7, 2), null,
            "En cours", "La devise d'affichage reste en USD alors que l'utilisateur a sélectionné EUR dans les réglages. Le changement n'est pris en compte qu'après réinstallation.", null),
        new("Maître des Investissements", "2.1", "Windows",
            new DateOnly(2026, 1, 15), new DateOnly(2026, 1, 29),
            "Résolu", "L'import d'un relevé au format CSV échoue silencieusement lorsque le fichier utilise le point-virgule comme séparateur (export Excel français). Aucune transaction n'est importée.", "Le lecteur CSV ne gérait que la virgule. Détection automatique du séparateur (virgule / point-virgule / tabulation) et message d'erreur explicite si le format reste invalide."),
        new("Maître des Investissements", "2.1", "MacOS",
            new DateOnly(2026, 2, 3), null,
            "En cours", "Sur écran Retina, les étiquettes du graphique de répartition d'actifs (camembert) se chevauchent et deviennent illisibles quand le portefeuille contient plus de 8 lignes.", null),
        new("Planificateur d'Entraînement", "1.0", "Linux",
            new DateOnly(2026, 2, 24), new DateOnly(2026, 3, 12),
            "Résolu", "Les séances programmées pour le lendemain disparaissent du planning passé minuit. L'utilisateur se réveille sans sa séance du jour.", "Les dates de séance étaient stockées en heure locale mais comparées en UTC, décalant le changement de jour. Normalisation de toutes les dates en UTC au stockage et conversion à l'affichage."),
        new("Planificateur d'Entraînement", "1.0", "Linux",
            new DateOnly(2026, 3, 6), null,
            "En cours", "Impossible de supprimer un exercice personnalisé de la bibliothèque. Le bouton « Supprimer » reste sans effet et l'exercice réapparaît au redémarrage.", null),
        new("Planificateur d'Entraînement", "1.1", "Android",
            new DateOnly(2026, 6, 18), new DateOnly(2026, 7, 4),
            "Résolu", "Le minuteur de temps de repos continue de tourner en arrière-plan après la fermeture de l'application et vide la batterie en quelques heures.", "Un service de premier plan restait actif sans condition d'arrêt. Ajout de l'annulation du minuteur à la fin de la séance et libération du WakeLock."),
        new("Planificateur d'Entraînement", "1.1", "Windows Mobile",
            new DateOnly(2026, 7, 21), null,
            "En cours", "Les rappels de séance programmés (« Séance jambes à 18 h ») ne s'affichent jamais. Aucune notification n'apparaît, même application ouverte.", null),
        new("Planificateur d'Entraînement", "1.1", "iOS",
            new DateOnly(2026, 5, 9), new DateOnly(2026, 5, 23),
            "Résolu", "La synchronisation avec Apple Santé enregistre bien les séances mais pas les calories brûlées associées.", "Le type de données activeEnergyBurned n'était pas inclus dans la demande d'autorisation HealthKit. Ajout du type manquant et réémission de la demande de permission."),
        new("Planificateur d'Entraînement", "2.0", "Windows",
            new DateOnly(2026, 3, 4), new DateOnly(2026, 3, 18),
            "Résolu", "Le glisser-déposer pour réordonner les exercices d'une séance ne fonctionne pas à la souris sur poste de bureau ; il ne marche qu'au tactile.", "Seuls les événements tactiles étaient écoutés. Ajout de la prise en charge des événements souris (pointer events) pour couvrir souris et écran tactile."),
        new("Planificateur d'Entraînement", "2.0", "Android",
            new DateOnly(2026, 4, 2), null,
            "En cours", "L'application plante lors de l'ajout d'une photo de progression prise avec un appareil haute résolution (au-delà de 12 mégapixels). Les photos plus petites passent sans souci.", null),
        new("Planificateur d'Anxiété Sociale", "1.0", "Windows",
            new DateOnly(2026, 3, 27), new DateOnly(2026, 4, 11),
            "Résolu", "Les entrées du journal d'humeur ne sont pas sauvegardées lorsque le texte dépasse environ 500 caractères. L'utilisateur perd son écrit sans message d'erreur.", "La colonne de base de données était limitée à VARCHAR(500) et l'insertion échouait en silence. Passage en NVARCHAR(MAX) et remontée de l'erreur à l'utilisateur en cas d'échec d'enregistrement."),
        new("Planificateur d'Anxiété Sociale", "1.0", "Android",
            new DateOnly(2026, 4, 5), null,
            "En cours", "Lors des exercices de respiration guidée, l'animation visuelle (cercle qui se dilate) se désynchronise progressivement de la piste audio, jusqu'à un décalage de plusieurs secondes.", null),
        new("Planificateur d'Anxiété Sociale", "1.1", "iOS",
            new DateOnly(2026, 5, 16), new DateOnly(2026, 5, 30),
            "Résolu", "Les rappels d'exercice d'exposition arrivent en pleine nuit (vers 3 h du matin) au lieu de l'heure choisie par l'utilisateur.", "L'heure de rappel était planifiée en UTC sans conversion vers le fuseau de l'utilisateur. Correction du calcul de la prochaine occurrence dans le fuseau local de l'appareil."),
        new("Planificateur d'Anxiété Sociale", "1.1", "MacOS",
            new DateOnly(2026, 6, 3), null,
            "En cours", "Le graphique d'évolution du niveau d'anxiété reste vide tant que l'utilisateur n'a pas saisi au moins 3 entrées, sans aucun message expliquant pourquoi. Les nouveaux utilisateurs pensent que la fonction est cassée.", null),
    };
}
