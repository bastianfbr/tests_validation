using MorpionApp;

namespace MorpionAppTests
{
    public class VerifVictoireTests : IDisposable
    {
        private Morpion jeu;

        public VerifVictoireTests()
        {
            jeu = new Morpion();
        }

        public void Dispose()
        {
            // Non nécessaire, mais on peut ajouter du code ici pour nettoyer après chaque test
        }

        private void SetupAndAssertVictoire(char joueur, params (int, int)[] positions)
        {
            foreach (var (row, col) in positions)
            {
                jeu.grille[row, col] = joueur;
            }

            bool resultat = jeu.verifVictoire(joueur);
            Assert.True(resultat, $"Le joueur '{joueur}' devrait gagner avec les positions {string.Join(", ", positions)}");
        }

        [Fact]
        [Trait("Category", "victoireXColonnes")]
        public void VictoireXSurColonnes()
        {
            SetupAndAssertVictoire('X', (0, 0), (1, 0), (2, 0));
            SetupAndAssertVictoire('X', (0, 1), (1, 1), (2, 1));
            SetupAndAssertVictoire('X', (0, 2), (1, 2), (2, 2));
        }

        [Fact]
        [Trait("Category", "victoireXLignes")]
        public void VictoireXSurLignes()
        {
            SetupAndAssertVictoire('X', (0, 0), (0, 1), (0, 2));
            SetupAndAssertVictoire('X', (1, 0), (1, 1), (1, 2));
            SetupAndAssertVictoire('X', (2, 0), (2, 1), (2, 2));
        }

        [Fact]
        [Trait("Category", "victoireXDiagonales")]
        public void VictoireXSurDiagonales()
        {
            SetupAndAssertVictoire('X', (0, 0), (1, 1), (2, 2));
            SetupAndAssertVictoire('X', (0, 2), (1, 1), (2, 0));
        }

        [Fact]
        [Trait("Category", "victoireOColonnes")]
        public void VictoireOSurColonnes()
        {
            SetupAndAssertVictoire('O', (0, 0), (1, 0), (2, 0));
            SetupAndAssertVictoire('O', (0, 1), (1, 1), (2, 1));
            SetupAndAssertVictoire('O', (0, 2), (1, 2), (2, 2));
        }

        [Fact]
        [Trait("Category", "victoireOLignes")]
        public void VictoireOSurLignes()
        {
            SetupAndAssertVictoire('O', (0, 0), (0, 1), (0, 2));
            SetupAndAssertVictoire('O', (1, 0), (1, 1), (1, 2));
            SetupAndAssertVictoire('O', (2, 0), (2, 1), (2, 2));
        }

        [Fact]
        [Trait("Category", "victoireODiagonales")]
        public void VictoireOSurDiagonales()
        {
            SetupAndAssertVictoire('O', (0, 0), (1, 1), (2, 2));
            SetupAndAssertVictoire('O', (0, 2), (1, 1), (2, 0));
        }
    }
}
