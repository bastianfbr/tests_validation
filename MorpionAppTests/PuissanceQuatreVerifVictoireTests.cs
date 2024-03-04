using MorpionApp;

namespace MorpionAppTests
{
    public class PuissanceQuatreVerifVictoireTests : IDisposable
    {
        private PuissanceQuatre jeu;

        public PuissanceQuatreVerifVictoireTests()
        {
            jeu = new PuissanceQuatre();
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
            Assert.True(resultat, $"Le joueur '{joueur}' devrait gagner avec les positions: {string.Join(", ", positions.Select(p => $"({p.Item1},{p.Item2})"))}");
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireXVerticale()
        {
            SetupAndAssertVictoire('X', (0, 0), (1, 0), (2, 0), (3, 0));
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireXHorizontale()
        {
            SetupAndAssertVictoire('X', (0, 0), (0, 1), (0, 2), (0, 3));
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireXDiagonaleAscendante()
        {
            SetupAndAssertVictoire('X', (3, 0), (2, 1), (1, 2), (0, 3));
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireXDiagonaleDescendante()
        {
            SetupAndAssertVictoire('X', (0, 0), (1, 1), (2, 2), (3, 3));
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireOVerticale()
        {
            SetupAndAssertVictoire('O', (0, 1), (1, 1), (2, 1), (3, 1));
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireOHorizontale()
        {
            SetupAndAssertVictoire('O', (1, 0), (1, 1), (1, 2), (1, 3));
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireODiagonaleAscendante()
        {
            SetupAndAssertVictoire('O', (3, 1), (2, 2), (1, 3), (0, 4));
        }

        [Fact]
        [Trait("Category", "victoirePuissanceQuatre")]
        public void VictoireODiagonaleDescendante()
        {
            SetupAndAssertVictoire('O', (0, 1), (1, 2), (2, 3), (3, 4));
        }
    }
}
