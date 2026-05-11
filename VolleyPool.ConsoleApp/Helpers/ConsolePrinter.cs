namespace VolleyPool.ConsoleApp.Helpers
{
    public class ConsolePrinter
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintLine(char message)
        {
            Console.WriteLine(string.Join("", Enumerable.Repeat(message, 60)));
        }

        public void StripedLine()
        {
            PrintLine('-');

        }

        public void PrintBlock(string message)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            PrintLine('/');
            PrintMessage($"/// {message}");
            PrintLine('/');
            Console.ResetColor();
        }

        public void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void PrintDebugBlock(string message)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintLine('/');
            PrintMessage($"/// {message}");
            PrintLine('/');
            Console.ResetColor();
        }

        public void PrintDebugMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
