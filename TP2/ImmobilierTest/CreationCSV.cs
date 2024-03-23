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
        csvAttendu.AppendLine("Le cout total du crédit est de ; " + credit.coutTotal() + "; euros");
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
        
        Assert.StartsWith(csvAttendu.ToString(), resultatCsv);
    }
    
    [Fact]
    [Trait("Categorie", "CreationCSV")]
    public void VerifierCreationCSVDernieresLignes()
    {
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;

        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);

        var csv = new CSV(credit);

        var csvAttendu = new StringBuilder();
        csvAttendu.AppendLine("171;188512,78;11487,22");
        csvAttendu.AppendLine("172;189780,65;10219,35");
        csvAttendu.AppendLine("173;191050,64;8949,36");
        csvAttendu.AppendLine("174;192322,74;7677,26");
        csvAttendu.AppendLine("175;193596,96;6403,04");
        csvAttendu.AppendLine("176;194873,31;5126,69");
        csvAttendu.AppendLine("177;196151,78;3848,22");
        csvAttendu.AppendLine("178;197432,39;2567,61");
        csvAttendu.AppendLine("179;198715,12;1284,88");
        csvAttendu.AppendLine("180;200000;0");

        var resultatCsv = csv.donnerCSV();
        
        Assert.Contains(csvAttendu.ToString(), resultatCsv);
    }
    
    [Fact]
    [Trait("Categorie", "CreationCSV")]
    public void VerifierCreationCSVPremieresLigne()
    {
        var montant = 200000;
        var tauxAnnuel = 2;
        var dureeMois = 180;

        var credit = new CreditImmobilier(montant, tauxAnnuel, dureeMois);

        var csv = new CSV(credit);

        var csvAttendu = new StringBuilder();
        csvAttendu.AppendLine("Le cout total du crédit est de ; " + credit.coutTotal() + "; euros");
        csvAttendu.AppendLine("Mensualité;Capital remboursé;Capital restant dû");

        var resultatCsv = csv.donnerCSV();
        
        Assert.StartsWith(csvAttendu.ToString(), resultatCsv);
    }
}