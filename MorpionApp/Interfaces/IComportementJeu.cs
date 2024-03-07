namespace MorpionApp.Interfaces;

public interface IComportementJeu
{
    bool EffectuerAction(EtatJeu etatJeu, char playerSymbol, ref int row, ref int column);
    (int cursorLeft, int cursorTop) CalculerPositionCurseur(int row, int column);

    public (int row, int col) ObtenirEntreeUtilisateur(EtatJeu etatJeu);
    
    bool VerifVictoire(EtatJeu etatJeu, char c);
    bool VerifEgalite(EtatJeu etatJeu);
}
