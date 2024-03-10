using MorpionApp.Structures;

namespace MorpionApp.Interfaces;

public interface IComportementJeu
{
    bool EffectuerAction(EtatJeu etatJeu, IJoueur joueur, Position position);
    (int cursorLeft, int cursorTop) CalculerPositionCurseur(Position position);

    public Position ObtenirEntreeUtilisateur(EtatJeu etatJeu);
    
    bool VerifVictoire(EtatJeu etatJeu, IJoueur joueur);
    bool VerifEgalite(EtatJeu etatJeu);
}
