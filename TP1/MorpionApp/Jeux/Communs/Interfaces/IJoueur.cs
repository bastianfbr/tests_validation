using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Structures;

namespace MorpionApp.Jeux.Communs.Interfaces
{
    public interface IJoueur
    {
        char Symbol { get; }
        Position JouerTour(EtatJeu etatJeu, IComportementJeu comportementJeu);
    }
}