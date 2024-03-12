using MorpionApp.Console;
using MorpionApp.Jeux.Communs.Interfaces;
using MorpionApp.Jeux.Communs;
using MorpionApp.Sauvegarde;

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
                    LancerJeu(choix, null, JeuConsole.DemanderJoueurIA());
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
                        File.Delete("sauvegarde.json");
                        continuer = JeuConsole.DemanderRejouer();
                    }
                    else
                    {
                        File.Delete("sauvegarde.json");
                        var choixJeu = JeuConsole.ChoisirJeu();
                        LancerJeu(choixJeu, null, JeuConsole.DemanderJoueurIA());
                        continuer = JeuConsole.DemanderRejouer();
                    }
                }
            }
        }

        private static void LancerJeu(ConsoleKey choix, EtatJeu? sauvegarde, bool estJoueurIA)
        {
            IJeuFabrique jeuFabrique = new JeuFabrique();
            var jeuConfig = jeuFabrique.CreerConfigurationJeu(choix);
            ControleurDeJeu controleur = new ControleurDeJeu(sauvegarde ?? jeuConfig.etatJeu, jeuConfig.comportementJeu, estJoueurIA, new InteractionUtilisateur());
            controleur.DemarrerJeu();
        }

        private static bool DemanderReprendrePartie()
        {
            System.Console.WriteLine("Une partie de jeu est déjà en cours");
            System.Console.WriteLine("Appuyez sur [R] pour la reprendre ou sur [E] pour l'effacer.");
            
            bool choixValide = false;
            bool chargerPartie = false;
            while (!choixValide)
            {
                var key = System.Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.R:
                        System.Console.Clear();
                        choixValide = true;
                        chargerPartie = true;
                        break;
                    case ConsoleKey.E:
                        choixValide = true;
                        chargerPartie = false;
                        break;
                    default:
                        System.Console.WriteLine("Entrée invalide. Veuillez appuyer sur [R] pour reprendre la partie sauvegardée ou sur [E] pour l'effacer.");
                        break;
                }
            }

            return chargerPartie;
        }
    }
}