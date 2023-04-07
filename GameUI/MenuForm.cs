using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05_Othelo;

namespace GameUI
{
    public partial class MenuForm : Form
    {
        private int m_BoardSize = 6;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void updateBoardSizeText()
        {
            changeSizeButton.Text = string.Format("Board Size:{0}X{0} (click to increase)",m_BoardSize);
        }

        private void startGame(bool isAiGame)
        { 
            GameForm gameForm = new GameForm(m_BoardSize,isAiGame);
            this.Hide();
            gameForm.Closed += (s, args) => this.Close();
            gameForm.Show();
        }

        private void changeSizeButton_Click(object sender, EventArgs e)
        {
            m_BoardSize += 2;

            if (m_BoardSize >12)
            {
                m_BoardSize = 6;
            }

            updateBoardSizeText();
        }

        private void PvPButton_Click(object sender, EventArgs e)
        {
            startGame(isAiGame: false);
        }

        private void ComputerButton_Click(object sender, EventArgs e)
        {
            startGame(isAiGame: true);
        }
    }
}
