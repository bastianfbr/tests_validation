namespace TennisTest;

public class TennisScoreAvantageTest
{
[Fact]
    [Trait("Tennis", "RetourneScoreAvantage")]
    public void TennisRetourneScoreAvantageJ1()
    {
        var tennis = new Tennis();
        var echangeJ1 = 4;
        var echangeJ2 = 3;
        var scoreAttendu = "Avantage J1";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "RetourneScoreAvantage")]
    public void TennisRetourneScoreAvantageJ2()
    {
        var tennis = new Tennis();
        var echangeJ1 = 3;
        var echangeJ2 = 4;
        var scoreAttendu = "Avantage J2";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "RetourneScorePasAvantage")]
    public void TennisRetourneScorePasAvantage()
    {
        var tennis = new Tennis();
        var echangeJ1 = 5;
        var echangeJ2 = 5;
        var scoreNonAttendu = "Avantage J1";
        var scoreNonAttendu2 = "Avantage J2";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.NotEqual(scoreNonAttendu, score);
        Assert.NotEqual(scoreNonAttendu2, score);
    }
}