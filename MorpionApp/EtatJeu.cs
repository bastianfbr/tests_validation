using System.Text;

namespace MorpionApp;

public class EtatJeu
{
    public char[,] Grille { get; set; }

    public EtatJeu(int lignes, int colonnes)
    {
        Grille = new char[lignes, colonnes];
        // InitialiserGrille();
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
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Grille.GetLength(0); i++)
        {
            for (int j = 0; j < Grille.GetLength(1); j++)
            {
                sb.Append(' ');
                sb.Append(Grille[i, j]);
                sb.Append(" ");
                if (j < Grille.GetLength(1) - 1)
                {
                    sb.Append(" | ");
                }
            }

            sb.AppendLine();

            string separator = "----";
            for (int col = 2; col < Grille.GetLength(1); col++)
            {
                separator += "+-----";
            }
            separator += "+----"; // Use this line consistently

            if (i < Grille.GetLength(0) - 1)
            {
                sb.AppendLine(separator);
            }
        }

        Console.Write(sb.ToString());
    }
}
