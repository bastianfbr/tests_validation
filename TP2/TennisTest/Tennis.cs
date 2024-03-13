namespace TennisTest;

public class Tennis
{
    public const int ScorePourGagner = 4;
    public const int DiffMinPourGagner = 2;
    public static readonly string[] Scores = { "0", "15", "30", "40" };
    
    public string Score(int echangeJ1, int echangeJ2)
    {
        if (!ScoreValide(echangeJ1, echangeJ2))
        {
            return "Score non valide";
        }
        
        if (ScoreEgalite(echangeJ1, echangeJ2))
        {
            return "Egalite";
        }
        
        if (ScoreAvantage(echangeJ1, echangeJ2))
        {
            return $"Avantage {(echangeJ1 > echangeJ2 ? "J1" : "J2")}";
        }
        
        if (ScoreVictoire(echangeJ1, echangeJ2))
        {
            return $"Victoire {(echangeJ1 > echangeJ2 ? "J1" : "J2")}";
        }
        
        return $"{CalculeScore(echangeJ1)}-{CalculeScore(echangeJ2)}";
    }
    
    public string CalculeScore(int echange)
    {
        return echange < Scores.Length ? Scores[echange] : "40";
    }
    
    public bool ScoreValide(int echangeJ1, int echangeJ2)
    {
        return echangeJ1 >= 0 && echangeJ2 >= 0;
    }
    
    public bool ScoreEgalite(int echangeJ1, int echangeJ2)
    {
        return echangeJ1 == echangeJ2;
    }
    
    public bool ScoreAvantage(int echangeJ1, int echangeJ2)
    {
        return echangeJ1 >= 4 && echangeJ1 - echangeJ2 == 1 || echangeJ2 >= 4 && echangeJ2 - echangeJ1 == 1;
    }
    
    public bool ScoreVictoire(int echangeJ1, int echangeJ2)
    {
        return echangeJ1 >= ScorePourGagner && echangeJ1 - echangeJ2 >= DiffMinPourGagner || echangeJ2 >= ScorePourGagner && echangeJ2 - echangeJ1 >= DiffMinPourGagner;
    }
}