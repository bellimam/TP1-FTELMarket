# TP1 – FTELMarket

API REST de gestion d'un catalogue de produits développée avec ASP.NET Core Web API, Entity Framework Core et SQL Server.

Chaque produit appartient à une catégorie et est associé à un utilisateur.

## Technologies utilisées

- .NET 10 / ASP.NET Core Web API
- Entity Framework Core 10
- SQL Server 2022
- Docker
- C#

## Prérequis

- .NET SDK 10
- Docker Desktop
- SQL Server 2022 via Docker

## Installation et lancement

### 1. Télécharger le projet

```powershell
git clone https://github.com/bellimam/TP1-FTELMarket.git
cd TP1-FTELMarket
```

### 2. Restaurer les dépendances

```powershell
dotnet restore
```

### 3. Démarrer SQL Server avec Docker

```powershell
docker run -d --name ftelmarket-sql -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=VOTRE_MOT_DE_PASSE_FORT" -p 1433:1433 -v ftelmarket-data:/var/opt/mssql mcr.microsoft.com/mssql/server:2022-latest
```

Remplacer `VOTRE_MOT_DE_PASSE_FORT` par un mot de passe personnel robuste.

### 4. Configurer la connexion à SQL Server

Dans PowerShell, définir la variable d'environnement :

```powershell
$env:ConnectionStrings__DefaultConnection = "Server=localhost,1433;Database=FTELMarketDB;User Id=sa;Password=VOTRE_MOT_DE_PASSE_FORT;Encrypt=True;TrustServerCertificate=True"
```

Utiliser le même mot de passe que celui défini lors de la création du conteneur SQL Server.

### 5. Compiler et lancer l'application

```powershell
dotnet build
dotnet run
```

L'application applique les migrations et initialise les données au démarrage si cette configuration est présente dans `Program.cs`.

L'adresse de l'API est affichée dans la console, par exemple :

`http://localhost:5298`

## Endpoints disponibles

| Méthode | Endpoint | Description |
|---|---|---|
| GET | `/api/products` | Récupérer les produits |
| POST | `/api/products` | Ajouter un produit |
| PUT | `/api/products/{id}` | Modifier un produit |
| DELETE | `/api/products/{id}` | Supprimer un produit |
| GET | `/api/categories` | Récupérer les catégories |

## Structure du projet

```text
TP1-FTELMarket/
├── Controllers/
│   └── ProductsController.cs
├── DATA/
│   ├── AppDbContext.cs
│   └── DbInitializer.cs
├── Migrations/
├── Models/
├── Properties/
├── .gitignore
├── FTELMarket.API.csproj
├── FTELMarket.API.http
├── Program.cs
├── appsettings.json
└── README.md
```

## Choix techniques

- Approche Code First avec Entity Framework Core.
- Gestion de la base de données avec les migrations.
- Relation un-à-plusieurs entre User et Product.
- Relation un-à-plusieurs entre Category et Product.
- Prix stocké au format `decimal(18,2)`.
- Date de création définie en UTC.
- Initialisation de catégories et d'un utilisateur de démonstration.
