namespace TennisTest;

public class Tennis
{
    public string Score(int echangeJ1, int echangeJ2)
    {
        if (echangeJ1 < 0 || echangeJ2 < 0)
        {
            return "Score non valide";
        }
        
        if (echangeJ1 == echangeJ2)
        {
            return "Egalite";
        }
        return "Pas Egalite";
    }
}