using Immobilier;

namespace ImmobilierTest;

public class Validation
{
    [Fact]
    [Trait("Categorie", "Validation")]
    public void MontantEmpruntePositif()
    {
        var montant = -200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;
    
        var exception = Assert.Throws<ArgumentException>(() => new CreditImmobilier(montant, tauxAnnuel, dureeMois));
    
        Assert.Contains("Le montant emprunté doit être positif", exception.Message);
    }
    
    [Fact]
    [Trait("Categorie", "Validation")]
    public void TauxAnnuelPositif()
    {
        var montant = 200000;
        var tauxAnnuel = -2;
        var dureeMois = 180;
    
        var exception = Assert.Throws<ArgumentException>(() => new CreditImmobilier(montant, tauxAnnuel, dureeMois));
    
        Assert.Contains("Le taux annuel doit être positif", exception.Message);
    }

}