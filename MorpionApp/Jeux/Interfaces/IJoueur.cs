using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.Structures;

namespace MorpionApp.Jeux.Interfaces
{
    public interface IJoueur
    {
        char Symbol { get; }
        Position JouerTour(EtatJeu etatJeu, IComportementJeu comportementJeu);
    }
}