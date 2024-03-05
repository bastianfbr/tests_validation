using MorpionApp.Interfaces;

namespace MorpionApp;

public class JeuFabrique : IJeuFabrique
{
    public IJeu CreerJeu(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.X:
                return new Morpion();
            case ConsoleKey.P:
                return new PuissanceQuatre();
            default:
                throw new ArgumentException("Sélection de jeu invalide.");
        }
    }
}