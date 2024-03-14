namespace TennisTest;

public class TennisScoreValiditeTest
{
    [Fact]
    [Trait("Tennis", "ScoreValide")]
    public void TennisScoreNonValide()
    {
        var tennis = new Tennis();
        var echangeJ1 = -1;
        var echangeJ2 = -1;
        var scoreAttendu = "Score non valide";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.Equal(scoreAttendu, score);
    }
    
    [Fact]
    [Trait("Tennis", "ScoreValide")]
    public void TennisScoreValide()
    {
        var tennis = new Tennis();
        var echangeJ1 = 0;
        var echangeJ2 = 0;
        var scoreNonAttendu = "Score non valide";
        
        var score = tennis.Score(echangeJ1, echangeJ2);
        
        Assert.NotEqual(scoreNonAttendu, score);
    }
}