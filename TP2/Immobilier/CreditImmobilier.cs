namespace Immobilier;

public class CreditImmobilier
{
    private double montant;
    private double tauxAnnuel;
    private int dureeMois;

    public CreditImmobilier(double montant, double tauxAnnuel, int dureeMois)
    {
        if (montant <= 0)
        {
            throw new ArgumentException("Le montant emprunté doit être positif");
        }
        
        if (tauxAnnuel <= 0)
        {
            throw new ArgumentException("Le taux annuel doit être positif");
        }
        
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
}