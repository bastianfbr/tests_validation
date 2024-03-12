using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.Communs.Interfaces;
using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Structures;

namespace MorpionApp.Jeux.Morpion;

public class ComportementMorpion : IComportementJeu
{
    public bool EffectuerAction(EtatJeu etatJeu, IJoueur joueur, Position position)
    {
        if (etatJeu.Grille[position.Row, position.Column] == ' ')
        {
            etatJeu.Grille[position.Row, position.Column] = joueur.Symbol;
            return true;
        }
        return false;
    }

    public (int cursorLeft, int cursorTop) CalculerPositionCurseur(Position position)
    {
        return (position.Column * 6 + 1, position.Row * 2);
    }
    
    public Position ObtenirEntreeUtilisateur(EtatJeu etatJeu)
    {
        int row = 0, col = 0;
        bool choixValide = false;

        while (!choixValide)
        {
            System.Console.SetCursorPosition(CalculerPositionCurseur(new Position(row, col)).cursorLeft, CalculerPositionCurseur(new Position(row, col)).cursorTop);
            var key = System.Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    row = (row == 0) ? etatJeu.Grille.GetLength(0) - 1 : row - 1;
                    break;
                case ConsoleKey.DownArrow:
                    row = (row == etatJeu.Grille.GetLength(0) - 1) ? 0 : row + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    col = (col == 0) ? etatJeu.Grille.GetLength(1) - 1 : col - 1;
                    break;
                case ConsoleKey.RightArrow:
                    col = (col == etatJeu.Grille.GetLength(1) - 1) ? 0 : col + 1;
                    break;
                case ConsoleKey.Enter:
                    if (etatJeu.Grille[row, col] == ' ')
                    {
                        choixValide = true;
                    }
                    break;
            }
        }

        return new Position(row, col);
    }


    public bool VerifVictoire(EtatJeu etatJeu, IJoueur joueur)
    {
        for (int i = 0; i < etatJeu.Grille.GetLength(0); i++)
        {
            if (etatJeu.Grille[i, 0] == joueur.Symbol && etatJeu.Grille[i, 1] == joueur.Symbol && etatJeu.Grille[i, 2] == joueur.Symbol)
            {
                return true;
            }
        }
        
        for (int i = 0; i < etatJeu.Grille.GetLength(1); i++)
        {
            if (etatJeu.Grille[0, i] == joueur.Symbol && etatJeu.Grille[1, i] == joueur.Symbol && etatJeu.Grille[2, i] == joueur.Symbol)
            {
                return true;
            }
        }
        
        if (etatJeu.Grille[0, 0] == joueur.Symbol && etatJeu.Grille[1, 1] == joueur.Symbol && etatJeu.Grille[2, 2] == joueur.Symbol)
        {
            return true;
        }
        
        if (etatJeu.Grille[0, 2] == joueur.Symbol && etatJeu.Grille[1, 1] == joueur.Symbol && etatJeu.Grille[2, 0] == joueur.Symbol)
        {
            return true;
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
