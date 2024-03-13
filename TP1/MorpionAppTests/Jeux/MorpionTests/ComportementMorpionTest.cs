using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.Communs.Joueurs;
using MorpionApp.Jeux.Morpion;
using MorpionApp.Jeux.Structures;

namespace MorpionAppTests
{
    public class ComportementMorpionTest
    {
        private readonly ComportementMorpion comportementMorpion;
        private readonly EtatJeu etatJeu;
        private readonly JoueurHumain joueurX;

        public ComportementMorpionTest()
        {
            comportementMorpion = new ComportementMorpion();
            etatJeu = new EtatJeu(3, 3);
            joueurX = new JoueurHumain('X');
        }
        
        private void SetupAndAssertVictoire(char symbol, params (int, int)[] positions)
        {
            etatJeu.InitialiserGrille();
            foreach (var (row, col) in positions)
            {
                etatJeu.Grille[row, col] = symbol;
            }
            bool result = comportementMorpion.VerifVictoire(etatJeu, new JoueurHumain(symbol));
            Assert.True(result, $"La victoire de {symbol} était attendue");
        }

        private void SetupGrillePleineEtAssertEgalite(char[,] grille)
        {
            etatJeu.Grille = grille;
            bool result = comportementMorpion.VerifEgalite(etatJeu);
            Assert.True(result, "L'égalité était attendue");
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(1, 1, true)]
        [InlineData(0, 0, false)]
        [Trait("ComportementMorpion", "EffectuerAction")]
        public void EffectuerActionTests(int row, int col, bool resultat)
        {
            var position = new Position(row, col);
            if (!resultat)
            {
                etatJeu.Grille[position.Row, position.Column] = joueurX.Symbol;
            }
            var result = comportementMorpion.EffectuerAction(etatJeu, joueurX, position);
            Assert.Equal(resultat, result);
            if (resultat)
            {
                Assert.Equal(joueurX.Symbol, etatJeu.Grille[position.Row, position.Column]);
            }
            etatJeu.InitialiserGrille();
        }

        [Fact]
        [Trait("ComportementMorpion", "VerifVictoire")]
        public void VictoireSurColonnes()
        {
            SetupAndAssertVictoire(joueurX.Symbol, (0, 0), (1, 0), (2, 0));
            SetupAndAssertVictoire(joueurX.Symbol, (0, 1), (1, 1), (2, 1));
            SetupAndAssertVictoire(joueurX.Symbol, (0, 2), (1, 2), (2, 2));
        }

        [Fact]
        [Trait("ComportementMorpion", "VerifVictoire")]
        public void VictoireSurLignes()
        {
            SetupAndAssertVictoire(joueurX.Symbol, (0, 0), (0, 1), (0, 2));
            SetupAndAssertVictoire(joueurX.Symbol, (1, 0), (1, 1), (1, 2));
            SetupAndAssertVictoire(joueurX.Symbol, (2, 0), (2, 1), (2, 2));
        }

        [Fact]
        [Trait("ComportementMorpion", "VerifVictoire")]
        public void VictoireSurDiagonales()
        {
            SetupAndAssertVictoire(joueurX.Symbol, (0, 0), (1, 1), (2, 2));
            SetupAndAssertVictoire(joueurX.Symbol, (0, 2), (1, 1), (2, 0));
        }

        [Fact]
        [Trait("ComportementMorpion", "VerifEgalite")]
        public void EgaliteTests()
        {
            SetupGrillePleineEtAssertEgalite(new char[,] {
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' },
                { 'X', 'O', 'X' }
            });

            SetupGrillePleineEtAssertEgalite(new char[,] {
                { 'O', 'X', 'O' },
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' }
            });

            SetupGrillePleineEtAssertEgalite(new char[,] {
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' },
                { 'X', 'X', 'O' }
            });
        }
    }
}
