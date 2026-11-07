# TP1 – FTELMarket API

## Présentation

Ce projet consiste à développer une API REST pour la gestion d'un catalogue de produits dans le cadre du TP1 – Installation et CRUD.

L'API permet de consulter, créer, modifier et supprimer des produits. Les données sont persistées dans une base de données SQL Server à l'aide d'Entity Framework Core.

## Technologies utilisées

- C#
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core 10
- SQL Server
- Docker (pour l'environnement de base de données)

## Architecture du projet

```text
TP1-FTELMarket/
│
├── Controllers/
│   └── ProductsController.cs
│
├── Data/
│   ├── AppDbContext.cs
│   └── DbInitializer.cs
│
├── Migrations/
│   ├── InitialCreate.cs
│   ├── InitialCreate.Designer.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Models/
│   ├── Product.cs
│   ├── Category.cs
│   └── User.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── FTELMarket.API.csproj
├── appsettings.json
└── README.md
```

## Fonctionnalités

### Gestion des produits

- **GET** : consulter le catalogue des produits.
- **GET** : consulter les catégories.
- **POST** : ajouter un nouveau produit.
- **PUT** : modifier un produit existant.
- **DELETE** : supprimer un produit.

### Modèle de données

- Un utilisateur peut posséder plusieurs produits.
- Chaque produit appartient à une catégorie.
- Chaque produit possède un nom, une description facultative, un prix, un stock et une date de création.

## Prérequis

- .NET 10 SDK
- SQL Server
- Visual Studio ou Visual Studio Code
- Entity Framework Core CLI

## Installation et lancement

### 1. Cloner le dépôt

```bash
git clone https://github.com/bellimam/TP1-FTELMarket.git
cd TP1-FTELMarket
```

### 2. Restaurer les dépendances

```bash
dotnet restore
```

### 3. Configurer la connexion à SQL Server

Configurer la chaîne de connexion `DefaultConnection` dans `appsettings.json`, en fonction de l'environnement SQL Server utilisé.

Ne pas publier de mot de passe ou d'information sensible dans le dépôt.

### 4. Appliquer les migrations

```bash
dotnet ef database update
```

### 5. Lancer l'API

```bash
dotnet run
```

L'API est alors accessible à l'adresse indiquée dans la console.

## Auteur

Projet réalisé dans le cadre du TP1 – Installation et CRUD.
