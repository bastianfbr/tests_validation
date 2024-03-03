# I. 🚧 Difficultés liées à la validation

## 🔗 Éléments freinant la validation

#### Maintenabilité faible
La duplication de code et l'absence de modularité rendent le code difficile à maintenir. La maintenabilité est affectée négativement par des pratiques telles que l'utilisation extensive de variables globales et le manque d'abstraction.

#### Fiabilité questionnable
L'absence de validation approfondie des entrées utilisateur et de gestion des exceptions peut conduire à des comportements imprévus, affectant la fiabilité du logiciel.

#### Efficacité limitée
Les méthodes de vérification de victoire et d'égalité, par leur simplicité, pourraient ne pas être optimisées pour l'efficacité, surtout en termes de performance.

---
### 🐛 Exemples de problèmes de design

#### Duplication de code :
Dans Morpion.cs et PuissanceQuatre.cs, des fonctions comme tourJoueur et tourJoueur2 présentent une duplication significative. Ce manque de DRY (Don't Repeat Yourself) compromet la maintenabilité.

```csharp
void tourJoueur() {
    // Logique du tour du joueur 1
}

void tourJoueur2() {
    // Logique très similaire pour le joueur 2, indiquant une duplication
}
```

#### Validation des entrées
La méthode ChoisirJeu dans Program.cs ne gère pas explicitement les entrées invalides, ce qui peut induire des erreurs et affecter la fiabilité.
```csharp
private static ConsoleKey ChoisirJeu()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.X && key != ConsoleKey.P);

            return key;
        }
```

#### Code commenté et fonctions void
L'usage fréquent de méthodes void sans retour explicite de l'état ou du résultat de l'opération peut limiter la testabilité et la clarté du code. De plus, le code commenté trouvé dans les fichiers suggère une possible confusion ou un manque de nettoyage du code, affectant la lisibilité.

#### Couplage
L'interdépendance entre les différentes parties du logiciel, comme l'interaction directe entre Program.cs et les jeux spécifiques (Morpion.cs, PuissanceQuatre.cs), révèle un couplage fort qui peut compliquer la maintenance et l'introduction de nouvelles fonctionnalités.

# II. 🛠 Méthodes de résolution des problèmes

## ✅ Actions pour valider l'existant

#### Tester l'existant
Développer des tests unitaires pour les composants critiques du logiciel (qui peuvent être testés) pour identifier et corriger les bugs existants et s'assurer que les fonctionnalités actuelles fonctionnent correctement.

#### Améliorer la validation des entrées 
Mettre en place une validation robuste des entrées utilisateur dans Program.cs pour gérer correctement les entrées invalides et fournir des messages d'erreur clairs, évitant ainsi les comportements imprévus du logiciel.

#### Optimiser la gestion d'état
Refactoriser la logique de gestion de l'état du jeu, en remplaçant l'usage de variables globales par des structures de données plus adaptées et des modèles de conception qui favorisent l'encapsulation et la flexibilité.

#### Introduire des Tests unitaires 
Développer des tests unitaires pour chaque composant critique du logiciel, permettant de détecter et de corriger les bugs plus rapidement et de manière fiable.

#### Réduire le couplage : 
Réorganiser le code pour minimiser les dépendances directes entre les composants, en utilisant des interfaces ou des événements pour communiquer entre eux, ce qui rendra le code plus modulaire et facilitera l'ajout de nouvelles fonctionnalités.

#### Nettoyer le Code : 
Supprimer le code mort ou commenté qui n'apporte pas de valeur ajoutée au projet pour améliorer la lisibilité et la maintenabilité du code.

# III. 🌟 Développement des fonctionnalités manquantes

## 🤖 Intégration d'un joueur IA
Expliquez comment vous souhaitez procéder pour « brancher » un joueur contrôlé par l’ordinateur.

## 💾 Système d'historisation et de persistance
Ainsi qu’un système permettant l’historisation et la persistance.

### 🔍 Importance du processus de qualité
Gardez bien en tête que les parties prenantes ont énormément insisté sur la nécessité de processus de qualité robuste. Cette nouvelle fonctionnalité doit donc être testée.
