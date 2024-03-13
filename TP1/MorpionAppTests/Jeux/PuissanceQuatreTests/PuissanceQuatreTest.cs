using MorpionApp.Jeux.PuissanceQuatre;
namespace MorpionAppTests.Jeux.PuissanceQuatreTests;

public class PuissanceQuatreTests
{
    [Trait("PuissanceQuatre", "Constructeur")]
    [Fact]
    public void PuissanceQuatre_Constructeur_InitialiseEtatJeu()
    {
        var puissanceQuatre = new PuissanceQuatre();
        
        Assert.NotNull(puissanceQuatre.etatJeu);
        Assert.Equal(4, puissanceQuatre.etatJeu.Grille.GetLength(0));
        Assert.Equal(7, puissanceQuatre.etatJeu.Grille.GetLength(1));
    }
}