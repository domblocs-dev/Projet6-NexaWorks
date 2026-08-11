-- Démonstration des 20 requêtes de la liste, via la procédure unique ObtenirTickets.
-- Chaque bloc = une demande de la liste, obtenue en appelant la MÊME procédure avec des paramètres différents.
-- Valeurs d'exemple : produit = Trader en Herbe ; version = 1.2 ; période = 01/01/2026 au 30/06/2026 ; mot-clé = écran.

USE NexaWorks;
GO

PRINT '1. En cours (tous les produits)';
EXEC ObtenirTickets @Statut=N'En cours';

PRINT '2. En cours, un produit (toutes versions)';
EXEC ObtenirTickets @Statut=N'En cours', @Produit=N'Trader en Herbe';

PRINT '3. En cours, un produit (une version)';
EXEC ObtenirTickets @Statut=N'En cours', @Produit=N'Trader en Herbe', @Version=N'1.2';

PRINT '4. Rencontrés sur une période, un produit (toutes versions)';
EXEC ObtenirTickets @Produit=N'Trader en Herbe', @DateDebut='2026-01-01', @DateFin='2026-06-30';

PRINT '5. Rencontrés sur une période, un produit (une version)';
EXEC ObtenirTickets @Produit=N'Trader en Herbe', @Version=N'1.2', @DateDebut='2026-01-01', @DateFin='2026-06-30';

PRINT '6. En cours, mots-clés (tous les produits)';
EXEC ObtenirTickets @Statut=N'En cours', @MotCle=N'écran';

PRINT '7. En cours, un produit, mots-clés (toutes versions)';
EXEC ObtenirTickets @Statut=N'En cours', @Produit=N'Trader en Herbe', @MotCle=N'écran';

PRINT '8. En cours, un produit, mots-clés (une version)';
EXEC ObtenirTickets @Statut=N'En cours', @Produit=N'Trader en Herbe', @Version=N'1.2', @MotCle=N'écran';

PRINT '9. Période, un produit, mots-clés (toutes versions)';
EXEC ObtenirTickets @Produit=N'Trader en Herbe', @DateDebut='2026-01-01', @DateFin='2026-06-30', @MotCle=N'écran';

PRINT '10. Période, un produit, mots-clés (une version)';
EXEC ObtenirTickets @Produit=N'Trader en Herbe', @Version=N'1.2', @DateDebut='2026-01-01', @DateFin='2026-06-30', @MotCle=N'écran';

PRINT '11. Résolus (tous les produits)';
EXEC ObtenirTickets @Statut=N'Résolu';

PRINT '12. Résolus, un produit (toutes versions)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe';

PRINT '13. Résolus, un produit (une version)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe', @Version=N'1.2';

PRINT '14. Résolus sur une période, un produit (toutes versions)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe', @DateDebut='2026-01-01', @DateFin='2026-06-30';

PRINT '15. Résolus sur une période, un produit (une version)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe', @Version=N'1.2', @DateDebut='2026-01-01', @DateFin='2026-06-30';

PRINT '16. Résolus, mots-clés (tous les produits)';
EXEC ObtenirTickets @Statut=N'Résolu', @MotCle=N'écran';

PRINT '17. Résolus, un produit, mots-clés (toutes versions)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe', @MotCle=N'écran';

PRINT '18. Résolus, un produit, mots-clés (une version)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe', @Version=N'1.2', @MotCle=N'écran';

PRINT '19. Résolus sur une période, un produit, mots-clés (toutes versions)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe', @DateDebut='2026-01-01', @DateFin='2026-06-30', @MotCle=N'écran';

PRINT '20. Résolus sur une période, un produit, mots-clés (une version)';
EXEC ObtenirTickets @Statut=N'Résolu', @Produit=N'Trader en Herbe', @Version=N'1.2', @DateDebut='2026-01-01', @DateFin='2026-06-30', @MotCle=N'écran';

