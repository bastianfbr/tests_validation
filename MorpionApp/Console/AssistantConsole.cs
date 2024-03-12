namespace MorpionApp.Console
{
    public static class AssistantConsole
    {
        public static ConsoleKey DemanderToucheParmiOptions(string message, params ConsoleKey[] optionsValides)
        {
            ConsoleKey key;
            do
            {
                System.Console.WriteLine(message);
                key = System.Console.ReadKey(true).Key;

                foreach (var option in optionsValides)
                {
                    if (key == option)
                    {
                        return key;
                    }
                }

                System.Console.WriteLine("Entrée invalide");
            } while (true);
        }
    }
}