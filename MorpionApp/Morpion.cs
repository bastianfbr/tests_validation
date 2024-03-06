using MorpionApp.Interfaces;

namespace MorpionApp
{
    public class Morpion : IJeu
    {
        private EtatJeu etatJeu;
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;

        public Morpion()
        {
            etatJeu = new EtatJeu(3, 3);
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
                        if (column >= 2)
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
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
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
                        if (column >= 2)
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
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
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
            Console.WriteLine($" {etatJeu.Grille[0, 0]}  |  {etatJeu.Grille[0, 1]}  |  {etatJeu.Grille[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {etatJeu.Grille[1, 0]}  |  {etatJeu.Grille[1, 1]}  |  {etatJeu.Grille[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {etatJeu.Grille[2, 0]}  |  {etatJeu.Grille[1, 1]}  |  {etatJeu.Grille[0, 2]}");
        }

        public bool verifVictoire(char c) =>
            etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 0] == c && etatJeu.Grille[2, 0] == c ||
            etatJeu.Grille[0, 1] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 1] == c ||
            etatJeu.Grille[0, 2] == c && etatJeu.Grille[1, 2] == c && etatJeu.Grille[2, 2] == c ||
            etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 2] == c ||
            etatJeu.Grille[1, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[1, 2] == c ||
            etatJeu.Grille[2, 0] == c && etatJeu.Grille[2, 1] == c && etatJeu.Grille[2, 2] == c ||
            etatJeu.Grille[0, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[2, 2] == c ||
            etatJeu.Grille[2, 0] == c && etatJeu.Grille[1, 1] == c && etatJeu.Grille[0, 2] == c;

        public bool verifEgalite() =>
            etatJeu.Grille[0, 0] != ' ' && etatJeu.Grille[1, 0] != ' ' && etatJeu.Grille[2, 0] != ' ' &&
            etatJeu.Grille[0, 1] != ' ' && etatJeu.Grille[1, 1] != ' ' && etatJeu.Grille[2, 1] != ' ' &&
            etatJeu.Grille[0, 2] != ' ' && etatJeu.Grille[1, 2] != ' ' && etatJeu.Grille[2, 2] != ' ';


        public void finPartie(string msg)
        {
            Console.Clear();
            etatJeu.AfficherGrille();
            Console.WriteLine(msg);
        }
    }
}
