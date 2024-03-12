using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.Communs.Joueurs;
using MorpionApp.Jeux.Structures;
using MorpionApp.Jeux.Morpion;

namespace MorpionAppTests.Jeux.MorpionTests
{
    public class ComportementMorpionTests
    {
        [Trait("ComportementMorpion", "EffectuerAction")]
        [Fact]
        public void EffectuerAction_AvecCasesVides()
        {
            var comportement = new ComportementMorpion();
            var etatJeu = new EtatJeu(3, 3);
            var joueur = new JoueurHumain('X');
            var position = new Position(0, 0);
            
            var result = comportement.EffectuerAction(etatJeu, joueur, position);
            
            Assert.True(result);
            Assert.Equal(joueur.Symbol, etatJeu.Grille[position.Row, position.Column]);
        }

        [Trait("ComportementMorpion", "EffectuerAction")]
        [Fact]
        public void EffectuerAction_AvecCasesOccupees()
        {
            var comportement = new ComportementMorpion();
            var etatJeu = new EtatJeu(3, 3);
            var joueur = new JoueurHumain('X');
            var position = new Position(0, 0);
            etatJeu.Grille[position.Row, position.Column] = 'O';
            
            var result = comportement.EffectuerAction(etatJeu, joueur, position);
            
            Assert.False(result);
            Assert.NotEqual(joueur.Symbol, etatJeu.Grille[position.Row, position.Column]);
        }

        [Trait("ComportementMorpion", "VerifVictoire")]
        [Fact]
        public void VerifVictoire_AvecVictoire()
        {
            var comportement = new ComportementMorpion();
            var etatJeu = new EtatJeu(3, 3);
            var joueur = new JoueurHumain('X');
            for (int i = 0; i < 3; i++)
            {
                etatJeu.Grille[i, 0] = joueur.Symbol;
            }
            
            var result = comportement.VerifVictoire(etatJeu, joueur);
            
            Assert.True(result);
        }
        
        [Trait("ComportementMorpion", "VerifVictoire")]
        [Fact]
        public void VerifVictoire_SansVictoire()
        {
            var comportement = new ComportementMorpion();
            var etatJeu = new EtatJeu(3, 3);
            var joueur = new JoueurHumain('X');
            
            var result = comportement.VerifVictoire(etatJeu, joueur);
            
            Assert.False(result);
        }

        [Trait("ComportementMorpion", "VerifEgalite")]
        [Fact]
        public void VerifEgalite_AvecGrillePleine()
        {
            var comportement = new ComportementMorpion();
            var etatJeu = new EtatJeu(3, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    etatJeu.Grille[i, j] = 'X';
                }
            }
            
            var result = comportement.VerifEgalite(etatJeu);
            
            Assert.True(result);
        }

        [Trait("ComportementMorpion", "VerifEgalite")]
        [Fact]
        public void VerifEgalite_AvecGrilleNonPleine()
        {
            var comportement = new ComportementMorpion();
            var etatJeu = new EtatJeu(3, 3);
            
            var result = comportement.VerifEgalite(etatJeu);
            
            Assert.False(result);
        }
    }
}