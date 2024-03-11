namespace MorpionApp;

[Serializable]
public class SauvegardeDonnees
{
    public List<string> Grille { get; set; }
    public string TypeJeu { get; set; }
    public bool EstJoueurIA { get; set; }
}
