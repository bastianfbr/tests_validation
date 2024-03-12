using MorpionApp.Console.Interfaces;
using MorpionApp.Jeux.Communs;

namespace MorpionApp.Console
{
    public class InteractionUtilisateur : IInteractionUtilisateur
    {
        public void AfficherMessage(string message)
        {
            System.Console.WriteLine(message);
        }

        public void EffacerConsole()
        {
            System.Console.Clear();
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
            System.Console.WriteLine($"C'est au tour du joueur {symbolJoueur}. Veuillez choisir une case.");
        }

        public void AfficherCoupInvalide()
        {
            System.Console.WriteLine("Coup invalide, veuillez réessayer.");
        }
    }
}