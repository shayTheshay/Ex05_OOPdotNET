using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_Othelo
{
    public class Board
    {
        private int m_Size;
        public int Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }

        private readonly Cell[,] r_Cells;
        public Cell[,] Cells
        {
            get { return r_Cells; }
        }

        public Board(int size=8)
        {
            m_Size = size;
            r_Cells = new Cell[size, size];
            initializeBoard();
        }

        internal void initializeBoard()
        {
            for (int i = 0; i < m_Size; i++)
                {
                    for (int j = 0; j < m_Size; j++)
                    {
                        r_Cells[i, j] = new Cell();
                    }
                }    

            r_Cells[(m_Size / 2) - 1, (m_Size / 2) - 1].CellColor = ePlayerColor.White;
            r_Cells[m_Size / 2, m_Size / 2].CellColor = ePlayerColor.White;
            r_Cells[(m_Size / 2) - 1, m_Size / 2].CellColor = ePlayerColor.Black;
            r_Cells[m_Size / 2, (m_Size / 2) - 1].CellColor = ePlayerColor.Black;
        }
    }
}
