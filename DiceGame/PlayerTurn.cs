using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame
{
    public class PlayerTurn
    {
        public List<int> PlayerDice { get; set; }

        public int Pair { get; set; }
        public bool Win { get; set; }

    }
}
