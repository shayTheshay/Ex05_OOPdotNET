using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_Othelo
{
    public class Player
    {
        private readonly string r_Name;
        public string Name
        {
            get { return r_Name; }
        }

        private readonly ePlayerColor r_PlayerColor;
        public ePlayerColor PlayerColor
        {
            get { return r_PlayerColor; }
        }

        private readonly bool r_IsAi;
        public bool IsAi
        {
            get { return r_IsAi; }
        }

        public Player(string i_Name, ePlayerColor i_Color, bool isAi = false)
        {
            r_Name = i_Name;
            r_PlayerColor = i_Color;
            this.r_IsAi = isAi;
        }
    }

    public enum ePlayerColor
    {
        Empty,
        Black,
        White
    }
}
