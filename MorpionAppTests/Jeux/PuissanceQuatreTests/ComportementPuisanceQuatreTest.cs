using MorpionApp.Jeux.Communs;
using MorpionApp.Jeux.PuissanceQuatre;
using MorpionApp.Jeux.Communs.Joueurs;
using MorpionApp.Jeux.Structures;

namespace MorpionAppTests.Jeux.PuissanceQuatreTests;

public class ComportementPuissanceQuatreTests
{
    [Trait("ComportementPuissanceQuatre", "EffectuerAction")]
    [Fact]
    public void EffectuerAction_AvecCasesVides()
    {
        var comportement = new ComportementPuissanceQuatre();
        var etatJeu = new EtatJeu(6, 7);
        var joueur = new JoueurHumain('X');
        var position = new Position(0, 0);
        
        var result = comportement.EffectuerAction(etatJeu, joueur, position);
        
        Assert.True(result);
        Assert.Equal(joueur.Symbol, etatJeu.Grille[etatJeu.Grille.GetLength(0) - 1, position.Column]);
    }
    
    [Trait("ComportementPuissanceQuatre", "EffectuerAction")]
    [Fact]
    public void EffectuerAction_AvecCasesOccupees()
    {
        var comportement = new ComportementPuissanceQuatre();
        var etatJeu = new EtatJeu(6, 7);
        var joueur = new JoueurHumain('X');
        var position = new Position(0, 0);
        etatJeu.Grille[etatJeu.Grille.GetLength(0) - 1, position.Column] = 'O';
        
        var result = comportement.EffectuerAction(etatJeu, joueur, position);
        
        Assert.False(result);
        Assert.NotEqual(joueur.Symbol, etatJeu.Grille[etatJeu.Grille.GetLength(0) - 1, position.Column]);
    }

    [Trait("ComportementPuissanceQuatre", "VerifVictoire")]
    [Fact]
    public void VerifVictoire_AvecVictoire()
    {
        var comportement = new ComportementPuissanceQuatre();
        var etatJeu = new EtatJeu(6, 7);
        var joueur = new JoueurHumain('X');
        for (int i = 0; i < 4; i++)
        {
            etatJeu.Grille[etatJeu.Grille.GetLength(0) - 1, i] = joueur.Symbol;
        }
        
        var result = comportement.VerifVictoire(etatJeu, joueur);
        
        Assert.True(result);
    }
    
    [Trait("ComportementPuissanceQuatre", "VerifVictoire")]
    [Fact]
    public void VerifVictoire_SansVictoire()
    {
        var comportement = new ComportementPuissanceQuatre();
        var etatJeu = new EtatJeu(6, 7);
        var joueur = new JoueurHumain('X');
        for (int i = 0; i < 3; i++)
        {
            etatJeu.Grille[etatJeu.Grille.GetLength(0) - 1, i] = joueur.Symbol;
        }
        
        var result = comportement.VerifVictoire(etatJeu, joueur);
        
        Assert.False(result);
    }

    [Trait("ComportementPuissanceQuatre", "VerifEgalite")]
    [Fact]
    public void VerifEgalite_AvecGrillePleine()
    {
        var comportement = new ComportementPuissanceQuatre();
        var etatJeu = new EtatJeu(6, 7);
        for (int i = 0; i < etatJeu.Grille.GetLength(0); i++)
        {
            for (int j = 0; j < etatJeu.Grille.GetLength(1); j++)
            {
                etatJeu.Grille[i, j] = 'X';
            }
        }
        
        var result = comportement.VerifEgalite(etatJeu);
        
        Assert.True(result);
    }
    
    [Trait("ComportementPuissanceQuatre", "VerifEgalite")]
    [Fact]
    public void VerifEgalite_AvecGrilleNonPleine()
    {
        var comportement = new ComportementPuissanceQuatre();
        var etatJeu = new EtatJeu(6, 7);
        
        var result = comportement.VerifEgalite(etatJeu);
        
        Assert.False(result);
    }
}