using MorpionApp.Interfaces;
using MorpionApp.Structures;

namespace MorpionApp.Jeux.Joueurs
{
    public class JoueurHumain : IJoueur
    {
        public char Symbol { get; private set; }

        public JoueurHumain(char symbol)
        {
            Symbol = symbol;
        }

        public Position JouerTour(EtatJeu etatJeu, IComportementJeu comportementJeu)
        {
            return comportementJeu.ObtenirEntreeUtilisateur(etatJeu);
        }
    }
}