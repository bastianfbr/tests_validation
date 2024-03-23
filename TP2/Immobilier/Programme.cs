namespace Immobilier;

public class Programme
{
    public static void Main(string[] args)
    {
        try {
            if (args.Length != 3)
            {
                Console.WriteLine("Veuillez entrer le montant, le taux annuel et la durée en mois du crédit");
                return;
            }
        
            var montant = double.Parse(args[0]);
            var tauxAnnuel = double.Parse(args[1]);
            var dureeMois = int.Parse(args[2]);
        
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