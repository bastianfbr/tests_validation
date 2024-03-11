using MorpionApp.Interfaces;
using MorpionApp.Jeux.Joueurs;

namespace MorpionApp
{
    public class ControleurDeJeu
    {
        private readonly EtatJeu etatJeu;
        private readonly IComportementJeu comportementJeu;

        private readonly IJoueur joueur1;
        private readonly IJoueur joueur2;

        public ControleurDeJeu(EtatJeu etatJeu, IComportementJeu comportementJeu, bool jouerContreIA)
        {
            this.etatJeu = etatJeu;
            this.comportementJeu = comportementJeu;

            joueur1 = new JoueurHumain('X');
            joueur2 = jouerContreIA ? (IJoueur)new JoueurIA('O') : new JoueurHumain('O');
        }

        public void DemarrerJeu()
        {
            bool quitterJeu = false;
            IJoueur joueurActuel = joueur1;

            while (!quitterJeu)
            {
                etatJeu.InitialiserGrille();
                bool partieTerminee = false;

                while (!partieTerminee && !quitterJeu)
                {
                    Console.Clear();
                    etatJeu.AfficherGrille();
                    Console.WriteLine($"C'est au tour du joueur {joueurActuel.Symbol}. Veuillez choisir une case.");

                    partieTerminee = EffectuerTour(joueurActuel);

                    joueurActuel = (joueurActuel.Symbol == 'X') ? joueur2 : joueur1;
                }

                if (partieTerminee)
                {
                    Console.Clear();
                    etatJeu.AfficherGrille();
                    if (comportementJeu.VerifVictoire(etatJeu, (joueurActuel.Symbol == joueur1.Symbol ? joueur2 : joueur1)))
                    {
                        Console.WriteLine($"Le joueur {(joueurActuel.Symbol == joueur1.Symbol ? joueur2 : joueur1).Symbol} a gagné !");
                    }
                    else if (comportementJeu.VerifEgalite(etatJeu))
                    {
                        Console.WriteLine("La partie se termine par une égalité !");
                    }

                    Console.WriteLine("Appuyez sur [N] pour une nouvelle partie, sur [Q] pour quitter.");

                    bool choixValide = false;
                    while (!choixValide)
                    {
                        var key = Console.ReadKey(true).Key;
                        switch (key)
                        {
                            case ConsoleKey.N:
                                Console.Clear();
                                choixValide = true;
                                break;
                            case ConsoleKey.Q:
                                quitterJeu = true;
                                choixValide = true;
                                break;
                            default:
                                Console.WriteLine("Entrée invalide. Veuillez appuyer sur [N] pour une nouvelle partie ou sur [Q] pour quitter.");
                                break;
                        }
                    }
                }


            }
        }

        private bool EffectuerTour(IJoueur joueur)
        {
            bool coupValide = false;

            while (!coupValide)
            {
                Console.Clear();
                etatJeu.AfficherGrille();
                Console.WriteLine($"C'est au tour du joueur {joueur}. Veuillez choisir une case.");

                var position = joueur.JouerTour(etatJeu, comportementJeu);
                coupValide = comportementJeu.EffectuerAction(etatJeu, joueur, position);
                if (!coupValide)
                {
                    Console.WriteLine("Coup invalide, veuillez réessayer.");
                    Console.ReadKey(true);
                }
                else
                {
                    if (comportementJeu.VerifVictoire(etatJeu, joueur))
                    {
                        Console.WriteLine($"Le joueur {joueur} a gagné !");
                        return true;
                    }
                    else if (comportementJeu.VerifEgalite(etatJeu))
                    {
                        Console.WriteLine("La partie se termine par une égalité !");
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
