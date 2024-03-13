using Xunit;
using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.Communs.Interfaces;
using MorpionApp.Jeux.Communs.Joueurs;
using MorpionApp.Jeux.Interfaces;
using MorpionApp.Jeux.Structures;

namespace MorpionAppTests.Jeux.Communs.JoueursTest;

public class JoueurHumainTest
{
    [Trait("JoueurHumain", "Constructeur")]
    [Fact]
    public void JoueurHumain_Constructeur_InitialiseSymbole()
    {
        char expectedSymbol = 'X';
        
        var joueurHumain = new JoueurHumain(expectedSymbol);
        
        Assert.Equal(expectedSymbol, joueurHumain.Symbol);
    }

    [Trait("JoueurHumain", "JouerTour")]
    [Fact]
    public void JoueurHumain_JouerTour_RetournePosition()
    {
        var joueurHumain = new JoueurHumain('X');
        var etatJeu = new EtatJeu(3, 3);
        var comportementJeu = new ComportementJeuMock();
        
        var position = joueurHumain.JouerTour(etatJeu, comportementJeu);
        
        Assert.NotNull(position);
        Assert.Equal(comportementJeu.ExpectedPosition, position);
    }
}

public class ComportementJeuMock : IComportementJeu
{
    public Position ExpectedPosition { get; } = new Position(0, 0);

    public Position ObtenirEntreeUtilisateur(EtatJeu etatJeu)
    {
        return ExpectedPosition;
    }

    public bool EffectuerAction(EtatJeu etatJeu, IJoueur joueur, Position position)
    {
        return true;
    }
    
    public (int cursorLeft, int cursorTop) CalculerPositionCurseur(Position position)
    {
        return (0, 0);
    }

    public bool VerifVictoire(EtatJeu etatJeu, IJoueur joueur)
    {
        return true;
    }

    public bool VerifEgalite(EtatJeu etatJeu)
    {
        return true;
    }
    
}