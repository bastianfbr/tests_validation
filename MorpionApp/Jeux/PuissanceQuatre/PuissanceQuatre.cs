using MorpionApp.Jeux.Communs;

namespace MorpionApp.Jeux.PuissanceQuatre
{
    public class PuissanceQuatre
    {
        public readonly EtatJeu etatJeu;

        public PuissanceQuatre()
        {
            etatJeu = new EtatJeu(4, 7);
        }

    }
}
