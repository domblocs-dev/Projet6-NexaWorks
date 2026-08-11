# NexaWorks - Support de soutenance (texte des diapositives)


## Diapositive 1

- NexaWorks
- Base de données de suivi des problèmes logiciels
- Projet 6 — Conception et création d'une base de données pour une application .NET
- > présenté par Dominique

**Notes d'orateur :** Bonjour, je vais vous présenter le projet NexaWorks : la conception et la création d'une base de données pour suivre les problèmes des logiciels de l'entreprise. Je commencerai par vous montrer la solution qui fonctionne, puis je détaillerai comment je l'ai construite.

## Diapositive 2

- // le projet
- Le contexte et le besoin
- NexaWorks édite plusieurs logiciels.
- Des produits  chacun en plusieurs versions (1.0, 1.1, 2.0...).
- Des systèmes d'exploitation  Windows, MacOS, Linux, Android, iOS, Windows Mobile.
- Des problèmes  des tickets à suivre par version et par OS.
- Aucun outil existant  d'où la mission : concevoir et créer la base.
- // ma mission
- Concevoir le modèle de données, créer la base, la remplir de données d'exemple, puis fournir les requêtes pour l'interroger.
- L'équipe branchera ensuite une API et un site web sur cette base.

**Notes d'orateur :** NexaWorks édite des logiciels, chacun en plusieurs versions, compatibles avec différents systèmes d'exploitation. L'entreprise n'a aucun outil pour tracer les problèmes rencontrés. Ma mission : concevoir et créer cette base de données, la remplir, et fournir les requêtes pour l'interroger.

## Diapositive 3

- // démonstration
- La solution en fonctionnement
- Avant les explications : la base est créée, remplie et interrogeable.
- 25
- tickets enregistrés
- 20
- requêtes couvertes
- 6
- tables reliées
- > dotnet run
- En cours (tous les produits)          : 11 tickets
- Résolus, Trader en Herbe, version 1.2 :  2 tickets
- Contenant le mot-clé "batterie"          :  1 ticket
- Rencontrés en juin 2026               :  5 tickets
- ...  les 20 demandes répondent, résultats justes.

**Notes d'orateur :** Point clé : je montre d'abord que ça marche. Je lance le programme en direct : il remplit la base puis exécute les 20 requêtes demandées. On voit tout de suite des résultats cohérents. Une fois rassurés que la solution fonctionne, je vais expliquer comment je l'ai construite.

## Diapositive 4

- // conception
- Le modèle entité-association
- Six tables : Produit, Version, OS, Compatibilite, Statut et Ticket, reliées par leurs clés.

**Notes d'orateur :** Voici le modèle : six tables. Produit, Version qui appartient à un produit, OS, la table d'association Compatibilite qui relie versions et OS, Statut, et Ticket au centre. Un ticket concerne une compatibilité, donc une version sur un OS, et a un statut.

## Diapositive 5

- // conception
- Les choix de conception
- 3e forme normale  le produit d'un ticket n'est pas stocké, il se déduit.
- Table d'association Compatibilite  pour le plusieurs-à-plusieurs version / OS.
- Contrainte d'unicité  interdit deux fois le même couple version + OS.
- Une seule clé étrangère sur le ticket  vers une compatibilité déjà validée.
- Numéro de version en texte  « 1.2 » est une étiquette, pas un nombre.
- // à retenir
- La 3e forme normale évite de stocker deux fois la même information : chaque donnée vit à un seul endroit.

Les contraintes (clé étrangère, unicité) font que la base refuse elle-même les incohérences, sans compter sur le code.

**Notes d'orateur :** Mes choix : la 3e forme normale, le produit se déduit du ticket via sa version, on ne le stocke pas. Une table d'association pour le plusieurs-à-plusieurs entre versions et OS, avec une contrainte d'unicité. Une seule clé étrangère sur le ticket, vers une compatibilité déjà validée, ce qui garantit un couple compatible. Et le numéro de version en texte car ce n'est pas un nombre.

## Diapositive 6

- // données
- Les 25 tickets d'exemple
- Des problèmes réalistes, couvrant largement produits, versions et OS.
- 4
- produits
- 12
- versions
- 6
- systèmes d'OS
- 25
- tickets
- 14 tickets résolus
- avec leur date et leur solution.
- 11 tickets en cours
- sans date ni solution de résolution.

**Notes d'orateur :** J'ai créé 25 tickets réalistes, en respectant la matrice de compatibilité : l'OS d'un ticket est toujours compatible avec sa version. Ils couvrent les 4 produits, les 12 versions, les 6 OS, au moins 3 de chaque, avec un mélange de 14 résolus et 11 en cours, comme demandé.

## Diapositive 7

- // données
- Deux tickets expliqués
- Ticket 1 — Trader en Herbe 1.0 / Windows
- Problème : sur un PC en langue française, tous les cours de bourse s'affichent à 0,00.

Solution : le programme lisait les prix au format local (virgule) alors que le service renvoie un point décimal. On force un format fixe (InvariantCulture), et les prix se lisent correctement.
- Ticket 6 — Trader en Herbe 1.2 / Windows Mobile
- Problème : après une vente, le solde du portefeuille ne se met pas à jour à l'écran.

Solution : la donnée changeait en mémoire mais l'écran n'était pas prévenu. On ajoute la notification de changement (INotifyPropertyChanged) et l'affichage se met à jour tout seul.

**Notes d'orateur :** Le premier ticket : les cours à 0,00 sur un PC français, à cause du format des nombres, virgule contre point. En forçant un format fixe, le programme lit correctement le point décimal : la solution répond directement au problème. Le second : le solde qui ne se rafraîchit pas ; on prévient l'affichage du changement, et il se met à jour automatiquement.

## Diapositive 8

- // création
- La création : Code-First (Entity Framework Core)
- Pourquoi Code-First  l'approche courante en entreprise, valorisée en entretien.
- Le principe  j'écris des classes C#, EF Core en génère la base.
- .NET 10 et EF Core 10  les versions les plus récentes.
- En complément  le même schéma aussi en SQL pur (SSMS).
- public class Ticket
- {
- public int Id { get; set; }
- public DateOnly DateCreation
- public string Probleme
- public int CompatibiliteId
- }
- > dotnet ef migrations add Init
- > dotnet ef database update

**Notes d'orateur :** J'ai choisi le Code-First : on écrit des classes C# pour chaque table, puis EF Core génère la base à partir d'une migration. C'est l'approche la plus courante en entreprise. En bonus, j'ai aussi écrit le schéma entièrement en SQL pur.

## Diapositive 9

- // données
- Le remplissage de la base
- Un code de remplissage crée les objets, les relie, et enregistre en une fois.
- 4
- produits
- 6
- OS
- 2
- statuts
- 12
- versions
- 44
- compatibilités
- 25
- tickets

**Notes d'orateur :** Pour remplir la base, un code crée les objets et les relie par leurs propriétés de navigation, puis un seul enregistrement envoie tout d'un coup dans une transaction. Au total : 4 produits, 6 OS, 2 statuts, 12 versions, 44 compatibilités et 25 tickets.

## Diapositive 10

- // interrogation
- L'optimisation des requêtes
- 20 demandes  =>  1 seule requête paramétrée
- Les 20 requêtes ne diffèrent que par cinq critères, tous optionnels :
- 1
- Statut
- 2
- Produit
- 3
- Version
- 4
- Période
- 5
- Mots-clés
- Un critère laissé vide est ignoré : une seule requête répond à toute la liste.

**Notes d'orateur :** Le cœur de l'optimisation : les 20 requêtes ne varient que par cinq critères : statut, produit, version, période, mots-clés. J'en ai fait une seule requête paramétrée, où chaque critère est optionnel. Un paramètre vide est ignoré. Cette unique requête répond aux 20 demandes, bien en dessous de la limite de 20.

## Diapositive 11

- // interrogation
- Deux implémentations, mêmes résultats
- LINQ
- var q = context.Ticket
- .Where(t => statut == null
- || t.Statut.Nom == statut)
- .Where(t => t.Probleme
- .Contains(mot))
- .ToList();
- Procédure stockée
- CREATE PROCEDURE ObtenirTickets
- @Statut NVARCHAR(50) = NULL, ...
- ...
- WHERE (@Statut IS NULL
- OR s.Nom = @Statut)
- AND (@MotCle IS NULL OR ...)
- Mêmes résultats  les deux approches renvoient exactement 11, 2, 1, 5 ... pour les 20 demandes.

**Notes d'orateur :** J'ai fourni la requête de deux façons : en LINQ dans le projet .NET, et en procédure stockée T-SQL dans la base. La version LINQ construit les filtres à la volée et se traduit en une seule requête SQL ; la procédure utilise le motif paramètre-vide-ou-condition. Les deux donnent exactement les mêmes résultats.

## Diapositive 12

- // livrables
- Documentation et sauvegarde
- Documentation des requêtes
- Un fichier Excel documente les 20 demandes : but, paramètres, résultat escompté et résultat obtenu (les vrais comptes sur la base).
- Sauvegarde complète (dump)
- Une copie intégrale de la base au format .bak, restaurable sur n'importe quel serveur SQL Server, déposée sur GitHub avec tout le projet.

**Notes d'orateur :** Côté documentation, un fichier Excel reprend les 20 demandes avec pour chacune le but, les paramètres, le résultat attendu et le résultat obtenu. Enfin, une sauvegarde complète de la base au format .bak, restaurable ailleurs, est déposée sur GitHub avec l'ensemble du projet.

## Diapositive 13

- // bilan
- Ce que ce projet m'a apporté
- Modélisation  concevoir un schéma normalisé (3e forme normale) à partir d'un besoin.
- Code-First avec EF Core  des classes C# à la vraie base de données.
- Interrogation  LINQ et SQL, et l'art d'optimiser des requêtes.
- Rigueur des livrables  documentation, sauvegarde, et un dépôt GitHub clair.
- > merci de votre attention  —  vos questions

**Notes d'orateur :** En bilan, ce projet m'a fait progresser sur la modélisation et la normalisation, sur la création d'une base en Code-First avec EF Core, sur l'interrogation en LINQ et en SQL avec l'optimisation des requêtes, et sur la rigueur des livrables. Je vous remercie et je réponds à vos questions.
