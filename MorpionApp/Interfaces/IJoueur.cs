using MorpionApp.Structures;

namespace MorpionApp.Interfaces
{
    public interface IJoueur
    {
        char Symbol { get; }
        Position JouerTour(EtatJeu etatJeu, IComportementJeu comportementJeu);
    }
}