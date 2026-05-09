using System.Collections.Generic;

public enum Status { ToDo, InProgress, Done }

[System.Serializable]
public class TaskItem
{
    public string Title;
    public string Project;
    public Status Status;
    public string Assignee;

    public TaskItem(string title, string project, Status status, string assignee)
    {
        Title = title;
        Project = project;
        Status = status;
        Assignee = assignee;
    }
}

public static class MockData
{
    public static List<string> Projects = new List<string>
    {
        "Tous les projets", "Site web e-commerce", "App mobile iOS",
        "App mobile Android", "Migration BDD PostgreSQL", "Refonte API REST",
        "Pipeline CI/CD", "Dashboard analytics", "Module authentification",
        "Système de paiement", "Notifications push", "Refonte UX checkout",
        "Internationalisation", "Tests E2E Cypress", "Documentation technique",
        "Audit sécurité"
    };

    public static List<TaskItem> Tasks = new List<TaskItem>
    {
        // ToDo
        new TaskItem("Refactor module auth",         "Module authentification",  Status.ToDo,        "Anas"),
        new TaskItem("Écrire tests API",             "Refonte API REST",         Status.ToDo,        "Yassine"),
        new TaskItem("Réviser PR #142",              "Module authentification",  Status.ToDo,        "Anas"),
        new TaskItem("Configurer pipeline staging",  "Pipeline CI/CD",           Status.ToDo,        "Yassine"),
        new TaskItem("Ajouter pagination produits",  "Site web e-commerce",      Status.ToDo,        "Anas"),
        new TaskItem("Maquette écran panier",        "Refonte UX checkout",      Status.ToDo,        "Yassine"),
        new TaskItem("Audit dépendances npm",        "Audit sécurité",           Status.ToDo,        "Anas"),
        new TaskItem("Traduire interface EN→FR",     "Internationalisation",     Status.ToDo,        "Yassine"),
        new TaskItem("Documenter endpoints REST",    "Documentation technique",  Status.ToDo,        "Anas"),
        new TaskItem("Écrire scénarios E2E login",  "Tests E2E Cypress",        Status.ToDo,        "Yassine"),

        // InProgress
        new TaskItem("Intégration Stripe",           "Système de paiement",      Status.InProgress,  "Anas"),
        new TaskItem("Dashboard KPI temps réel",     "Dashboard analytics",      Status.InProgress,  "Yassine"),
        new TaskItem("Migration table users",        "Migration BDD PostgreSQL", Status.InProgress,  "Anas"),
        new TaskItem("Push notifications iOS",       "Notifications push",       Status.InProgress,  "Yassine"),
        new TaskItem("Refonte page checkout",        "Refonte UX checkout",      Status.InProgress,  "Anas"),
        new TaskItem("Setup Android CI",             "App mobile Android",       Status.InProgress,  "Yassine"),
        new TaskItem("Sécurisation JWT",             "Module authentification",  Status.InProgress,  "Anas"),
        new TaskItem("Optimisation requêtes SQL",    "Migration BDD PostgreSQL", Status.InProgress,  "Yassine"),
        new TaskItem("Composant carte produit",      "Site web e-commerce",      Status.InProgress,  "Anas"),
        new TaskItem("Tests unitaires paiement",     "Système de paiement",      Status.InProgress,  "Yassine"),

        // Done
        new TaskItem("Setup projet iOS",             "App mobile iOS",           Status.Done,        "Anas"),
        new TaskItem("Modèles de données BDD",       "Migration BDD PostgreSQL", Status.Done,        "Yassine"),
        new TaskItem("Charte graphique",             "Refonte UX checkout",      Status.Done,        "Anas"),
        new TaskItem("Config Nginx prod",            "Pipeline CI/CD",           Status.Done,        "Yassine"),
        new TaskItem("Wireframes app Android",       "App mobile Android",       Status.Done,        "Anas"),
        new TaskItem("API auth endpoints",           "Refonte API REST",         Status.Done,        "Yassine"),
        new TaskItem("Dictionnaire traductions",     "Internationalisation",     Status.Done,        "Anas"),
        new TaskItem("Rapport audit SSL",            "Audit sécurité",           Status.Done,        "Yassine"),
        new TaskItem("Page d'accueil e-commerce",    "Site web e-commerce",      Status.Done,        "Anas"),
        new TaskItem("Cahier des charges analytics", "Dashboard analytics",      Status.Done,        "Yassine"),
    };
}