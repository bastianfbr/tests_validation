using MorpionApp;
using Xunit;

namespace MorpionAppTests
{
    public class PuissanceQuatreVerifEgaliteTests : IDisposable
    {
        private PuissanceQuatre jeu;

        public PuissanceQuatreVerifEgaliteTests()
        {
            jeu = new PuissanceQuatre();
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
            char[,] grille = new char[4, 7]
            {
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O' }
            };
            SetupGrilleEtAssertEgalite(grille);
        }

        [Fact]
        [Trait("Category", "verifEgalite")]
        public void EgaliteScenario2()
        {
            char[,] grille = new char[4, 7]
            {
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' }
            };
            SetupGrilleEtAssertEgalite(grille);
        }
        
        [Fact]
        [Trait("Category", "verifEgalite")]
        public void EgaliteScenario3()
        {
            char[,] grille = new char[4, 7]
            {
                { 'X', 'X', 'O', 'O', 'X', 'O', 'X' },
                { 'O', 'O', 'X', 'X', 'O', 'X', 'O' },
                { 'X', 'X', 'O', 'O', 'X', 'O', 'X' },
                { 'O', 'O', 'X', 'X', 'O', 'X', 'O' }
            };
            SetupGrilleEtAssertEgalite(grille);
        }
    }
}
