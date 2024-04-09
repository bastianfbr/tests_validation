using Immobilier;

namespace ImmobilierTest;

public class ProgrammeTests
{
    [Fact]
    public void Test_ArgumentsManquants()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        Programme.Main(new string[] { });

        var output = writer.GetStringBuilder().ToString().Trim();
        Assert.Contains("Veuillez entrer le montant, le taux annuel et la durée en mois du crédit", output);
    }

    [Fact]
    public void Test_ArgumentsInvalides()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        Programme.Main(new string[] { "abc", "def", "ghi" });

        var output = writer.GetStringBuilder().ToString().Trim();
        Assert.Contains("Le montant spécifié n'est pas un nombre valide", output);
    }

    [Fact]
    public void Test_TauxAnnuelInvalide()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        Programme.Main(new string[] { "100000", "-1", "120" });

        var output = writer.GetStringBuilder().ToString().Trim();
        Assert.Contains("Le taux annuel doit être positif", output);
    }

    [Fact]
    public void Test_DureeMoisInvalide()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        Programme.Main(new string[] { "100000", "3,5", "a" });

        var output = writer.GetStringBuilder().ToString().Trim();
        Assert.Contains("La durée en mois spécifiée n'est pas un nombre valide", output);
    }
}