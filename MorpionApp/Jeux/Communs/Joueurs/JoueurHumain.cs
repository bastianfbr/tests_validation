using MorpionApp.Jeux.Communs.Interfaces;
using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Structures;

namespace MorpionApp.Jeux.Communs.Joueurs
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