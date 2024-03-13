namespace TennisTest;

public class TennisScoreVictoireTest
{
    [Fact]
    [Trait("Tennis", "RetourneScoreVictoire")]
    public void TennisRetourneScoreVictoireJ1()
    {
        var tennis = new Tennis();
        var echangeJ1 = 4;
        var echangeJ2 = 0;
        var scoreAttendu = "Victoire J1";
        var scoreNonAttendu = "Victoire J2";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
        Assert.NotEqual(scoreNonAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "RetourneScoreVictoire")]
    public void TennisRetourneScoreVictoireJ2()
    {
        var tennis = new Tennis();
        var echangeJ1 = 0;
        var echangeJ2 = 4;
        var scoreAttendu = "Victoire J2";
        var scoreNonAttendu = "Victoire J1";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
        Assert.NotEqual(scoreNonAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "RetourneScorePasVictoire")]
    public void TennisRetourneScorePasVictoire()
    {
        var tennis = new Tennis();
        var echangeJ1 = 5;
        var echangeJ2 = 5;
        var scoreNonAttendu = "Victoire J1";
        var scoreNonAttendu2 = "Victoire J2";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.NotEqual(scoreNonAttendu, score);
        Assert.NotEqual(scoreNonAttendu2, score);
    }
}