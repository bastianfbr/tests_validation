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
        
        if (echangeJ1 >= 4 && echangeJ1 - echangeJ2 == 1)
        {
            return "Avantage J1";
        }
        
        if (echangeJ2 >= 4 && echangeJ2 - echangeJ1 == 1)
        {
            return "Avantage J2";
        }
        
        if (echangeJ1 >= 4 && echangeJ1 - echangeJ2 >= 2)
        {
            return "Victoire J1";
        }
        
        if (echangeJ2 >= 4 && echangeJ2 - echangeJ1 >= 2)
        {
            return "Victoire J2";
        }
        
        return CalculeScore(echangeJ1, echangeJ2);
    }
    
    public string CalculeScore(int echangeJ1, int echangeJ2)
    {
        var scoreJ1 = 0;
        var scoreJ2 = 0;
        
        if (echangeJ1 == 1)
        {
            scoreJ1 = 15;
        }
        else if (echangeJ1 == 2)
        {
            scoreJ1 = 30;
        }
        else if (echangeJ1 >= 3)
        {
            scoreJ1 = 40;
        }
        
        if (echangeJ2 == 1)
        {
            scoreJ2 = 15;
        }
        else if (echangeJ2 == 2)
        {
            scoreJ2 = 30;
        }
        else if (echangeJ2 >= 3)
        {
            scoreJ2 = 40;
        }
        
        return $"{scoreJ1}-{scoreJ2}";
    }
}