namespace MorpionApp.Interfaces
{
    public interface IJeuFabrique
    {
        (EtatJeu etatJeu, IComportementJeu comportementJeu) CreerConfigurationJeu(ConsoleKey key);
    }
}