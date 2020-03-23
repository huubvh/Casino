using System;

namespace DiceGame
{
    public class DiceGame

    {
        public Enums.resultType result { get; set; }
        public int bet { get; set; }
        public int win { get; set; }
        public int pushDie { get; set; }
        public PlayerTurn playerTurn { get; set; }

        public int diceAmount { get; set; }
        public int diceType { get; set; }
        public int shoveDie { get; set; }


        public string GameResult
        {
            get
                {
                string resultTest = "test";
                return resultTest;

            }
        }

    }
}
