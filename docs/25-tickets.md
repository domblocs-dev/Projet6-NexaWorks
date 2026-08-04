# NexaWorks — 25 tickets d'exemple

> Tickets créés pour alimenter la base de données de suivi des problèmes.
> Ils respectent le format du document *« Exemples de tickets »* et la
> matrice de compatibilité du document *« Tableau des produits et versions »*.
>
> **Couverture** : 4 produits, 12 versions, 6 systèmes d'exploitation (chacun ≥ 3),
> **14 tickets résolus** et **11 tickets en cours**.

## Ticket de référence (fourni par NexaWorks)

- **Produit** : Trader en Herbe
- **Version** : 1.2
- **Système d'exploitation** : iOS
- **Date de création** : 2 mars 2023
- **Date de résolution** : 16 avril 2023
- **Statut** : Résolu
- **Problème** : L'utilisateur dit que les achats se font en double pour chaque achat effectué. Si l'utilisateur souhaite acheter 10 actions Apple, le programme effectue deux transactions, chacune pour 10 actions.
- **Résolution** : L'utilisateur était sur un réseau 3G et s'attendait à ce que l'achat soit effectué plus rapidement. Comme l'écran n'a pas changé assez vite, il a cliqué à nouveau. Demande envoyée à l'équipe de dev : ajouter une animation « en cours » et désactiver le bouton d'achat après le premier clic.

---

## Ticket 1
- **Produit** : Trader en Herbe
- **Version** : 1.0
- **Système d'exploitation** : Windows
- **Date de création** : 12 janvier 2023
- **Date de résolution** : 27 janvier 2023
- **Statut** : Résolu
- **Problème** : Sur les postes dont la langue système utilise la virgule comme séparateur décimal (français, allemand), tous les cours de bourse s'affichent à « 0,00 ». L'utilisateur ne peut donc pas suivre ses valeurs.
- **Résolution** : Le parsing des prix utilisait la culture système au lieu de `InvariantCulture`. Le service de cotation renvoie des nombres au format anglo-saxon (point décimal). Correction : forcer `CultureInfo.InvariantCulture` lors de la désérialisation des prix.

## Ticket 2
- **Produit** : Trader en Herbe
- **Version** : 1.0
- **Système d'exploitation** : Linux
- **Date de création** : 3 février 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : Le graphique de cours ne se rafraîchit pas en temps réel. L'utilisateur doit changer d'onglet puis revenir pour voir la valeur mise à jour. Le problème n'apparaît que sous certains gestionnaires de fenêtres Linux.

## Ticket 3
- **Produit** : Trader en Herbe
- **Version** : 1.1
- **Système d'exploitation** : MacOS
- **Date de création** : 18 mars 2023
- **Date de résolution** : 5 avril 2023
- **Statut** : Résolu
- **Problème** : Les alertes de seuil de prix (« notifier quand AAPL > 180 $ ») sont envoyées deux fois, à quelques secondes d'intervalle.
- **Résolution** : Deux abonnements au flux de prix étaient créés au retour de veille du Mac. Ajout d'une déduplication par identifiant d'alerte et fermeture propre de l'ancien abonnement avant réabonnement.

## Ticket 4
- **Produit** : Trader en Herbe
- **Version** : 1.2
- **Système d'exploitation** : iOS
- **Date de création** : 22 mai 2023
- **Date de résolution** : 9 juin 2023
- **Statut** : Résolu
- **Problème** : Sur iPhone SE (petit écran), le clavier numérique masque le champ « quantité » lors de la saisie d'un ordre. L'utilisateur ne voit pas ce qu'il tape.
- **Résolution** : La vue de saisie ne remontait pas au-dessus du clavier. Ajout d'un ajustement de la marge basse égale à la hauteur du clavier (`keyboardWillShow`) et défilement automatique vers le champ actif.

## Ticket 5
- **Produit** : Trader en Herbe
- **Version** : 1.2
- **Système d'exploitation** : Windows Mobile
- **Date de création** : 14 juin 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : L'application se ferme brutalement lorsque l'utilisateur ajoute une action à sa liste de suivi et que cette liste contient déjà plus de 50 valeurs. En dessous de 50, aucun souci.

## Ticket 6
- **Produit** : Trader en Herbe
- **Version** : 1.2
- **Système d'exploitation** : Windows Mobile
- **Date de création** : 1 juillet 2023
- **Date de résolution** : 20 juillet 2023
- **Statut** : Résolu
- **Problème** : Après avoir vendu une action, le solde du portefeuille ne se met pas à jour à l'écran. Il faut fermer et rouvrir l'application pour voir le bon montant.
- **Résolution** : L'événement de vente mettait à jour la base locale mais pas le modèle de vue affiché. Ajout de la notification de changement de propriété (`INotifyPropertyChanged`) sur le solde du portefeuille.

## Ticket 7
- **Produit** : Trader en Herbe
- **Version** : 1.3
- **Système d'exploitation** : Android
- **Date de création** : 8 septembre 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : Le widget d'écran d'accueil Android affiche les cours de la veille au lieu des cours du jour. L'application principale, elle, affiche bien les cours à jour.

## Ticket 8
- **Produit** : Trader en Herbe
- **Version** : 1.3
- **Système d'exploitation** : iOS
- **Date de création** : 30 septembre 2023
- **Date de résolution** : 14 octobre 2023
- **Statut** : Résolu
- **Problème** : Depuis la mise à jour vers iOS 17, la connexion par Face ID échoue systématiquement et renvoie à l'écran de mot de passe.
- **Résolution** : L'API `LocalAuthentication` renvoyait une nouvelle erreur non gérée sous iOS 17. Mise à jour du SDK et gestion du cas `biometryNotAvailable` avec repli propre sur le code PIN.

## Ticket 9
- **Produit** : Maître des Investissements
- **Version** : 1.0
- **Système d'exploitation** : MacOS
- **Date de création** : 11 avril 2023
- **Date de résolution** : 2 mai 2023
- **Statut** : Résolu
- **Problème** : Le rendement annualisé affiché ignore les dividendes versés. Un portefeuille orienté dividendes paraît donc bien moins performant qu'il ne l'est réellement.
- **Résolution** : La formule de rendement ne sommait que les plus-values. Ajout des dividendes encaissés au numérateur du calcul de performance (rendement total).

## Ticket 10
- **Produit** : Maître des Investissements
- **Version** : 1.0
- **Système d'exploitation** : iOS
- **Date de création** : 19 avril 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : L'export PDF du rapport de portefeuille tronque les dernières colonnes du tableau (valorisation et performance) en orientation portrait.

## Ticket 11
- **Produit** : Maître des Investissements
- **Version** : 2.0
- **Système d'exploitation** : Android
- **Date de création** : 7 août 2023
- **Date de résolution** : 25 août 2023
- **Statut** : Résolu
- **Problème** : La synchronisation multi-appareils crée des doublons de transactions : une opération saisie sur téléphone apparaît deux fois après synchronisation avec la tablette.
- **Résolution** : L'identifiant de transaction était généré côté client, sans garantie d'unicité entre appareils. Passage à un identifiant serveur (GUID) et fusion idempotente lors de la synchronisation.

## Ticket 12
- **Produit** : Maître des Investissements
- **Version** : 2.0
- **Système d'exploitation** : iOS
- **Date de création** : 2 octobre 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : La devise d'affichage reste en USD alors que l'utilisateur a sélectionné EUR dans les réglages. Le changement n'est pris en compte qu'après réinstallation.

## Ticket 13
- **Produit** : Maître des Investissements
- **Version** : 2.1
- **Système d'exploitation** : Windows
- **Date de création** : 15 janvier 2024
- **Date de résolution** : 29 janvier 2024
- **Statut** : Résolu
- **Problème** : L'import d'un relevé au format CSV échoue silencieusement lorsque le fichier utilise le point-virgule comme séparateur (export Excel français). Aucune transaction n'est importée.
- **Résolution** : Le lecteur CSV ne gérait que la virgule. Détection automatique du séparateur (virgule / point-virgule / tabulation) et message d'erreur explicite si le format reste invalide.

## Ticket 14
- **Produit** : Maître des Investissements
- **Version** : 2.1
- **Système d'exploitation** : MacOS
- **Date de création** : 3 février 2024
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : Sur écran Retina, les étiquettes du graphique de répartition d'actifs (camembert) se chevauchent et deviennent illisibles quand le portefeuille contient plus de 8 lignes.

## Ticket 15
- **Produit** : Planificateur d'Entraînement
- **Version** : 1.0
- **Système d'exploitation** : Linux
- **Date de création** : 24 février 2023
- **Date de résolution** : 12 mars 2023
- **Statut** : Résolu
- **Problème** : Les séances programmées pour le lendemain disparaissent du planning passé minuit. L'utilisateur se réveille sans sa séance du jour.
- **Résolution** : Les dates de séance étaient stockées en heure locale mais comparées en UTC, décalant le changement de jour. Normalisation de toutes les dates en UTC au stockage et conversion à l'affichage.

## Ticket 16
- **Produit** : Planificateur d'Entraînement
- **Version** : 1.0
- **Système d'exploitation** : Linux
- **Date de création** : 6 mars 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : Impossible de supprimer un exercice personnalisé de la bibliothèque. Le bouton « Supprimer » reste sans effet et l'exercice réapparaît au redémarrage.

## Ticket 17
- **Produit** : Planificateur d'Entraînement
- **Version** : 1.1
- **Système d'exploitation** : Android
- **Date de création** : 18 juin 2023
- **Date de résolution** : 4 juillet 2023
- **Statut** : Résolu
- **Problème** : Le minuteur de temps de repos continue de tourner en arrière-plan après la fermeture de l'application et vide la batterie en quelques heures.
- **Résolution** : Un service de premier plan restait actif sans condition d'arrêt. Ajout de l'annulation du minuteur à la fin de la séance et libération du `WakeLock`.

## Ticket 18
- **Produit** : Planificateur d'Entraînement
- **Version** : 1.1
- **Système d'exploitation** : Windows Mobile
- **Date de création** : 21 juillet 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : Les rappels de séance programmés (« Séance jambes à 18 h ») ne s'affichent jamais. Aucune notification n'apparaît, même application ouverte.

## Ticket 19
- **Produit** : Planificateur d'Entraînement
- **Version** : 1.1
- **Système d'exploitation** : iOS
- **Date de création** : 9 août 2023
- **Date de résolution** : 23 août 2023
- **Statut** : Résolu
- **Problème** : La synchronisation avec Apple Santé enregistre bien les séances mais pas les calories brûlées associées.
- **Résolution** : Le type de données `activeEnergyBurned` n'était pas inclus dans la demande d'autorisation HealthKit. Ajout du type manquant et réémission de la demande de permission.

## Ticket 20
- **Produit** : Planificateur d'Entraînement
- **Version** : 2.0
- **Système d'exploitation** : Windows
- **Date de création** : 4 mars 2024
- **Date de résolution** : 18 mars 2024
- **Statut** : Résolu
- **Problème** : Le glisser-déposer pour réordonner les exercices d'une séance ne fonctionne pas à la souris sur poste de bureau ; il ne marche qu'au tactile.
- **Résolution** : Seuls les événements tactiles étaient écoutés. Ajout de la prise en charge des événements souris (`pointer events`) pour couvrir souris et écran tactile.

## Ticket 21
- **Produit** : Planificateur d'Entraînement
- **Version** : 2.0
- **Système d'exploitation** : Android
- **Date de création** : 2 avril 2024
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : L'application plante lors de l'ajout d'une photo de progression prise avec un appareil haute résolution (au-delà de 12 mégapixels). Les photos plus petites passent sans souci.

## Ticket 22
- **Produit** : Planificateur d'Anxiété Sociale
- **Version** : 1.0
- **Système d'exploitation** : Windows
- **Date de création** : 27 mars 2023
- **Date de résolution** : 11 avril 2023
- **Statut** : Résolu
- **Problème** : Les entrées du journal d'humeur ne sont pas sauvegardées lorsque le texte dépasse environ 500 caractères. L'utilisateur perd son écrit sans message d'erreur.
- **Résolution** : La colonne de base de données était limitée à `VARCHAR(500)` et l'insertion échouait en silence. Passage en `NVARCHAR(MAX)` et remontée de l'erreur à l'utilisateur en cas d'échec d'enregistrement.

## Ticket 23
- **Produit** : Planificateur d'Anxiété Sociale
- **Version** : 1.0
- **Système d'exploitation** : Android
- **Date de création** : 5 avril 2023
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : Lors des exercices de respiration guidée, l'animation visuelle (cercle qui se dilate) se désynchronise progressivement de la piste audio, jusqu'à un décalage de plusieurs secondes.

## Ticket 24
- **Produit** : Planificateur d'Anxiété Sociale
- **Version** : 1.1
- **Système d'exploitation** : iOS
- **Date de création** : 16 mai 2024
- **Date de résolution** : 30 mai 2024
- **Statut** : Résolu
- **Problème** : Les rappels d'exercice d'exposition arrivent en pleine nuit (vers 3 h du matin) au lieu de l'heure choisie par l'utilisateur.
- **Résolution** : L'heure de rappel était planifiée en UTC sans conversion vers le fuseau de l'utilisateur. Correction du calcul de la prochaine occurrence dans le fuseau local de l'appareil.

## Ticket 25
- **Produit** : Planificateur d'Anxiété Sociale
- **Version** : 1.1
- **Système d'exploitation** : MacOS
- **Date de création** : 3 juin 2024
- **Date de résolution** :
- **Statut** : En cours
- **Problème** : Le graphique d'évolution du niveau d'anxiété reste vide tant que l'utilisateur n'a pas saisi au moins 3 entrées, sans aucun message expliquant pourquoi. Les nouveaux utilisateurs pensent que la fonction est cassée.
