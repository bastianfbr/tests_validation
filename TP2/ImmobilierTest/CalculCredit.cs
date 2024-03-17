namespace ImmobilierTest;

public class CalculCredit
{
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