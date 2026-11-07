# TP1 .NET : Installation et CRUD

API REST **FTELMarket** pour la gestion d'un catalogue de produits. Chaque produit appartient à une catégorie et est associé à un utilisateur. Projet réalisé avec ASP.NET Core Web API, Entity Framework Core (Code First) et SQL Server.

## Technologies

- .NET 10 / ASP.NET Core Web API
- Entity Framework Core 10 (SQL Server)
- SQL Server 2022
- Docker

## Lancer le projet

1. Cloner le dépôt :

   ```bash
   git clone https://github.com/bellimam/TP1-FTELMarket.git
   cd TP1-FTELMarket
   ```

2. Restaurer les dépendances :

   ```bash
   dotnet restore
   ```

3. Démarrer SQL Server avec Docker :

   ```bash
   docker run -d --name ftelmarket-sql \
   -e "ACCEPT_EULA=Y" \
   -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" \
   -p 1433:1433 \
   -v ftelmarket-data:/var/opt/mssql \
   mcr.microsoft.com/mssql/server:2022-latest
   ```

   Remplacer le mot de passe par celui choisi localement.

4. Configurer la chaîne de connexion `DefaultConnection` avec les identifiants du serveur SQL Server.

5. Appliquer les migrations :

   ```bash
   dotnet ef database update
   ```

6. Lancer l'API :

   ```bash
   dotnet run
   ```

## Routes

| Méthode | URL | Description |
|---|---|---|
| GET | `/api/products` | Liste des produits |
| POST | `/api/products` | Ajouter un produit |
| PUT | `/api/products/{id}` | Modifier un produit |
| DELETE | `/api/products/{id}` | Supprimer un produit |
| GET | `/api/categories` | Liste des catégories |

## Structure

```text
Controllers/   ProductsController
DATA/          AppDbContext et DbInitializer
Models/        Product, Category et User
Migrations/    Migrations Entity Framework Core
Properties/    Configuration de lancement
Program.cs     Configuration et démarrage de l'API
```

## Choix techniques

- Entity Framework Core avec l'approche Code First et les migrations.
- Relation 1-N entre User et Product.
- Relation 1-N entre Category et Product.
- Prix stocké en `decimal(18,2)` pour garantir la précision des valeurs monétaires.
- Date de création définie en UTC côté serveur.
- Données initiales des catégories et d'un utilisateur de démonstration.
