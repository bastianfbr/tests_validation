namespace MorpionApp.Console
{
    public class JeuConsole
    {
        public static ConsoleKey ChoisirJeu()
        {
            return AssistantConsole.DemanderToucheParmiOptions("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.", ConsoleKey.X, ConsoleKey.P);
        }

        public static bool DemanderJoueurIA()
        {
            ConsoleKey key = AssistantConsole.DemanderToucheParmiOptions("Voulez-vous jouer contre l'ordinateur ? Taper [O] pour oui et [N] pour non.", ConsoleKey.O, ConsoleKey.N);
            return key == ConsoleKey.O;
        }

        public static bool DemanderRejouer()
        {
            
            ConsoleKey key = AssistantConsole.DemanderToucheParmiOptions("Voulez-vous encore jouer à un jeu ? Taper [O] pour oui et [N] pour non.", ConsoleKey.O, ConsoleKey.N);
            return key == ConsoleKey.O;
        }
    }
}
