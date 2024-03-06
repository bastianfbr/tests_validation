using MorpionApp.Interfaces;

namespace MorpionApp
{
    public class PuissanceQuatre : IJeu
    {
        private EtatJeu etatJeu;
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;

    public PuissanceQuatre()
    {
        etatJeu = new EtatJeu(4, 7);
    }

    public void BoucleJeu()
    {
        while (!quiterJeu)
        {
            etatJeu.InitialiserGrille();
            while (!quiterJeu)
            {
                if (tourDuJoueur)
                {
                    tourJoueur();
                    if (verifVictoire('X'))
                    {
                        finPartie("Le joueur 1 à gagné !");
                        break;
                    }
                }
                else
                {
                    tourJoueur2();
                    if (verifVictoire('O'))
                    {
                        finPartie("Le joueur 2 à gagné !");
                        break;
                    }
                }

                tourDuJoueur = !tourDuJoueur;
                if (verifEgalite())
                {
                    finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                    break;
                }
            }

            if (!quiterJeu)
            {
                Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;
                    default:
                        goto GetKey;
                }
            }

        }
    }

    public void tourJoueur()
    {
        var (row, column) = (0, 0);
        bool moved = false;

        while (!quiterJeu && !moved)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine();
            Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
            Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    quiterJeu = true;
                    Console.Clear();
                    break;

                case ConsoleKey.RightArrow:
                    if (column >= 6)
                    {
                        column = 0;
                    }
                    else
                    {
                        column = column + 1;
                    }

                    break;

                case ConsoleKey.LeftArrow:
                    if (column <= 0)
                    {
                        column = 6;
                    }
                    else
                    {
                        column = column - 1;
                    }

                    break;
                
                case ConsoleKey.Enter:
                    while (row <= 3)
                    {
                        row = row + 1;
                        if (row >= 3)
                        {
                            break;
                        }
                    }

                    while (etatJeu.Grille[row, column] is 'X' or 'O')
                    {
                        if (row == 0)
                        {
                            break;
                        }

                        row = row - 1;
                    }

                    if (etatJeu.Grille[row, column] is ' ')
                    {
                        etatJeu.Grille[row, column] = 'X';
                        moved = true;
                        quiterJeu = false;
                    }

                    break;
            }

        }
    }

    public void tourJoueur2()
    {
        var (row, column) = (0, 0);
        bool moved = false;

        while (!quiterJeu && !moved)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine();
            Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
            Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    quiterJeu = true;
                    Console.Clear();
                    break;

                case ConsoleKey.RightArrow:
                    if (column >= 6)
                    {
                        column = 0;
                    }
                    else
                    {
                        column = column + 1;
                    }

                    break;

                case ConsoleKey.LeftArrow:
                    if (column <= 0)
                    {
                        column = 6;
                    }
                    else
                    {
                        column = column - 1;
                    }

                    break;
                
                case ConsoleKey.Enter:
                    while (row <= 3)
                    {
                        row = row + 1;
                        if (row >= 3)
                        {
                            break;
                        }
                    }

                    while (etatJeu.Grille[row, column] is 'X' or 'O')
                    {
                        if (row == 0)
                        {
                            break;
                        }

                        row = row - 1;
                    }

                    if (etatJeu.Grille[row, column] is ' ')
                    {
                        etatJeu.Grille[row, column] = 'O';
                        moved = true;
                        quiterJeu = false;
                    }

                    break;
            }
        }
    }

    public void affichePlateau()
    {
        Console.WriteLine();
        Console.WriteLine(
            $" {etatJeu.Grille[0, 0]}  |  {etatJeu.Grille[0, 1]}  |  {etatJeu.Grille[0, 2]}  |  {etatJeu.Grille[0, 3]}  |  {etatJeu.Grille[0, 4]}  |  {etatJeu.Grille[0, 5]}  |  {etatJeu.Grille[0, 6]}");
        Console.WriteLine("    |     |     |     |     |     |");
        Console.WriteLine("----+-----+-----+-----+-----+-----+----");
        Console.WriteLine("    |     |     |     |     |     |");
        Console.WriteLine(
            $" {etatJeu.Grille[1, 0]}  |  {etatJeu.Grille[1, 1]}  |  {etatJeu.Grille[1, 2]}  |  {etatJeu.Grille[1, 3]}  |  {etatJeu.Grille[1, 4]}  |  {etatJeu.Grille[1, 5]}  |  {etatJeu.Grille[1, 6]}");
        Console.WriteLine("    |     |     |     |     |     |");
        Console.WriteLine("----+-----+-----+-----+-----+-----+----");
        Console.WriteLine("    |     |     |     |     |     |");
        Console.WriteLine(
            $" {etatJeu.Grille[2, 0]}  |  {etatJeu.Grille[2, 1]}  |  {etatJeu.Grille[2, 2]}  |  {etatJeu.Grille[2, 3]}  |  {etatJeu.Grille[2, 4]}  |  {etatJeu.Grille[2, 5]}  |  {etatJeu.Grille[1, 6]}");
        Console.WriteLine("    |     |     |     |     |     |");
        Console.WriteLine("----+-----+-----+-----+-----+-----+----");
        Console.WriteLine("    |     |     |     |     |     |");
        Console.WriteLine(
            $" {etatJeu.Grille[3, 0]}  |  {etatJeu.Grille[3, 1]}  |  {etatJeu.Grille[3, 2]}  |  {etatJeu.Grille[3, 3]}  |  {etatJeu.Grille[3, 4]}  |  {etatJeu.Grille[3, 5]}  |  {etatJeu.Grille[1, 6]}");
        Console.WriteLine("    |     |     |     |     |     |");
        Console.WriteLine("----+-----+-----+-----+-----+-----+----");
    }

    public bool verifVictoire(char c) =>
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

    public bool verifEgalite() =>
        etatJeu.Grille[0, 0] != ' ' && etatJeu.Grille[0, 1] != ' ' && etatJeu.Grille[0, 2] != ' ' && etatJeu.Grille[0, 3] != ' ' &&
        etatJeu.Grille[0, 4] != ' ' && etatJeu.Grille[0, 5] != ' ' && etatJeu.Grille[0, 6] != ' ' &&
        etatJeu.Grille[1, 0] != ' ' && etatJeu.Grille[1, 1] != ' ' && etatJeu.Grille[1, 2] != ' ' && etatJeu.Grille[1, 3] != ' ' &&
        etatJeu.Grille[1, 4] != ' ' && etatJeu.Grille[1, 5] != ' ' && etatJeu.Grille[1, 6] != ' ' &&
        etatJeu.Grille[2, 0] != ' ' && etatJeu.Grille[2, 1] != ' ' && etatJeu.Grille[1, 2] != ' ' && etatJeu.Grille[2, 3] != ' ' &&
        etatJeu.Grille[2, 4] != ' ' && etatJeu.Grille[2, 5] != ' ' && etatJeu.Grille[2, 6] != ' ' &&
        etatJeu.Grille[3, 0] != ' ' && etatJeu.Grille[3, 1] != ' ' && etatJeu.Grille[3, 2] != ' ' && etatJeu.Grille[3, 3] != ' ' &&
        etatJeu.Grille[3, 4] != ' ' && etatJeu.Grille[3, 5] != ' ' && etatJeu.Grille[3, 5] != ' ';


    public void finPartie(string msg)
    {
        Console.Clear();
        affichePlateau();
        Console.WriteLine(msg);
    }
    }
}
