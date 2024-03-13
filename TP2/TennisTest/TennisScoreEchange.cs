namespace TennisTest;

public class TennisScoreEchange
{
    [Fact]
    [Trait("Tennis", "RetourneBonScore")]
    public void TennisRetourneBonScore15_15()
    {
        var tennis = new Tennis();
        var echangeJ1 = 1;
        var echangeJ2 = 1;
        var scoreAttendu = "15-15";
        
        var score = tennis.CalculeScore(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "RetourneBonScore")]
    public void TennisRetourneBonScore30_15()
    {
        var tennis = new Tennis();
        var echangeJ1 = 2;
        var echangeJ2 = 1;
        var scoreAttendu = "30-15";
        
        var score = tennis.CalculeScore(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "RetourneBonScore")]
    public void TennisRetourneBonScore40_40()
    {
        var tennis = new Tennis();
        var echangeJ1 = 30;
        var echangeJ2 = 30;
        var scoreAttendu = "40-40";
        
        var score = tennis.CalculeScore(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
    }
}