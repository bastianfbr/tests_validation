using MorpionApp.Interfaces;
using MorpionApp.Jeux;

using System.IO;

namespace MorpionApp
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            bool continuer = true;
            while (continuer)
            {
                if (!File.Exists("sauvegarde.json"))
                {
                    var choix = JeuConsole.ChoisirJeu();
                    LancerJeu(choix, null);
                    continuer = JeuConsole.DemanderRejouer();
                }
                else
                {
                    var choix = DemanderReprendrePartie();

                    if (choix)
                    {
                        var (etatJeu, typeJeu, estJoueurIA) = SauvegardeJeu.Charger();
                        ConsoleKey jeuChoisi = typeJeu == "ComportementMorpion" ? ConsoleKey.X : ConsoleKey.P;
                        LancerJeu(jeuChoisi, etatJeu, estJoueurIA);
                        File.Delete("sauvegarde.json"); // Suppression après chargement
                        continuer = JeuConsole.DemanderRejouer();
                    }
                    else
                    {
                        File.Delete("sauvegarde.json"); // Suppression si l'utilisateur ne veut pas reprendre la partie
                    }
                }
            }
        }

        private static void LancerJeu(ConsoleKey choix, EtatJeu? sauvegarde = null, bool estJoueurIA = false)
        {
            IJeuFabrique jeuFabrique = new JeuFabrique();
            var jeuConfig = jeuFabrique.CreerConfigurationJeu(choix);
            // Passer estJoueurIA et l'état de jeu si présent
            ControleurDeJeu controleur = new ControleurDeJeu(sauvegarde ?? jeuConfig.etatJeu, jeuConfig.comportementJeu, estJoueurIA);
            controleur.DemarrerJeu();
        }

        private static bool DemanderReprendrePartie()
        {
            Console.WriteLine("Une partie de jeu est déjà en cours");
            Console.WriteLine("Appuyez sur [R] pour la reprendre ou sur [E] pour l'effacer.");
            
            bool choixValide = false;
            bool chargerPartie = false;
            while (!choixValide)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.R:
                        Console.Clear();
                        choixValide = true;
                        chargerPartie = true;
                        break;
                    case ConsoleKey.E:
                        choixValide = true;
                        chargerPartie = false;
                        break;
                    default:
                        Console.WriteLine("Entrée invalide. Veuillez appuyer sur [R] pour reprendre la partie sauvegardée ou sur [E] pour l'effacer.");
                        break;
                }
            }

            return chargerPartie;
        }
    }
}