namespace TennisTest;

public class TennisScoreEgaliteTest
{
    [Fact]
    [Trait("Tennis", "RetourneScoreEgalite")]
    public void TennisRetourneScoreEgalite()
    {
        var tennis = new Tennis();
        var echangeJ1 = 3;
        var echangeJ2 = 3;
        var scoreAttendu = "Egalite";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "RetourneScoreEgalite")]
    public void TennisRetourneScorePasEgalite()
    {
        var tennis = new Tennis();
        var echangeJ1 = 5;
        var echangeJ2 = 4;
        var scoreNonAttendu = "Egalite";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.NotEqual(scoreNonAttendu, score);
    }
}