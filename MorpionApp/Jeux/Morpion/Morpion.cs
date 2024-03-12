using MorpionApp.Jeux.Communs;

namespace MorpionApp.Jeux.Morpion
{
    public class Morpion
    {
        public EtatJeu etatJeu { get; set; }

        public Morpion()
        {
            etatJeu = new EtatJeu(3, 3);
        }
    }
}
