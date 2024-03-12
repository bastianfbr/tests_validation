using MorpionApp.Jeux.Communs.Interfaces;
using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Morpion;
using MorpionApp.Jeux.PuissanceQuatre;

namespace MorpionApp.Jeux.Communs
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