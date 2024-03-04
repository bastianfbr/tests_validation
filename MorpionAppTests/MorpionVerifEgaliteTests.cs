using MorpionApp;

namespace MorpionAppTests
{
    public class MorpionVerifEgaliteTests : IDisposable
    {
        private Morpion jeu;

        public MorpionVerifEgaliteTests()
        {
            jeu = new Morpion();
        }

        public void Dispose()
        {
            // Non nécessaire, mais on peut ajouter du code ici pour nettoyer après chaque test
        }

        private void SetupGrilleEtAssertEgalite(char[,] grille)
        {
            jeu.grille = grille;
            bool resultat = jeu.verifEgalite();
            Assert.True(resultat, "La partie devrait se terminer sur une égalité.");
        }

        [Fact]
        [Trait("Category", "verifEgalite")]
        public void EgaliteScenario1()
        {
            char[,] grille = {
                { 'X', 'O', 'X'},
                { 'O', 'X', 'O'},
                { 'X', 'O', 'X'}
            };
            SetupGrilleEtAssertEgalite(grille);
        }

        [Fact]
        [Trait("Category", "verifEgalite")]
        public void EgaliteScenario2()
        {
            char[,] grille = {
                { 'O', 'X', 'O'},
                { 'X', 'O', 'X'},
                { 'O', 'X', 'O'}
            };
            SetupGrilleEtAssertEgalite(grille);
        }

        [Fact]
        [Trait("Category", "verifEgalite")]
        public void EgaliteScenario3()
        {
            char[,] grille = {
                { 'X', 'O', 'X'},
                { 'O', 'X', 'O'},
                { 'X', 'X', 'O'}
            };
            SetupGrilleEtAssertEgalite(grille);
        }
    }
}