-- Bonus : création complète de la base NexaWorks_SQL en SQL pur (voie SSMS).
-- Script rejouable : il vide et recrée les tables, puis réinsère toutes les données.

IF DB_ID('NexaWorks_SQL') IS NULL
    CREATE DATABASE NexaWorks_SQL;
GO
USE NexaWorks_SQL;
GO

IF OBJECT_ID('dbo.Ticket','U')        IS NOT NULL DROP TABLE dbo.Ticket;
IF OBJECT_ID('dbo.Compatibilite','U') IS NOT NULL DROP TABLE dbo.Compatibilite;
IF OBJECT_ID('dbo.Version','U')       IS NOT NULL DROP TABLE dbo.[Version];
IF OBJECT_ID('dbo.Statut','U')        IS NOT NULL DROP TABLE dbo.Statut;
IF OBJECT_ID('dbo.OS','U')            IS NOT NULL DROP TABLE dbo.OS;
IF OBJECT_ID('dbo.Produit','U')       IS NOT NULL DROP TABLE dbo.Produit;
GO

CREATE TABLE Produit (
    Id  INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(100) NOT NULL
);

CREATE TABLE OS (
    Id  INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(100) NOT NULL
);

CREATE TABLE Statut (
    Id  INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(50) NOT NULL
);

CREATE TABLE [Version] (
    Id        INT IDENTITY(1,1) PRIMARY KEY,
    Numero    NVARCHAR(50) NOT NULL,
    ProduitId INT NOT NULL,
    CONSTRAINT FK_Version_Produit FOREIGN KEY (ProduitId) REFERENCES Produit(Id)
);

CREATE TABLE Compatibilite (
    Id        INT IDENTITY(1,1) PRIMARY KEY,
    VersionId INT NOT NULL,
    OSId      INT NOT NULL,
    CONSTRAINT FK_Compatibilite_Version FOREIGN KEY (VersionId) REFERENCES [Version](Id),
    CONSTRAINT FK_Compatibilite_OS      FOREIGN KEY (OSId)      REFERENCES OS(Id),
    CONSTRAINT UQ_Compatibilite_Version_OS UNIQUE (VersionId, OSId)
);

CREATE TABLE Ticket (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    DateCreation    DATE NOT NULL,
    DateResolution  DATE NULL,
    Probleme        NVARCHAR(MAX) NOT NULL,
    Resolution      NVARCHAR(MAX) NULL,
    StatutId        INT NOT NULL,
    CompatibiliteId INT NOT NULL,
    CONSTRAINT FK_Ticket_Statut        FOREIGN KEY (StatutId)        REFERENCES Statut(Id),
    CONSTRAINT FK_Ticket_Compatibilite FOREIGN KEY (CompatibiliteId) REFERENCES Compatibilite(Id)
);
GO

-- Données de référence
INSERT INTO Produit (Nom) VALUES
    (N'Trader en Herbe'),
    (N'Maître des Investissements'),
    (N'Planificateur d''Entraînement'),
    (N'Planificateur d''Anxiété Sociale');
INSERT INTO OS (Nom) VALUES
    (N'Windows'), (N'MacOS'), (N'Linux'), (N'Android'), (N'iOS'), (N'Windows Mobile');
INSERT INTO Statut (Nom) VALUES
    (N'En cours'), (N'Résolu');

-- Versions (Numero, ProduitId)
INSERT INTO [Version] (Numero, ProduitId) VALUES
    (N'1.0', 1),
    (N'1.1', 1),
    (N'1.2', 1),
    (N'1.3', 1),
    (N'1.0', 2),
    (N'2.0', 2),
    (N'2.1', 2),
    (N'1.0', 3),
    (N'1.1', 3),
    (N'2.0', 3),
    (N'1.0', 4),
    (N'1.1', 4);

-- Compatibilités (VersionId, OSId)
INSERT INTO Compatibilite (VersionId, OSId) VALUES
    (1, 3),
    (1, 1),
    (2, 3),
    (2, 2),
    (2, 1),
    (3, 3),
    (3, 2),
    (3, 1),
    (3, 4),
    (3, 5),
    (3, 6),
    (4, 2),
    (4, 1),
    (4, 4),
    (4, 5),
    (5, 2),
    (5, 5),
    (6, 2),
    (6, 4),
    (6, 5),
    (7, 2),
    (7, 1),
    (7, 4),
    (7, 5),
    (8, 3),
    (8, 2),
    (9, 3),
    (9, 2),
    (9, 1),
    (9, 4),
    (9, 5),
    (9, 6),
    (10, 2),
    (10, 1),
    (10, 4),
    (10, 5),
    (11, 2),
    (11, 1),
    (11, 4),
    (11, 5),
    (12, 2),
    (12, 1),
    (12, 4),
    (12, 5);

-- Tickets
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-01-12', '2026-01-27', N'Sur les postes dont la langue système utilise la virgule comme séparateur décimal (français, allemand), tous les cours de bourse s''affichent à « 0,00 ». L''utilisateur ne peut donc pas suivre ses valeurs.', N'Le parsing des prix utilisait la culture système au lieu de InvariantCulture. Le service de cotation renvoie des nombres au format anglo-saxon (point décimal). Correction : forcer CultureInfo.InvariantCulture lors de la désérialisation des prix.', 2, 2);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-02-03', NULL, N'Le graphique de cours ne se rafraîchit pas en temps réel. L''utilisateur doit changer d''onglet puis revenir pour voir la valeur mise à jour. Le problème n''apparaît que sous certains gestionnaires de fenêtres Linux.', NULL, 1, 1);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-03-18', '2026-04-05', N'Les alertes de seuil de prix (« notifier quand AAPL > 180 $ ») sont envoyées deux fois, à quelques secondes d''intervalle.', N'Deux abonnements au flux de prix étaient créés au retour de veille du Mac. Ajout d''une déduplication par identifiant d''alerte et fermeture propre de l''ancien abonnement avant réabonnement.', 2, 4);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-05-22', '2026-06-09', N'Sur iPhone SE (petit écran), le clavier numérique masque le champ « quantité » lors de la saisie d''un ordre. L''utilisateur ne voit pas ce qu''il tape.', N'La vue de saisie ne remontait pas au-dessus du clavier. Ajout d''un ajustement de la marge basse égale à la hauteur du clavier (keyboardWillShow) et défilement automatique vers le champ actif.', 2, 10);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-06-14', NULL, N'L''application se ferme brutalement lorsque l''utilisateur ajoute une action à sa liste de suivi et que cette liste contient déjà plus de 50 valeurs. En dessous de 50, aucun souci.', NULL, 1, 11);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-07-01', '2026-07-20', N'Après avoir vendu une action, le solde du portefeuille ne se met pas à jour à l''écran. Il faut fermer et rouvrir l''application pour voir le bon montant.', N'L''événement de vente mettait à jour la base locale mais pas le modèle de vue affiché. Ajout de la notification de changement de propriété (INotifyPropertyChanged) sur le solde du portefeuille.', 2, 11);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-06-08', NULL, N'Le widget d''écran d''accueil Android affiche les cours de la veille au lieu des cours du jour. L''application principale, elle, affiche bien les cours à jour.', NULL, 1, 14);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-06-30', '2026-07-14', N'Depuis la mise à jour vers iOS 17, la connexion par Face ID échoue systématiquement et renvoie à l''écran de mot de passe.', N'L''API LocalAuthentication renvoyait une nouvelle erreur non gérée sous iOS 17. Mise à jour du SDK et gestion du cas biometryNotAvailable avec repli propre sur le code PIN.', 2, 15);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-04-11', '2026-05-02', N'Le rendement annualisé affiché ignore les dividendes versés. Un portefeuille orienté dividendes paraît donc bien moins performant qu''il ne l''est réellement.', N'La formule de rendement ne sommait que les plus-values. Ajout des dividendes encaissés au numérateur du calcul de performance (rendement total).', 2, 16);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-04-19', NULL, N'L''export PDF du rapport de portefeuille tronque les dernières colonnes du tableau (valorisation et performance) en orientation portrait.', NULL, 1, 17);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-05-07', '2026-05-25', N'La synchronisation multi-appareils crée des doublons de transactions : une opération saisie sur téléphone apparaît deux fois après synchronisation avec la tablette.', N'L''identifiant de transaction était généré côté client, sans garantie d''unicité entre appareils. Passage à un identifiant serveur (GUID) et fusion idempotente lors de la synchronisation.', 2, 19);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-07-02', NULL, N'La devise d''affichage reste en USD alors que l''utilisateur a sélectionné EUR dans les réglages. Le changement n''est pris en compte qu''après réinstallation.', NULL, 1, 20);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-01-15', '2026-01-29', N'L''import d''un relevé au format CSV échoue silencieusement lorsque le fichier utilise le point-virgule comme séparateur (export Excel français). Aucune transaction n''est importée.', N'Le lecteur CSV ne gérait que la virgule. Détection automatique du séparateur (virgule / point-virgule / tabulation) et message d''erreur explicite si le format reste invalide.', 2, 22);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-02-03', NULL, N'Sur écran Retina, les étiquettes du graphique de répartition d''actifs (camembert) se chevauchent et deviennent illisibles quand le portefeuille contient plus de 8 lignes.', NULL, 1, 21);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-02-24', '2026-03-12', N'Les séances programmées pour le lendemain disparaissent du planning passé minuit. L''utilisateur se réveille sans sa séance du jour.', N'Les dates de séance étaient stockées en heure locale mais comparées en UTC, décalant le changement de jour. Normalisation de toutes les dates en UTC au stockage et conversion à l''affichage.', 2, 25);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-03-06', NULL, N'Impossible de supprimer un exercice personnalisé de la bibliothèque. Le bouton « Supprimer » reste sans effet et l''exercice réapparaît au redémarrage.', NULL, 1, 25);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-06-18', '2026-07-04', N'Le minuteur de temps de repos continue de tourner en arrière-plan après la fermeture de l''application et vide la batterie en quelques heures.', N'Un service de premier plan restait actif sans condition d''arrêt. Ajout de l''annulation du minuteur à la fin de la séance et libération du WakeLock.', 2, 30);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-07-21', NULL, N'Les rappels de séance programmés (« Séance jambes à 18 h ») ne s''affichent jamais. Aucune notification n''apparaît, même application ouverte.', NULL, 1, 32);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-05-09', '2026-05-23', N'La synchronisation avec Apple Santé enregistre bien les séances mais pas les calories brûlées associées.', N'Le type de données activeEnergyBurned n''était pas inclus dans la demande d''autorisation HealthKit. Ajout du type manquant et réémission de la demande de permission.', 2, 31);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-03-04', '2026-03-18', N'Le glisser-déposer pour réordonner les exercices d''une séance ne fonctionne pas à la souris sur poste de bureau ; il ne marche qu''au tactile.', N'Seuls les événements tactiles étaient écoutés. Ajout de la prise en charge des événements souris (pointer events) pour couvrir souris et écran tactile.', 2, 34);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-04-02', NULL, N'L''application plante lors de l''ajout d''une photo de progression prise avec un appareil haute résolution (au-delà de 12 mégapixels). Les photos plus petites passent sans souci.', NULL, 1, 35);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-03-27', '2026-04-11', N'Les entrées du journal d''humeur ne sont pas sauvegardées lorsque le texte dépasse environ 500 caractères. L''utilisateur perd son écrit sans message d''erreur.', N'La colonne de base de données était limitée à VARCHAR(500) et l''insertion échouait en silence. Passage en NVARCHAR(MAX) et remontée de l''erreur à l''utilisateur en cas d''échec d''enregistrement.', 2, 38);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-04-05', NULL, N'Lors des exercices de respiration guidée, l''animation visuelle (cercle qui se dilate) se désynchronise progressivement de la piste audio, jusqu''à un décalage de plusieurs secondes.', NULL, 1, 39);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-05-16', '2026-05-30', N'Les rappels d''exercice d''exposition arrivent en pleine nuit (vers 3 h du matin) au lieu de l''heure choisie par l''utilisateur.', N'L''heure de rappel était planifiée en UTC sans conversion vers le fuseau de l''utilisateur. Correction du calcul de la prochaine occurrence dans le fuseau local de l''appareil.', 2, 44);
INSERT INTO Ticket (DateCreation, DateResolution, Probleme, Resolution, StatutId, CompatibiliteId)
VALUES ('2026-06-03', NULL, N'Le graphique d''évolution du niveau d''anxiété reste vide tant que l''utilisateur n''a pas saisi au moins 3 entrées, sans aucun message expliquant pourquoi. Les nouveaux utilisateurs pensent que la fonction est cassée.', NULL, 1, 41);
GO
