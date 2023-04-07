using Ex05_Othelo;

namespace GameUI
{
    public partial class GameForm : Form
    {
        private readonly GameLogic r_Logic;
        private readonly int r_CellSize = 75;
        private readonly int r_Margins = 10;
        private readonly List<OthelloButton> r_ButtonList = new();
        private int m_BlackWins = 0;
        private int m_WhiteWins = 0;
        private int m_AIMoveX = 0;
        private int m_AIMoveY = 0;

        public GameForm(int i_Size, bool isAiGame)
        {
            r_Logic = new GameLogic(i_Size, isAiGame);
            r_Logic.EndGameActions += endGame;
            r_Logic.AIActions += moveAI;
            r_Logic.UpdateVisuals += updateGraphics;
            InitializeComponent(i_Size);
            startNewGame();
        }

        private void startNewGame()
        {
            r_Logic.ResetBoard();
            updateGraphics();
        }

        private void updateGraphics()
        {
            foreach (OthelloButton button in r_ButtonList)
            {
                button.Enabled = false;
                button.BackColor = Color.Gray;
                switch (r_Logic.Board.Cells[button.X, button.Y].CellColor)
                {
                    case ePlayerColor.Empty:
                        if (r_Logic.CheckLegalityOfPlay(button.X, button.Y))
                        {
                            button.BackColor = Color.Green;
                            button.Enabled = true;
                        }

                        button.Image = null;
                        break;
                    case ePlayerColor.White:
                        button.Image = Properties.Resources.CoinYellow;
                        break;
                    case ePlayerColor.Black:
                        button.Image = Properties.Resources.CoinRed;
                        break;
                }
            }

            this.Text = String.Format("Othello:{0}'s turn", r_Logic.CurrentPlayer.PlayerColor);
        }

        private void endGame(Player winner, int winnerScore, int loserScore)
        {
            String winningPlayerText,victoryMessage;

            if (winner == null)
            {
                winningPlayerText = "Tie!";
            }
            else
            {
                winningPlayerText = String.Format("{0} won!",
                                       winner.PlayerColor);
                if (winner.PlayerColor == ePlayerColor.Black)
                    m_BlackWins++;
                else
                    m_WhiteWins++;
            }

            victoryMessage = String.Format(" ({0}/{1})({2}/{3}) Would you like to play again?",
                                                winnerScore, loserScore, m_BlackWins, m_WhiteWins);
            DialogResult result = MessageBox.Show(winningPlayerText+victoryMessage, "Othello", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                startNewGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void othelloButton_Click(object obj, EventArgs e)
        {
            OthelloButton buttonClicked = (OthelloButton)obj;
            makeMove(buttonClicked.X, buttonClicked.Y);
        }

        private void makeMove(int i_X, int i_Y)
        {
            r_Logic.PlayMove(i_X, i_Y);
        }

        private void moveAI(int i_X, int i_Y)
        {
            m_AIMoveX = i_X;
            m_AIMoveY = i_Y;
            m_AIDelayTimer.Start();
        }

        private void makeAiMove(object sender, EventArgs e)
        {
            m_AIDelayTimer.Stop();
            r_Logic.PlayMove(m_AIMoveX, m_AIMoveY);
        }
    }
}
