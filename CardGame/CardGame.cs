using System;

namespace CardGame
{
    public class CardGame    
    {
    
    public void GameSummary(TheHouse.IPlayerInterface io)
        {

            string gameSummary = "Welcome to the Card Game. \n";
            io.DisplayMessage(gameSummary);


        }

    }
}

