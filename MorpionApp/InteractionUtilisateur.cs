using MorpionApp.Interfaces;

namespace MorpionApp
{
    public class InteractionUtilisateur : IInteractionUtilisateur
    {
        public void AfficherMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void EffacerConsole()
        {
            Console.Clear();
        }

        public ConsoleKey DemanderContinuerOuQuitter()
        {
            Console.WriteLine("Appuyez sur [N] pour une nouvelle partie, sur [Q] pour quitter.");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if (key != ConsoleKey.N && key != ConsoleKey.Q)
                {
                    Console.WriteLine("Entrée invalide. Veuillez appuyer sur [N] pour une nouvelle partie ou sur [Q] pour quitter.");
                }
            } while (key != ConsoleKey.N && key != ConsoleKey.Q);

            return key;
        }

        public void AfficherGrille(EtatJeu etatJeu)
        {
            etatJeu.AfficherGrille();
        }

        public void AfficherDemandeDeCoup(char symbolJoueur)
        {
            Console.WriteLine($"C'est au tour du joueur {symbolJoueur}. Veuillez choisir une case.");
        }

        public void AfficherCoupInvalide()
        {
            Console.WriteLine("Coup invalide, veuillez réessayer.");
        }
    }
}