namespace Immobilier;

public static class Programme
{
    public static void Main(string[] args)
    {
        try {
            if (args.Length != 3)
            {
                Console.WriteLine("Veuillez entrer le montant, le taux annuel et la durée en mois du crédit");
                return;
            }
        
            if (double.TryParse(args[0], out var montant) == false)
            {
                Console.WriteLine("Le montant spécifié n'est pas un nombre valide");
                return;
            }
            
            if (double.TryParse(args[1], out var tauxAnnuel) == false)
            {
                Console.WriteLine("Le taux annuel spécifié n'est pas un nombre valide");
                return;
            }
            
            if (int.TryParse(args[2], out var dureeMois) == false)
            {
                Console.WriteLine("La durée en mois spécifiée n'est pas un nombre valide");
                return;
            }
        
            var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);
        
            var csv = new CSV(credit);
        
            Console.WriteLine(csv.donnerCSV());
        
            csv.ecrireCSV("credit.csv");
        
            Console.WriteLine("Le fichier credit.csv a été créé");
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}