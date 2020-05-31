using System;
using System.Collections.Generic;
using System.Text;
using TheHouse;

namespace GameLibrary
{
    public class BaseGame
    {
        public string GameName { get; set; }
        public string Description { get; set; }
        public string GameRules { get; set; }
        public string GameType { get; set; }
        public decimal GameOdds { get; set; }

        public IUserInterface io;
        public int Bet { get; set; }

        public Player player;
        public BaseGame()
        {
            
        }
        public void GameSummary()
        {
            io.DisplayMessage(GameRules);
        }
        public void AddGame(string newGameName, string newGameType, decimal newGameOdds)
        {
            GameName = newGameName;
            GameType = newGameType;
            GameOdds = newGameOdds;
        }



    }
}
