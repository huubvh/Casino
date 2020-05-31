using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public static class Dice
    {
        public static int DiceRoll(int d)
        {
            Random roll = new Random();
            int dieValue = roll.Next(1, d + 1);
            return dieValue;
        }
    }

}
