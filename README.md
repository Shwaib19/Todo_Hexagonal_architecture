# Todo MVC API - Architecture Hexagonale

Une implémentation robuste d'une API de gestion de tâches (Todo) développée en **.NET 8/9**, utilisant l'**Architecture Hexagonale** (Ports & Adaptateurs) et documentée avec **Scalar**.

## 🎯 Objectif du Projet

Ce projet démontre comment séparer strictement la logique métier des préoccupations techniques (Base de données, API, UI). L'utilisation de l'architecture hexagonale permet de garder un noyau (Core) pur et testable.

## 🚀 Points Clés

- **Architecture Hexagonale** : Découplage total entre le métier et l'infrastructure.
- **Scalar** : Documentation d'API moderne et interactive (alternative à Swagger).
- **Clean Code** : Utilisation des records C#, du typage fort et de l'injection de dépendances.
- **Minimal APIs** : Implémentation performante et légère des points d'entrée.

---

## 🏗️ Structure de la Solution

Le projet est organisé suivant les cercles de l'architecture hexagonale :

- **`Todo.Api`** : Point d'entrer du projet 
- **`Todo.Domain`** : Le cœur de l'application. Contient les entités métier, les exceptions de domaine et les interfaces des ports de sortie (ex: `ITodoRepository`). *Dépendances : Aucune.*
- **`Todo.Application`** : Contient les cas d'utilisation (Use Cases). Orchestre la logique en utilisant les ports du domaine. *Dépendances : Domain.*
- **`Todo.Infrastructure`** : Contient les adaptateurs.


---

## 🛠️ Stack Technique

- **Framework** : ASP.NET Core 8.0+
- **Documentation** : [Scalar](https://github.com/scalar/scalar)
- **Validation** : FluentValidation (optionnel)
- **Mapping** : AutoMapper ou Mapping manuel pour plus de contrôle.

---

## 🚦 Démarrage Rapide

### Prérequis
- [.NET SDK 10.0 ](https://dotnet.microsoft.com/download)
