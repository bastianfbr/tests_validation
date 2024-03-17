using Immobilier;

namespace ImmobilierTest;

public class Validation
{
    [Fact]
    [Trait("Categorie", "Validation")]
    public void MontantAuMoins50000()
    {
        var montant = 20000;
        var tauxAnnuel = 2;
        var dureeMois = 180;
    
        var exception = Assert.Throws<ArgumentException>(() => new CreditImmobilier(montant, tauxAnnuel, dureeMois));
    
        Assert.Contains("Le montant emprunté doit être au moins 50 000", exception.Message);
    }
    
    [Fact]
    [Trait("Categorie", "Validation")]
    public void DureeMoisEntre9et25ans()
    {
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 301;
    
        var exception = Assert.Throws<ArgumentException>(() => new CreditImmobilier(montant, tauxAnnuel, dureeMois));
    
        Assert.Contains("La durée du crédit doit être entre 9 et 25 ans", exception.Message);
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