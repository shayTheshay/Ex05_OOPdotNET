using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_Othelo
{
    public class Cell
    {
        private ePlayerColor m_CellColor = ePlayerColor.Empty;
        public ePlayerColor CellColor
        {
            get { return m_CellColor; }
            set { m_CellColor = value; }
        }
    }
}
