namespace MorpionApp.Jeux.Structures;

public readonly struct Position
{
    public int Row { get; }
    public int Column { get; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }
}
