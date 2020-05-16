using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class BaseGame
    {
        public string GameName { get; set; }
        public string Description { get; set; }
        public string GameRules { get; set; }
        public string GameType { get; set; }
        public double GameOdds { get; set; }

        public int Bet { get; set; }

        public BaseGame()
        {
            
        }

        public void AddGame(string newGameName, string newGameType, double newGameOdds)
        {
            GameName = newGameName;
            GameType = newGameType;
            GameOdds = newGameOdds;
        }


    }
}
