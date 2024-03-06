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
        // Pas encore implémenté
    }


}