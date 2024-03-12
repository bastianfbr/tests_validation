namespace MorpionApp
{
    public static class AssistantConsole
    {
        public static ConsoleKey DemanderToucheParmiOptions(string message, params ConsoleKey[] optionsValides)
        {
            ConsoleKey key;
            do
            {
                Console.WriteLine(message);
                key = Console.ReadKey(true).Key;

                foreach (var option in optionsValides)
                {
                    if (key == option)
                    {
                        return key;
                    }
                }

                Console.WriteLine("Entrée invalide");
            } while (true);
        }
    }
}