using MorpionApp.Jeux.Structures;

namespace MorpionAppTests.Jeux.StructuresTest;

public class PositionTests
{
    [Trait("Position", "Constructeur")]
    [Fact]
    public void Position_Constructeur_Initialise_Position()
    {
        int row = 1;
        int column = 2;
        
        var position = new Position(row, column);
        
        Assert.Equal(row, position.Row);
        Assert.Equal(column, position.Column);
    }
}