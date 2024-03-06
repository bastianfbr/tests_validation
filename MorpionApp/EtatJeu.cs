namespace MorpionApp;

public class EtatJeu
{
    public char[,] Grille { get; private set; }

    public EtatJeu(int lignes, int colonnes)
    {
        Grille = new char[lignes, colonnes];
        InitialiserGrille();
    }

    public void InitialiserGrille()
    {
        for (int i = 0; i < Grille.GetLength(0); i++)
        {
            for (int j = 0; j < Grille.GetLength(1); j++)
            {
                Grille[i, j] = ' ';
            }
        }
    }

    public void AfficherGrille()
    {
        for (int i = 0; i < Grille.GetLength(0); i++)
        {
            for (int j = 0; j < Grille.GetLength(1); j++)
            {
                Console.Write(" ");
                Console.Write(Grille[i, j]);
                Console.Write(" ");
                if (j < Grille.GetLength(1) - 1)
                {
                    Console.Write(" | ");
                }
            }

            Console.WriteLine();

            string separator = "----";
            for (int col = 2; col < Grille.GetLength(1); col++)
            {
                separator += "+-----";
            }
            separator += (Grille.GetLength(1) == 7) ? "+----" : "+----";

            if (i < Grille.GetLength(0) - 1)
            {
                Console.WriteLine(separator);
            }

        }
    }
}