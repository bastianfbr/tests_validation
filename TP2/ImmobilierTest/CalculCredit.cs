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
        
        Assert.Equal(953,67, Math.Round(capitalRembourse, 2));
    }
    
    [Fact]
    [Trait("Categorie", "Calculs")]
    public void VerifierCapitalRestantDuApresPremiereMensualite()
    {
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;
        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);
    
        var capitalRestant = credit.CapitalRestantDuApresMensualite(1);
        
        Assert.Equal(199046.32, Math.Round(capitalRestant, 2));
    }
}