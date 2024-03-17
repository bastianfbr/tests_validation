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
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;
        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);
        
        var coutTotal = credit.coutTotal();
        
        Assert.Equal(231663.13, Math.Round(coutTotal, 2));
    }
    
    [Fact]
    [Trait("Categorie", "Calculs")]
    public void VerifierCapitalRemboursePremiereMensualite()
    {
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;
        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);
    
        var capitalRembourse = credit.capitalRembourseApresMensualite(1);
        
        Assert.Equal(1284.85, Math.Round(capitalRembourse, 2));
    }
}