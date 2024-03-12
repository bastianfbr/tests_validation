using MorpionApp.Jeux.Communs.Interfaces;
using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.Structures;

namespace MorpionApp.Jeux.PuissanceQuatre;

public class ComportementPuissanceQuatre : IComportementJeu
{
    public bool EffectuerAction(EtatJeu etatJeu, IJoueur joueur, Position position)
    {
        for (int i = etatJeu.Grille.GetLength(0) - 1; i >= 0; i--)
        {
            if (etatJeu.Grille[i, position.Column] == ' ')
            {
                etatJeu.Grille[i, position.Column] = joueur.Symbol;
                return true;
            }
        }
        return false;
    }
    
    public Position ObtenirEntreeUtilisateur(EtatJeu etatJeu)
    {
        int col = 0;
        bool choixValide = false;

        while (!choixValide)
        {
            System.Console.SetCursorPosition(CalculerPositionCurseur(new Position(etatJeu.Grille.GetLength(0) - 1, col)).cursorLeft, CalculerPositionCurseur(new Position(etatJeu.Grille.GetLength(0) - 1, col)).cursorTop);
            var key = System.Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    col = (col == 0) ? etatJeu.Grille.GetLength(1) - 1 : col - 1;
                    break;
                case ConsoleKey.RightArrow:
                    col = (col == etatJeu.Grille.GetLength(1) - 1) ? 0 : col + 1;
                    break;
                case ConsoleKey.Enter:
                    int row = etatJeu.Grille.GetLength(0) - 1;
                    while (row >= 0 && etatJeu.Grille[row, col] != ' ') row--;

                    if (row >= 0)
                    {
                        return new Position(row, col);
                    }
                    break;
            }
        }
        
        return new Position(-1, -1);
    }


    public (int cursorLeft, int cursorTop) CalculerPositionCurseur(Position position) 
    {
        return (position.Column * 6 + 1, position.Row * 2);
    }

    public bool VerifVictoire(EtatJeu etatJeu, IJoueur joueur) =>
        etatJeu.Grille[0, 0] == joueur.Symbol && etatJeu.Grille[1, 0] == joueur.Symbol && etatJeu.Grille[2, 0] == joueur.Symbol && etatJeu.Grille[3, 0] == joueur.Symbol ||
        etatJeu.Grille[0, 1] == joueur.Symbol && etatJeu.Grille[1, 1] == joueur.Symbol && etatJeu.Grille[2, 1] == joueur.Symbol && etatJeu.Grille[3, 1] == joueur.Symbol ||
        etatJeu.Grille[0, 2] == joueur.Symbol && etatJeu.Grille[1, 2] == joueur.Symbol && etatJeu.Grille[2, 2] == joueur.Symbol && etatJeu.Grille[3, 2] == joueur.Symbol ||
        etatJeu.Grille[0, 3] == joueur.Symbol && etatJeu.Grille[1, 3] == joueur.Symbol && etatJeu.Grille[2, 3] == joueur.Symbol && etatJeu.Grille[3, 3] == joueur.Symbol ||
        etatJeu.Grille[0, 4] == joueur.Symbol && etatJeu.Grille[1, 4] == joueur.Symbol && etatJeu.Grille[2, 4] == joueur.Symbol && etatJeu.Grille[3, 4] == joueur.Symbol ||
        etatJeu.Grille[0, 5] == joueur.Symbol && etatJeu.Grille[1, 5] == joueur.Symbol && etatJeu.Grille[2, 5] == joueur.Symbol && etatJeu.Grille[3, 5] == joueur.Symbol ||
        etatJeu.Grille[0, 6] == joueur.Symbol && etatJeu.Grille[1, 6] == joueur.Symbol && etatJeu.Grille[2, 6] == joueur.Symbol && etatJeu.Grille[3, 6] == joueur.Symbol ||
        etatJeu.Grille[0, 0] == joueur.Symbol && etatJeu.Grille[0, 1] == joueur.Symbol && etatJeu.Grille[0, 2] == joueur.Symbol && etatJeu.Grille[0, 3] == joueur.Symbol ||
        etatJeu.Grille[0, 1] == joueur.Symbol && etatJeu.Grille[0, 2] == joueur.Symbol && etatJeu.Grille[0, 3] == joueur.Symbol && etatJeu.Grille[0, 4] == joueur.Symbol ||
        etatJeu.Grille[0, 2] == joueur.Symbol && etatJeu.Grille[0, 3] == joueur.Symbol && etatJeu.Grille[0, 3] == joueur.Symbol && etatJeu.Grille[0, 5] == joueur.Symbol ||
        etatJeu.Grille[0, 3] == joueur.Symbol && etatJeu.Grille[0, 4] == joueur.Symbol && etatJeu.Grille[0, 5] == joueur.Symbol && etatJeu.Grille[0, 6] == joueur.Symbol ||
        etatJeu.Grille[1, 0] == joueur.Symbol && etatJeu.Grille[1, 1] == joueur.Symbol && etatJeu.Grille[1, 2] == joueur.Symbol && etatJeu.Grille[1, 3] == joueur.Symbol ||
        etatJeu.Grille[1, 1] == joueur.Symbol && etatJeu.Grille[1, 2] == joueur.Symbol && etatJeu.Grille[1, 3] == joueur.Symbol && etatJeu.Grille[1, 4] == joueur.Symbol ||
        etatJeu.Grille[1, 2] == joueur.Symbol && etatJeu.Grille[1, 3] == joueur.Symbol && etatJeu.Grille[1, 4] == joueur.Symbol && etatJeu.Grille[1, 5] == joueur.Symbol ||
        etatJeu.Grille[1, 4] == joueur.Symbol && etatJeu.Grille[1, 4] == joueur.Symbol && etatJeu.Grille[1, 5] == joueur.Symbol && etatJeu.Grille[1, 6] == joueur.Symbol ||
        etatJeu.Grille[2, 0] == joueur.Symbol && etatJeu.Grille[2, 1] == joueur.Symbol && etatJeu.Grille[2, 2] == joueur.Symbol && etatJeu.Grille[2, 3] == joueur.Symbol ||
        etatJeu.Grille[2, 1] == joueur.Symbol && etatJeu.Grille[2, 2] == joueur.Symbol && etatJeu.Grille[2, 3] == joueur.Symbol && etatJeu.Grille[2, 4] == joueur.Symbol ||
        etatJeu.Grille[2, 2] == joueur.Symbol && etatJeu.Grille[2, 3] == joueur.Symbol && etatJeu.Grille[2, 3] == joueur.Symbol && etatJeu.Grille[2, 5] == joueur.Symbol ||
        etatJeu.Grille[2, 3] == joueur.Symbol && etatJeu.Grille[2, 4] == joueur.Symbol && etatJeu.Grille[2, 5] == joueur.Symbol && etatJeu.Grille[2, 6] == joueur.Symbol ||
        etatJeu.Grille[3, 0] == joueur.Symbol && etatJeu.Grille[3, 1] == joueur.Symbol && etatJeu.Grille[3, 2] == joueur.Symbol && etatJeu.Grille[3, 3] == joueur.Symbol ||
        etatJeu.Grille[3, 1] == joueur.Symbol && etatJeu.Grille[3, 2] == joueur.Symbol && etatJeu.Grille[3, 3] == joueur.Symbol && etatJeu.Grille[3, 4] == joueur.Symbol ||
        etatJeu.Grille[3, 2] == joueur.Symbol && etatJeu.Grille[3, 3] == joueur.Symbol && etatJeu.Grille[3, 4] == joueur.Symbol && etatJeu.Grille[3, 5] == joueur.Symbol ||
        etatJeu.Grille[3, 3] == joueur.Symbol && etatJeu.Grille[3, 4] == joueur.Symbol && etatJeu.Grille[3, 5] == joueur.Symbol && etatJeu.Grille[3, 6] == joueur.Symbol ||
        etatJeu.Grille[0, 0] == joueur.Symbol && etatJeu.Grille[1, 1] == joueur.Symbol && etatJeu.Grille[2, 2] == joueur.Symbol && etatJeu.Grille[3, 3] == joueur.Symbol ||
        etatJeu.Grille[0, 1] == joueur.Symbol && etatJeu.Grille[1, 2] == joueur.Symbol && etatJeu.Grille[2, 3] == joueur.Symbol && etatJeu.Grille[3, 4] == joueur.Symbol ||
        etatJeu.Grille[0, 2] == joueur.Symbol && etatJeu.Grille[1, 3] == joueur.Symbol && etatJeu.Grille[2, 4] == joueur.Symbol && etatJeu.Grille[3, 5] == joueur.Symbol ||
        etatJeu.Grille[0, 3] == joueur.Symbol && etatJeu.Grille[1, 4] == joueur.Symbol && etatJeu.Grille[2, 5] == joueur.Symbol && etatJeu.Grille[3, 6] == joueur.Symbol ||
        etatJeu.Grille[0, 3] == joueur.Symbol && etatJeu.Grille[1, 2] == joueur.Symbol && etatJeu.Grille[2, 1] == joueur.Symbol && etatJeu.Grille[3, 0] == joueur.Symbol ||
        etatJeu.Grille[0, 4] == joueur.Symbol && etatJeu.Grille[1, 4] == joueur.Symbol && etatJeu.Grille[2, 2] == joueur.Symbol && etatJeu.Grille[3, 1] == joueur.Symbol ||
        etatJeu.Grille[0, 5] == joueur.Symbol && etatJeu.Grille[1, 3] == joueur.Symbol && etatJeu.Grille[2, 3] == joueur.Symbol && etatJeu.Grille[3, 2] == joueur.Symbol ||
        etatJeu.Grille[0, 6] == joueur.Symbol && etatJeu.Grille[1, 5] == joueur.Symbol && etatJeu.Grille[2, 4] == joueur.Symbol && etatJeu.Grille[3, 3] == joueur.Symbol;
    
    public bool VerifEgalite(EtatJeu etatJeu) =>
        etatJeu.Grille[0, 0] != ' ' && etatJeu.Grille[0, 1] != ' ' && etatJeu.Grille[0, 2] != ' ' && etatJeu.Grille[0, 3] != ' ' &&
        etatJeu.Grille[0, 4] != ' ' && etatJeu.Grille[0, 5] != ' ' && etatJeu.Grille[0, 6] != ' ' &&
        etatJeu.Grille[1, 0] != ' ' && etatJeu.Grille[1, 1] != ' ' && etatJeu.Grille[1, 2] != ' ' && etatJeu.Grille[1, 3] != ' ' &&
        etatJeu.Grille[1, 4] != ' ' && etatJeu.Grille[1, 5] != ' ' && etatJeu.Grille[1, 6] != ' ' &&
        etatJeu.Grille[2, 0] != ' ' && etatJeu.Grille[2, 1] != ' ' && etatJeu.Grille[1, 2] != ' ' && etatJeu.Grille[2, 3] != ' ' &&
        etatJeu.Grille[2, 4] != ' ' && etatJeu.Grille[2, 5] != ' ' && etatJeu.Grille[2, 6] != ' ' &&
        etatJeu.Grille[3, 0] != ' ' && etatJeu.Grille[3, 1] != ' ' && etatJeu.Grille[3, 2] != ' ' && etatJeu.Grille[3, 3] != ' ' &&
        etatJeu.Grille[3, 4] != ' ' && etatJeu.Grille[3, 5] != ' ' && etatJeu.Grille[3, 5] != ' ';
}
