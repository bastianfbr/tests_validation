using MorpionApp.Interfaces;
using MorpionApp.Jeux;

namespace MorpionApp
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = JeuConsole.ChoisirJeu();
                LancerJeu(choix);
                continuer = JeuConsole.DemanderRejouer();
            }
        }

        private static void LancerJeu(ConsoleKey choix)
        {
            IJeuFabrique jeuFabrique = new JeuFabrique();
            var jeuConfig = jeuFabrique.CreerConfigurationJeu(choix);
            ControleurDeJeu controleur = new ControleurDeJeu(jeuConfig.etatJeu, jeuConfig.comportementJeu, JeuConsole.DemanderJoueurIA());
            controleur.DemarrerJeu();
        }
    }
}