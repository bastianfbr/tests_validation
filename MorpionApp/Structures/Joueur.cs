namespace MorpionApp.Structures;

public readonly struct Joueur
{
    public char Symbol { get; }

    public Joueur(char symbol)
    {
        Symbol = symbol;
    }
}