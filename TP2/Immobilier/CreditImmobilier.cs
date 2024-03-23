namespace Immobilier;

public class CreditImmobilier
{
    private double montant;
    private double tauxAnnuel;
    private int dureeMois;

    public CreditImmobilier(double montant, double tauxAnnuel, int dureeMois)
    {
        Validateur.ValiderMontant(montant);
        Validateur.ValiderTauxAnnuel(tauxAnnuel);
        Validateur.ValiderDureeMois(dureeMois);
        
        this.montant = montant;
        this.tauxAnnuel = tauxAnnuel;
        this.dureeMois = dureeMois;
    }
    
    public double coutTotal()
    {
        return mensualite() * dureeMois;
    }
    
    public double mensualite()
    {
        return montant * (tauxAnnuel / 100 / 12) / (1 - Math.Pow(1 + tauxAnnuel / 100 / 12, -dureeMois));
    }

    public double capitalRembourseApresMensualite(int mensualite)
    {
        var capitalRestantDu = montant;
        for (var i = 0; i < mensualite; i++)
        {
            var interet = capitalRestantDu * tauxAnnuel / 100 / 12;
            var amortissement = this.mensualite() - interet;
            capitalRestantDu -= amortissement;
        }

        return montant - capitalRestantDu;
    }
    
    public double CapitalRestantDuApresMensualite(int mensualite)
    {
        var capitalRestantDu = montant;
        for (var i = 0; i < mensualite; i++)
        {
            var interet = capitalRestantDu * tauxAnnuel / 100 / 12;
            var amortissement = this.mensualite() - interet;
            capitalRestantDu -= amortissement;
        }

        return capitalRestantDu;
    }
    
    public double obtenirMontant()
    {
        return montant;
    }
    public double obtenirTauxAnnuel()
    {
        return tauxAnnuel;
    }
    
    public int obtenirDureeMois()
    {
        return dureeMois;
    }
}