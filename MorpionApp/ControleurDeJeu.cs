using MorpionApp.Interfaces;

namespace MorpionApp
{
    public class ControleurDeJeu
    {
        private EtatJeu etatJeu;
        private IComportementJeu comportementJeu;
        
        public ControleurDeJeu(EtatJeu etatJeu, IComportementJeu comportementJeu)
        {
            this.etatJeu = etatJeu;
            this.comportementJeu = comportementJeu;
        }

        public void DemarrerJeu()
        {
            bool quitterJeu = false;
            char joueurActuel = 'X';

            while (!quitterJeu)
            {
                etatJeu.InitialiserGrille();
                bool partieTerminee = false;

                while (!partieTerminee && !quitterJeu)
                {
                    Console.Clear();
                    etatJeu.AfficherGrille();
                    Console.WriteLine($"C'est au tour du joueur {joueurActuel}. Veuillez choisir une case.");

                    partieTerminee = JouerTour(joueurActuel);
                    
                    joueurActuel = (joueurActuel == 'X') ? 'O' : 'X';
                }

                if (partieTerminee)
                {
                    Console.Clear();
                    etatJeu.AfficherGrille();
                    if (comportementJeu.VerifVictoire(etatJeu, (joueurActuel == 'X' ? 'O' : 'X')))
                    {
                        Console.WriteLine($"Le joueur {(joueurActuel == 'X' ? 'O' : 'X')} a gagné !");
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

        private bool JouerTour(char joueur)
        {
            bool coupValide = false;
    
            while (!coupValide)
            {
                Console.Clear();
                etatJeu.AfficherGrille();
                Console.WriteLine($"C'est au tour du joueur {joueur}. Veuillez choisir une case.");
                
                var (row, col) = comportementJeu.ObtenirEntreeUtilisateur(etatJeu);

                coupValide = comportementJeu.EffectuerAction(etatJeu, joueur, ref row, ref col);
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
