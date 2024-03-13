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

    public bool VerifVictoire(EtatJeu etatJeu, IJoueur joueur)
    {
        for (int i = 0; i < etatJeu.Grille.GetLength(0); i++)
        {
            for (int j = 0; j < etatJeu.Grille.GetLength(1); j++)
            {
                if (etatJeu.Grille[i, j] == joueur.Symbol)
                {
                    if (j + 3 < etatJeu.Grille.GetLength(1) && etatJeu.Grille[i, j + 1] == joueur.Symbol && etatJeu.Grille[i, j + 2] == joueur.Symbol && etatJeu.Grille[i, j + 3] == joueur.Symbol)
                    {
                        return true;
                    }
                    if (i + 3 < etatJeu.Grille.GetLength(0) && etatJeu.Grille[i + 1, j] == joueur.Symbol && etatJeu.Grille[i + 2, j] == joueur.Symbol && etatJeu.Grille[i + 3, j] == joueur.Symbol)
                    {
                        return true;
                    }
                    if (i + 3 < etatJeu.Grille.GetLength(0) && j + 3 < etatJeu.Grille.GetLength(1) && etatJeu.Grille[i + 1, j + 1] == joueur.Symbol && etatJeu.Grille[i + 2, j + 2] == joueur.Symbol && etatJeu.Grille[i + 3, j + 3] == joueur.Symbol)
                    {
                        return true;
                    }
                    if (i - 3 >= 0 && j + 3 < etatJeu.Grille.GetLength(1) && etatJeu.Grille[i - 1, j + 1] == joueur.Symbol && etatJeu.Grille[i - 2, j + 2] == joueur.Symbol && etatJeu.Grille[i - 3, j + 3] == joueur.Symbol)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool VerifEgalite(EtatJeu etatJeu)
    {
        for (int i = 0; i < etatJeu.Grille.GetLength(0); i++)
        {
            for (int j = 0; j < etatJeu.Grille.GetLength(1); j++)
            {
                if (etatJeu.Grille[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
}
