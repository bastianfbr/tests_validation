using MorpionApp.Interfaces;
using MorpionApp.Jeux.Comportement;

namespace MorpionApp
{
    public class JeuFabrique : IJeuFabrique
    {
        public (EtatJeu, IComportementJeu) CreerConfigurationJeu(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.X:
                    return (new EtatJeu(3, 3), new ComportementMorpion());
                case ConsoleKey.P:
                    return (new EtatJeu(4, 7), new ComportementPuissanceQuatre());
                default:
                    throw new ArgumentException("Sélection de jeu invalide.");
            }
        }
    }
}