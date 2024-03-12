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
            return AssistantConsole.DemanderToucheParmiOptions("Jouer à un autre jeu ? Taper [R] pour rejouer. Taper [Q] pour quitter.", ConsoleKey.R, ConsoleKey.Q);
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