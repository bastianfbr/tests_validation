using Immobilier;
using System.Text;

namespace ImmobilierTest;

public class CreationCSV
{
    [Fact]
    [Trait("Categorie", "CreationCSV")]
    public void VerifierCreationCSV10PremieresLignes()
    {
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;

        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);

        var csv = new CSV(credit);

        var csvAttendu = new StringBuilder();
        csvAttendu.AppendLine("Mensualité;Capital remboursé;Capital restant dû");
        csvAttendu.AppendLine("1;953,68;199046,32");
        csvAttendu.AppendLine("2;1908,96;198091,04");
        csvAttendu.AppendLine("3;2865,82;197134,18");
        csvAttendu.AppendLine("4;3824,28;196175,72");
        csvAttendu.AppendLine("5;4784,34;195215,66");
        csvAttendu.AppendLine("6;5746;194254");
        csvAttendu.AppendLine("7;6709,26;193290,74");
        csvAttendu.AppendLine("8;7674,13;192325,87");
        csvAttendu.AppendLine("9;8640,6;191359,4");
        csvAttendu.AppendLine("10;9608,69;190391,31");

        var resultatCsv = csv.donnerCSV();
        
        Assert.Contains(csvAttendu.ToString(), resultatCsv);
    }
}