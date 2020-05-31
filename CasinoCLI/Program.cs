using System;

namespace PlayChannelCLI
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsolePlayerInterface io = new ConsolePlayerInterface();
            PlayseatCLI playSeat = new PlayseatCLI(io);
            playSeat.Run();
        }
        
        public class ConsolePlayerInterface : TheHouse.IUserInterface
        {
            public void DisplayMessage(string message, params object[] parameters) =>
                Console.WriteLine(string.Format(message, parameters));

            public string GetInput() =>
                Console.ReadLine();
        }

    }
}
