namespace TennisTest;

public class Tennis
{
    public string Score(int echangeJ1, int echangeJ2)
    {
        if (echangeJ1 == echangeJ2)
        {
            return "Egalite";
        }
        return "Pas Egalite";
    }
}