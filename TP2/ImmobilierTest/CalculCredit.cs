using Immobilier;

namespace ImmobilierTest;

public class CalculCredit
{
    [Fact]
    [Trait("Categorie", "Calculs")]
    public void DonnerMensualite()
    {
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;
        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);
        
        var mensualite = credit.mensualite();
        
        Assert.Equal(1287.02, mensualite, 2);
    }
    
    [Fact]
    [Trait("Categorie", "Calculs")]
    public void DonnerCoutTotalCredit()
    {
        var montant = 100000;
        var tauxAnnuel = 0.03;
        var dureeMois = 120;
        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);
        
        var coutTotal = credit.coutTotal();
        
        Assert.Equal(130000, coutTotal);
    }
}