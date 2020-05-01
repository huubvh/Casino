using System;
using System.Collections.Generic;
using System.Text;

namespace TheHouse
{
    class InputOutput
    {
    }

    public interface IPlayerInterface
    {
        void DisplayMessage(string message, params object[] parameters);
        string GetInput();
    }
}
