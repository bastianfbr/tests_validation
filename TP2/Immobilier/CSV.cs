using System.Text;

namespace Immobilier;

public class CSV
{
    private readonly CreditImmobilier credit;

    public CSV(CreditImmobilier credit)
    {
        this.credit = credit;
    }

    public string donnerCSV()
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("Le cout total du crédit est de ; " + credit.coutTotal() + "; euros");
        csvBuilder.AppendLine("Mensualité;Capital remboursé;Capital restant dû");

        for (var i = 1; i <= credit.obtenirDureeMois(); i++)
        {
            double capitalRembourse = credit.capitalRembourseApresMensualite(i);
            double capitalRestantDu = credit.CapitalRestantDuApresMensualite(i);
        
            csvBuilder.AppendLine($"{i};{Math.Round(capitalRembourse, 2)};{Math.Round(capitalRestantDu, 2)}");
        }

        return csvBuilder.ToString();
    }
    
    public void ecrireCSV(string chemin)
    {
        File.WriteAllText(chemin, donnerCSV());
    }
    
}