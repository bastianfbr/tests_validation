using System;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
                LancerJeu(ChoisirJeu());
                Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");
            } while (Console.ReadKey(true).Key == ConsoleKey.R);
        }

        private static ConsoleKey ChoisirJeu()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.X && key != ConsoleKey.P);

            return key;
        }

        private static void LancerJeu(ConsoleKey choix)
        {
            switch (choix)
            {
                case ConsoleKey.X:
                    Morpion morpion = new Morpion();
                    morpion.BoucleJeu();
                    break;
                case ConsoleKey.P:
                    PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
                    puissanceQuatre.BoucleJeu();
                    break;
            }
        }
    }
}
