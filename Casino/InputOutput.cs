﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheHouse
{


    public interface IUserInterface
    {
        void DisplayMessage(string message, params object[] parameters);
        string GetInput();
    }

   
}
