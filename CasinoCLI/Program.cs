using System;

namespace PlayChannelCLI
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsolePlayerInterface io = new ConsolePlayerInterface();
            PlayseatCLI playSeat = new PlayseatCLI();
            playSeat.Run(io);
        }

        public class ConsolePlayerInterface : TheHouse.IPlayerInterface
        {
            public void DisplayMessage(string message, params object[] parameters) =>
                Console.WriteLine(string.Format(message, parameters));

            public string GetInput() =>
                Console.ReadLine();
        }

    }
}
