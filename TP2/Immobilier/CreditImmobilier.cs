namespace Immobilier;

public class CreditImmobilier
{
    private double montant;
    private double tauxAnnuel;
    private int dureeMois;

    public CreditImmobilier(double montant, double tauxAnnuel, int dureeMois)
    {
        ValiderMontant(montant);
        ValiderTauxAnnuel(tauxAnnuel);
        ValiderDureeMois(dureeMois);
        
        this.montant = montant;
        this.tauxAnnuel = tauxAnnuel;
        this.dureeMois = dureeMois;
    }
    
    private void ValiderMontant(double montant)
    {
        if (montant < 50000)
        {
            throw new ArgumentException("Le montant emprunté doit être au moins 50 000.");
        }
    }

    private void ValiderTauxAnnuel(double tauxAnnuel)
    {
        if (tauxAnnuel <= 0)
        {
            throw new ArgumentException("Le taux annuel doit être positif");
        }
    }

    private void ValiderDureeMois(int dureeMois)
    {
        if (dureeMois < 108 || dureeMois > 300)
        {
            throw new ArgumentException("La durée du crédit doit être entre 9 et 25 ans");
        }
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
}