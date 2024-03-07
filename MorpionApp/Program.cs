using MorpionApp.Interfaces;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
                var choix = ChoisirJeu();
                LancerJeu(choix);

                bool choixValide = false;
                while (!choixValide)
                {
                    Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour rejouer. Taper [Q] pour quitter.");
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.R)
                    {
                        choixValide = true;
                    }
                    else if (key == ConsoleKey.Q)
                    {
                        choixValide = true;
                        continuer = false;
                    }
                    else
                    {
                        Console.WriteLine("Entrée invalide. Veuillez appuyer sur [R] pour rejouer ou sur [Q] pour quitter.");
                    }
                }
            }
        }


        private static ConsoleKey ChoisirJeu()
        {
            while (true)
            {
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.X:
                    case ConsoleKey.P:
                        return input;
                    default:
                        Console.WriteLine("Entrée invalide. Veuillez taper [X] pour le morpion ou [P] pour le puissance 4.");
                        break;
                }
            }
        }

        private static void LancerJeu(ConsoleKey choix)
        {
            IJeuFabrique jeuFabrique = new JeuFabrique();
            var jeuConfig = jeuFabrique.CreerConfigurationJeu(choix);
            ControleurDeJeu controleur = new ControleurDeJeu(jeuConfig.etatJeu, jeuConfig.comportementJeu);
            controleur.DemarrerJeu();
        }
    }
}