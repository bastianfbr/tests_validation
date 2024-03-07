using MorpionApp.Interfaces;

namespace MorpionApp;

public class ComportementMorpion : IComportementJeu
{
    public bool EffectuerAction(EtatJeu etatJeu, char playerSymbol, ref int row, ref int column)
    {
        if (etatJeu.Grille[row, column] == ' ')
        {
            etatJeu.Grille[row, column] = playerSymbol;
            return true;
        }
        return false;
    }

    public (int cursorLeft, int cursorTop) CalculerPositionCurseur(int row, int column)
    {
        return (column * 6 + 1, row * 2);
    }
    
    public (int row, int col) ObtenirEntreeUtilisateur(EtatJeu etatJeu)
    {
        int row = 0, col = 0;
        bool choixValide = false;

        while (!choixValide)
        {
            Console.SetCursorPosition(CalculerPositionCurseur(row, col).cursorLeft, CalculerPositionCurseur(row, col).cursorTop);
            var key = Console.ReadKey(true).Key;

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

        return (row, col);
    }


    public bool VerifVictoire(EtatJeu etatJeu, char c) =>
        etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 0] == c && etatJeu.Grille[2, 0] == c ||
        etatJeu.Grille[0, 1] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 1] == c ||
        etatJeu.Grille[0, 2] == c && etatJeu.Grille[1, 2] == c && etatJeu.Grille[2, 2] == c ||
        etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 2] == c ||
        etatJeu.Grille[1, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[1, 2] == c ||
        etatJeu.Grille[2, 0] == c && etatJeu.Grille[2, 1] == c && etatJeu.Grille[2, 2] == c ||
        etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 2] == c ||
        etatJeu.Grille[2, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[0, 2] == c;
    
    public bool VerifEgalite(EtatJeu etatJeu) =>
    etatJeu.Grille[0, 0] != ' ' && etatJeu.Grille[1, 0] != ' ' && etatJeu.Grille[2, 0] != ' ' &&
    etatJeu.Grille[0, 1] != ' ' && etatJeu.Grille[1, 1] != ' ' && etatJeu.Grille[2, 1] != ' ' &&
    etatJeu.Grille[0, 2] != ' ' && etatJeu.Grille[1, 2] != ' ' && etatJeu.Grille[2, 2] != ' ';
}
