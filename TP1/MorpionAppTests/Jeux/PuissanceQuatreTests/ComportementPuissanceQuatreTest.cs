using Xunit;
using MorpionApp.Jeux.PuissanceQuatre;
using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.Communs.Joueurs;
using MorpionApp.Jeux.Structures;

namespace MorpionAppTests
{
    public class ComportementPuissanceQuatreTest
    {
        private readonly ComportementPuissanceQuatre comportementPuissanceQuatre;
        private readonly EtatJeu etatJeu;
        private readonly JoueurHumain joueurX;

        public ComportementPuissanceQuatreTest()
        {
            comportementPuissanceQuatre = new ComportementPuissanceQuatre();
            etatJeu = new EtatJeu(6, 7);
            joueurX = new JoueurHumain('X');
        }
        
        private void SetupAndAssertVictoire(char symbol, params (int, int)[] positions)
        {
            etatJeu.InitialiserGrille();
            foreach (var (row, col) in positions)
            {
                for (int fillRow = etatJeu.Grille.GetLength(0) - 1; fillRow >= row; fillRow--)
                {
                    etatJeu.Grille[fillRow, col] = symbol;
                }
            }
            bool result = comportementPuissanceQuatre.VerifVictoire(etatJeu, new JoueurHumain(symbol));
            Assert.True(result, $"La victoire de {symbol} était attendue avec les positions {string.Join(", ", positions)}");
        }

        private void SetupGrillePleineEtAssertEgalite(char[,] grille)
        {
            etatJeu.Grille = grille;
            bool result = comportementPuissanceQuatre.VerifEgalite(etatJeu);
            Assert.True(result, "L'égalité était attendue avec la grille pleine");
        }

        [Theory]
        [InlineData(5, 0, true)]
        [InlineData(5, 0, false)]
        [Trait("ComportementPuissanceQuatre", "EffectuerAction")]
        public void EffectuerActionTests(int row, int col, bool expectedSuccess)
        {
            var position = new Position(row, col);
            var result = comportementPuissanceQuatre.EffectuerAction(etatJeu, joueurX, position);
            Assert.Equal(expectedSuccess, result);
            if (expectedSuccess)
            {
                int lowestEmptyRow = etatJeu.Grille.GetLength(0) - 1;
                while (lowestEmptyRow >= 0 && etatJeu.Grille[lowestEmptyRow, col] != ' ')
                {
                    lowestEmptyRow--;
                }
                Assert.Equal(joueurX.Symbol, etatJeu.Grille[lowestEmptyRow + 1, col]);
            }
            etatJeu.InitialiserGrille();
        }

        [Fact]
        [Trait("ComportementPuissanceQuatre", "VerifVictoire")]
        public void VictoireHorizontale()
        {
            SetupAndAssertVictoire(joueurX.Symbol, (5, 0), (5, 1), (5, 2), (5, 3));
        }

        [Fact]
        [Trait("ComportementPuissanceQuatre", "VerifVictoire")]
        public void VictoireVerticale()
        {
            SetupAndAssertVictoire(joueurX.Symbol, (3, 0), (4, 0), (5, 0), (2, 0));
        }

        [Fact]
        [Trait("ComportementPuissanceQuatre", "VerifVictoire")]
        public void VictoireDiagonaleDroite()
        {
            SetupAndAssertVictoire(joueurX.Symbol, (2, 0), (3, 1), (4, 2), (5, 3));
        }

        [Fact]
        [Trait("ComportementPuissanceQuatre", "VerifVictoire")]
        public void VictoireDiagonaleGauche()
        {
            SetupAndAssertVictoire(joueurX.Symbol, (5, 3), (4, 2), (3, 1), (2, 0));
        }

        [Fact]
        [Trait("ComportementPuissanceQuatre", "VerifEgalite")]
        public void EgaliteTests()
        {
            char[,] grillePleine = new char[6, 7];
            for (int i = 0; i < grillePleine.GetLength(0); i++)
            {
                for (int j = 0; j < grillePleine.GetLength(1); j++)
                {
                    grillePleine[i, j] = (j % 2 == 0) ? 'X' : 'O';
                }
            }
            SetupGrillePleineEtAssertEgalite(grillePleine);
        }
        
    }
}
