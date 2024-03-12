using MorpionApp.Jeux.Communs;

namespace MorpionApp.Jeux.Morpion
{
    public class Morpion
    {
        private readonly EtatJeu etatJeu;

        public Morpion()
        {
            etatJeu = new EtatJeu(3, 3);
        }
    }
}
