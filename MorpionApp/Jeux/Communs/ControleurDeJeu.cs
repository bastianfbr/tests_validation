using MorpionApp.Console.Interfaces;
using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Communs.Joueurs;
using MorpionApp.Sauvegarde;

namespace MorpionApp.Jeux.Communs
{
    public class ControleurDeJeu
    {
        private readonly EtatJeu etatJeu;
        private readonly IComportementJeu comportementJeu;
        private readonly IJoueur joueur1;
        private readonly IJoueur joueur2;
        private readonly IInteractionUtilisateur interactionUtilisateur;

        public ControleurDeJeu(EtatJeu etatJeu, IComportementJeu comportementJeu, bool jouerContreIA, IInteractionUtilisateur interaction)
        {
            this.etatJeu = etatJeu;
            this.comportementJeu = comportementJeu;
            joueur1 = new JoueurHumain('X');
            joueur2 = jouerContreIA ? (IJoueur)new JoueurIA('O') : new JoueurHumain('O');
            this.interactionUtilisateur = interaction;
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
                    interactionUtilisateur.EffacerConsole();
                    interactionUtilisateur.AfficherGrille(etatJeu);
                    interactionUtilisateur.AfficherDemandeDeCoup(joueurActuel.Symbol);

                    SauvegarderEtatJeu();
                    partieTerminee = EffectuerTour(joueurActuel);

                    joueurActuel = (joueurActuel.Symbol == 'X') ? joueur2 : joueur1;
                }

                if (partieTerminee)
                {
                    File.Delete("sauvegarde.json");
                    interactionUtilisateur.EffacerConsole();
                    interactionUtilisateur.AfficherGrille(etatJeu);
                    if (comportementJeu.VerifVictoire(etatJeu, (joueurActuel.Symbol == joueur1.Symbol ? joueur2 : joueur1)))
                    {
                        interactionUtilisateur.AfficherMessage($"Le joueur {(joueurActuel.Symbol == joueur1.Symbol ? joueur2 : joueur1).Symbol} a gagné !");
                    }
                    else if (comportementJeu.VerifEgalite(etatJeu))
                    {
                        interactionUtilisateur.AfficherMessage("La partie se termine par une égalité !");
                    }

                    var choix = interactionUtilisateur.DemanderContinuerOuQuitter();
                    if (choix == ConsoleKey.Q)
                    {
                        quitterJeu = true;
                    }
                }
            }
        }

        private bool EffectuerTour(IJoueur joueur)
        {
            bool coupValide = false;
            bool partieTerminee = false;

            while (!coupValide)
            {
                interactionUtilisateur.EffacerConsole();
                interactionUtilisateur.AfficherGrille(etatJeu);
                interactionUtilisateur.AfficherDemandeDeCoup(joueur.Symbol);
                
                var position = joueur.JouerTour(etatJeu, comportementJeu);

                coupValide = comportementJeu.EffectuerAction(etatJeu, joueur, position);
                if (!coupValide)
                {
                    interactionUtilisateur.AfficherCoupInvalide();
                }
                else
                {
                    if (comportementJeu.VerifVictoire(etatJeu, joueur))
                    {
                        interactionUtilisateur.EffacerConsole();
                        interactionUtilisateur.AfficherGrille(etatJeu);
                        interactionUtilisateur.AfficherMessage($"Le joueur {joueur.Symbol} a gagné !");
                        partieTerminee = true;
                    }
                    else if (comportementJeu.VerifEgalite(etatJeu))
                    {
                        interactionUtilisateur.EffacerConsole();
                        interactionUtilisateur.AfficherGrille(etatJeu);
                        interactionUtilisateur.AfficherMessage("La partie se termine par une égalité !");
                        partieTerminee = true;
                    }
                }
            }

            return partieTerminee;
        }

        
        private void SauvegarderEtatJeu()
        {
            var sauvegarde = new SauvegardeJeu(etatJeu, comportementJeu.GetType().Name, joueur2 is JoueurIA);
            sauvegarde.Sauvegarder();
        }

    }
}
