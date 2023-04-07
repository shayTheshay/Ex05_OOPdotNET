using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameUI
{
    internal class OthelloButton : PictureBox
    {
        private readonly int r_X;
        public int X
        {
            get { return r_X; }
        }

        private readonly int r_Y;
        public int Y
        {
            get { return r_Y; }
        }

        public OthelloButton(int x, int y) : base()
        {
            r_X = x;
            r_Y = y;
        }
    }
}
