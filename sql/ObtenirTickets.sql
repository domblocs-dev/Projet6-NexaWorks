USE NexaWorks;
GO

CREATE OR ALTER PROCEDURE ObtenirTickets
    @Statut     NVARCHAR(50)  = NULL,
    @Produit    NVARCHAR(100) = NULL,
    @Version    NVARCHAR(50)  = NULL,
    @DateDebut  DATE          = NULL,
    @DateFin    DATE          = NULL,
    @MotCle     NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.Id,
        p.Nom            AS Produit,
        v.Numero         AS Version,
        o.Nom            AS OS,
        s.Nom            AS Statut,
        t.DateCreation,
        t.DateResolution,
        t.Probleme,
        t.Resolution
    FROM Ticket t
        INNER JOIN Statut s         ON s.Id = t.StatutId
        INNER JOIN Compatibilite c  ON c.Id = t.CompatibiliteId
        INNER JOIN [Version] v      ON v.Id = c.VersionId
        INNER JOIN Produit p        ON p.Id = v.ProduitId
        INNER JOIN [OS] o           ON o.Id = c.OSId
    WHERE
        (@Statut    IS NULL OR s.Nom = @Statut)
        AND (@Produit   IS NULL OR p.Nom = @Produit)
        AND (@Version   IS NULL OR v.Numero = @Version)
        AND (@DateDebut IS NULL OR t.DateCreation >= @DateDebut)
        AND (@DateFin   IS NULL OR t.DateCreation <= @DateFin)
        AND (@MotCle    IS NULL OR t.Probleme LIKE N'%' + @MotCle + N'%')
    ORDER BY t.Id;
END;

GO
-- Tests

EXEC ObtenirTickets @Statut = N'En cours';
EXEC ObtenirTickets @Statut = N'Résolu', @Produit = N'Trader en Herbe', @Version = N'1.2';
EXEC ObtenirTickets @MotCle = N'batterie';
EXEC ObtenirTickets @DateDebut = '2026-06-01', @DateFin = '2026-06-30';