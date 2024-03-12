using MorpionApp.Console;
using System.Text;

namespace MorpionAppTests.ConsoleTest;

public class AssistantConsoleTests
{
    [Trait("AssistantConsole", "DemanderToucheParmiOptions")]
    [Fact]
    public void DemanderToucheParmiOptions_RetourneOptionValide()
    {
        var input = new StringReader("A\n");
        Console.SetIn(input);
        var output = new StringBuilder();
        Console.SetOut(new StringWriter(output));
        
        var result = AssistantConsole.DemanderToucheParmiOptions("Appuyez sur une touche", ConsoleKey.A);
        
        Assert.Equal(ConsoleKey.A, result);
        Assert.Contains("Appuyez sur une touche", output.ToString());
    }

    [Trait("AssistantConsole", "DemanderToucheParmiOptions")]
    [Fact]
    public void DemanderToucheParmiOptions_RetourneMessageErreurPourOptionInvalide()
    {
        var input = new StringReader("B\nA\n");
        Console.SetIn(input);
        var output = new StringBuilder();
        Console.SetOut(new StringWriter(output));
        
        var result = AssistantConsole.DemanderToucheParmiOptions("Appuyez sur une touche", ConsoleKey.A);
        
        Assert.Equal(ConsoleKey.A, result);
        Assert.Contains("Entrée invalide", output.ToString());
    }
}