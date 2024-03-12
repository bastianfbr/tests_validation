using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Structures;

namespace MorpionApp.Jeux.Communs.Joueurs
{
    public class JoueurIA : IJoueur
    {
        public char Symbol { get; private set; }

        public JoueurIA(char symbol)
        {
            Symbol = symbol;
        }

        public Position JouerTour(EtatJeu etatJeu, IComportementJeu comportementJeu)
        {
            Random rnd = new Random();
            int row, col;
            do
            {
                row = rnd.Next(etatJeu.Grille.GetLength(0));
                col = rnd.Next(etatJeu.Grille.GetLength(1));
            } while (etatJeu.Grille[row, col] != ' ');

            return new Position(row, col);
        }
    }
}