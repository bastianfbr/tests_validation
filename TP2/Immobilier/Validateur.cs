namespace Immobilier;

public static class Validateur
{
    public static void ValiderMontant(double montant)
    {
        if (montant < 50000)
        {
            throw new ExceptionPersonnalisee("Le montant emprunté doit être au moins 50 000.");
        }
    }

    public static void ValiderTauxAnnuel(double tauxAnnuel)
    {
        if (tauxAnnuel <= 0)
        {
            throw new ExceptionPersonnalisee("Le taux annuel doit être positif.");
        }
    }

    public static void ValiderDureeMois(int dureeMois)
    {
        if (dureeMois < 108 || dureeMois > 300)
        {
            throw new ExceptionPersonnalisee("La durée du crédit doit être entre 9 et 25 ans.");
        }
    }
}