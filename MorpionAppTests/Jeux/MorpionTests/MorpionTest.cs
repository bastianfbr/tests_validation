using MorpionApp.Jeux.Morpion;

namespace MorpionAppTests.Jeux.MorpionTests;

public class MorpionTests
{
    [Trait("Morpion", "Constructeur")]
    [Fact]
    public void Morpion_Constructeur_InitialiseEtatJeu()
    {
        var morpion = new Morpion();
        
        Assert.NotNull(morpion.etatJeu);
        Assert.Equal(3, morpion.etatJeu.Grille.GetLength(0));
        Assert.Equal(3, morpion.etatJeu.Grille.GetLength(1));
    }
}