using MorpionApp.Jeux.Communs;

namespace MorpionApp.Console.Interfaces
{
    public interface IInteractionUtilisateur
    {
        void AfficherMessage(string message);
        void EffacerConsole();
        ConsoleKey DemanderContinuerOuQuitter();
        void AfficherGrille(EtatJeu etatJeu);
        void AfficherDemandeDeCoup(char symbolJoueur);
        void AfficherCoupInvalide();
    }
}