using MorpionApp.Interfaces;

namespace MorpionApp;

public class ComportementPuissanceQuatre : IComportementJeu
{
    public bool EffectuerAction(EtatJeu etatJeu, char playerSymbol, ref int row, ref int column)
    {
        for (int i = etatJeu.Grille.GetLength(0) - 1; i >= 0; i--)
        {
            if (etatJeu.Grille[i, column] == ' ')
            {
                etatJeu.Grille[i, column] = playerSymbol;
                return true;
            }
        }
        return false;
    }
    
    public (int row, int col) ObtenirEntreeUtilisateur(EtatJeu etatJeu)
    {
        int col = 0;
        bool choixValide = false;

        while (!choixValide)
        {
            Console.SetCursorPosition(CalculerPositionCurseur(0, col).cursorLeft, CalculerPositionCurseur(0, col).cursorTop);
            var key = Console.ReadKey(true).Key;

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
                        return (row, col);
                    }
                    break;
            }
        }
        
        return (-1, -1);
    }


    public (int cursorLeft, int cursorTop) CalculerPositionCurseur(int row, int column)
    {
        return (column * 6 + 1, row * 2);
    }

    public bool VerifVictoire(EtatJeu etatJeu, char c) =>
        etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 0] == c && etatJeu.Grille[2, 0] == c && etatJeu.Grille[3, 0] == c ||
        etatJeu.Grille[0, 1] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 1] == c && etatJeu.Grille[3, 1] == c ||
        etatJeu.Grille[0, 2] == c && etatJeu.Grille[1, 2] == c && etatJeu.Grille[2, 2] == c && etatJeu.Grille[3, 2] == c ||
        etatJeu.Grille[0, 3] == c && etatJeu.Grille[1, 3] == c && etatJeu.Grille[2, 3] == c && etatJeu.Grille[3, 3] == c ||
        etatJeu.Grille[0, 4] == c && etatJeu.Grille[1, 4] == c && etatJeu.Grille[2, 4] == c && etatJeu.Grille[3, 4] == c ||
        etatJeu.Grille[0, 5] == c && etatJeu.Grille[1, 5] == c && etatJeu.Grille[2, 5] == c && etatJeu.Grille[3, 5] == c ||
        etatJeu.Grille[0, 6] == c && etatJeu.Grille[1, 6] == c && etatJeu.Grille[2, 6] == c && etatJeu.Grille[3, 6] == c ||
        etatJeu.Grille[0, 0] == c && etatJeu.Grille[0, 1] == c && etatJeu.Grille[0, 2] == c && etatJeu.Grille[0, 3] == c ||
        etatJeu.Grille[0, 1] == c && etatJeu.Grille[0, 2] == c && etatJeu.Grille[0, 3] == c && etatJeu.Grille[0, 4] == c ||
        etatJeu.Grille[0, 2] == c && etatJeu.Grille[0, 3] == c && etatJeu.Grille[0, 3] == c && etatJeu.Grille[0, 5] == c ||
        etatJeu.Grille[0, 3] == c && etatJeu.Grille[0, 4] == c && etatJeu.Grille[0, 5] == c && etatJeu.Grille[0, 6] == c ||
        etatJeu.Grille[1, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[1, 2] == c && etatJeu.Grille[1, 3] == c ||
        etatJeu.Grille[1, 1] == c && etatJeu.Grille[1, 2] == c && etatJeu.Grille[1, 3] == c && etatJeu.Grille[1, 4] == c ||
        etatJeu.Grille[1, 2] == c && etatJeu.Grille[1, 3] == c && etatJeu.Grille[1, 4] == c && etatJeu.Grille[1, 5] == c ||
        etatJeu.Grille[1, 4] == c && etatJeu.Grille[1, 4] == c && etatJeu.Grille[1, 5] == c && etatJeu.Grille[1, 6] == c ||
        etatJeu.Grille[2, 0] == c && etatJeu.Grille[2, 1] == c && etatJeu.Grille[2, 2] == c && etatJeu.Grille[2, 3] == c ||
        etatJeu.Grille[2, 1] == c && etatJeu.Grille[2, 2] == c && etatJeu.Grille[2, 3] == c && etatJeu.Grille[2, 4] == c ||
        etatJeu.Grille[2, 2] == c && etatJeu.Grille[2, 3] == c && etatJeu.Grille[2, 3] == c && etatJeu.Grille[2, 5] == c ||
        etatJeu.Grille[2, 3] == c && etatJeu.Grille[2, 4] == c && etatJeu.Grille[2, 5] == c && etatJeu.Grille[2, 6] == c ||
        etatJeu.Grille[3, 0] == c && etatJeu.Grille[3, 1] == c && etatJeu.Grille[3, 2] == c && etatJeu.Grille[3, 3] == c ||
        etatJeu.Grille[3, 1] == c && etatJeu.Grille[3, 2] == c && etatJeu.Grille[3, 3] == c && etatJeu.Grille[3, 4] == c ||
        etatJeu.Grille[3, 2] == c && etatJeu.Grille[3, 3] == c && etatJeu.Grille[3, 4] == c && etatJeu.Grille[3, 5] == c ||
        etatJeu.Grille[3, 3] == c && etatJeu.Grille[3, 4] == c && etatJeu.Grille[3, 5] == c && etatJeu.Grille[3, 6] == c ||
        etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 2] == c && etatJeu.Grille[3, 3] == c ||
        etatJeu.Grille[0, 1] == c && etatJeu.Grille[1, 2] == c && etatJeu.Grille[2, 3] == c && etatJeu.Grille[3, 4] == c ||
        etatJeu.Grille[0, 2] == c && etatJeu.Grille[1, 3] == c && etatJeu.Grille[2, 4] == c && etatJeu.Grille[3, 5] == c ||
        etatJeu.Grille[0, 3] == c && etatJeu.Grille[1, 4] == c && etatJeu.Grille[2, 5] == c && etatJeu.Grille[3, 6] == c ||
        etatJeu.Grille[0, 3] == c && etatJeu.Grille[1, 2] == c && etatJeu.Grille[2, 1] == c && etatJeu.Grille[3, 0] == c ||
        etatJeu.Grille[0, 4] == c && etatJeu.Grille[1, 4] == c && etatJeu.Grille[2, 2] == c && etatJeu.Grille[3, 1] == c ||
        etatJeu.Grille[0, 5] == c && etatJeu.Grille[1, 3] == c && etatJeu.Grille[2, 3] == c && etatJeu.Grille[3, 2] == c ||
        etatJeu.Grille[0, 6] == c && etatJeu.Grille[1, 5] == c && etatJeu.Grille[2, 4] == c && etatJeu.Grille[3, 3] == c;
    
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
