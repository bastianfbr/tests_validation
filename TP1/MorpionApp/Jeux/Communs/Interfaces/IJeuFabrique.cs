using MorpionApp.Jeux.Interfaces;

namespace MorpionApp.Jeux.Communs.Interfaces
{
    public interface IJeuFabrique
    {
        (EtatJeu etatJeu, IComportementJeu comportementJeu) CreerConfigurationJeu(ConsoleKey key);
    }
}