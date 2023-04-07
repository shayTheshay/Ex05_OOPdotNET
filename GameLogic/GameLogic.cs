using Ex05_Othelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05_Othelo
{
    public delegate void NotifyWinnerDelegate(Player winner, int winnerScore, int loserScore);
    public delegate void AIActionsDelegate(int x, int y);
    public delegate void UpdateVisualsDelegate();
    public class GameLogic
    {
        private readonly Board r_Board;
        public Board Board
        {
            get { return r_Board; }
        }

        private Player m_CurrentPlayer;
        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        private readonly Player r_BlackPlayer;
        private readonly Player r_WhitePlayer;
        private List<int[]> m_LegalPlays;
        public List<int[]> LegalPlays
        {
            get { return m_LegalPlays;}
        }

        public event NotifyWinnerDelegate? EndGameActions;
        public event AIActionsDelegate? AIActions;
        public event UpdateVisualsDelegate? UpdateVisuals;

        public GameLogic(int i_Size,bool i_isAiGame, string i_WhiteName = "White", string i_BlackName = "Black")
        {
            r_Board = new Board(i_Size);
            r_WhitePlayer = new Player(i_WhiteName, ePlayerColor.White, isAi: i_isAiGame);
            r_BlackPlayer = new Player(i_BlackName, ePlayerColor.Black);
            m_CurrentPlayer = r_BlackPlayer;
            m_LegalPlays = currentLegalPlays();
        }

        public void ResetBoard()
        {
            r_Board.initializeBoard();
            m_CurrentPlayer = r_BlackPlayer;
            m_LegalPlays = currentLegalPlays();
        }

        private List<int[]> currentLegalPlays()
        {
            List<int[]> legalPlayArray = new();

            for (int i = 0; i < r_Board.Size; i++)
            {
                for (int j = 0; j < r_Board.Size; j++)
                {
                    bool isFreeSpace = r_Board.Cells[i, j].CellColor == ePlayerColor.Empty;

                    if (true == isFreeSpace)
                    {
                        bool north = checkDirection(i, j, -1, 0);
                        bool south = checkDirection(i, j, 1, 0);
                        bool east = checkDirection(i, j, 0, 1);
                        bool west = checkDirection(i, j, 0, -1);
                        bool northEast = checkDirection(i, j, -1, 1);
                        bool northWest = checkDirection(i, j, -1, -1);
                        bool southEast = checkDirection(i, j, 1, 1);
                        bool southWest = checkDirection(i, j, 1, -1);

                        if ((north || south || east || west || southEast || southWest || northEast || northWest))
                        {
                            int[] toAdd = { i, j };
                            legalPlayArray.Add(toAdd);
                        }
                    }
                }
            }

            return legalPlayArray;
        }

        private bool checkDirection(int i_X, int i_Y, int i_XOffset, int i_YOffset)
        {
            bool legality = false;
            ePlayerColor opposingLocation = ePlayerColor.Black;

            if (m_CurrentPlayer.PlayerColor == ePlayerColor.Black)
            {
                opposingLocation = ePlayerColor.White;
            }

            if (inBounds(i_X + i_XOffset, i_Y + i_YOffset) && r_Board.Cells[i_X + i_XOffset, i_Y + i_YOffset].CellColor == opposingLocation)
            {
                int accXOffset = 2 * i_XOffset, accYOffset = 2 * i_YOffset;

                while (inBounds(i_X + accXOffset, i_Y + accYOffset))
                {
                    if (r_Board.Cells[i_X + accXOffset, i_Y + accYOffset].CellColor == ePlayerColor.Empty)
                    {
                        break;
                    }

                    if (r_Board.Cells[i_X + accXOffset, i_Y + accYOffset].CellColor == m_CurrentPlayer.PlayerColor)
                    {
                        legality = true;
                        break;
                    }
                    accYOffset += i_YOffset;
                    accXOffset += i_XOffset;
                }
            }
            return legality;
        }

        private void updateDirection(int i_X, int i_Y, int i_XOffset, int i_YOffset)
        {
            ePlayerColor opposingLocation = ePlayerColor.Black;
            int accXOffset =  i_XOffset, accYOffset =  i_YOffset;

            if (m_CurrentPlayer.PlayerColor == ePlayerColor.Black)
            {
                opposingLocation = ePlayerColor.White;
            }

            while (inBounds(i_X + accXOffset, i_Y + accYOffset))
            {
                if (r_Board.Cells[i_X + accXOffset, i_Y + accYOffset].CellColor == opposingLocation)
                {
                    r_Board.Cells[i_X + accXOffset, i_Y + accYOffset].CellColor = m_CurrentPlayer.PlayerColor;
                    accYOffset += i_YOffset;
                    accXOffset += i_XOffset;
                }
                else
                {
                    break;
                }
            }
        }

        public bool CheckLegalityOfPlay(int i_X, int i_Y)
        {
            bool returnValue = false;
            int[] coordinate = { i_X, i_Y };

            if (inBounds(i_X, i_Y) && r_Board.Cells[i_X, i_Y].CellColor == ePlayerColor.Empty)
            {
                returnValue = m_LegalPlays.Find(item => item[0] == coordinate[0] && item[1] == coordinate[1]) != null;
            }

            return returnValue;
        }

        private bool inBounds(int i_X, int i_Y)
        {
            return i_X < r_Board.Size && i_Y < r_Board.Size && i_X >= 0 && i_Y >= 0;
        }

        public void PlayMove(int i_X, int i_Y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i != 0 || j != 0) && (checkDirection(i_X, i_Y, i, j) == true))
                    {
                        updateDirection(i_X, i_Y, i, j);
                    }
                }
            }

            r_Board.Cells[i_X, i_Y].CellColor = m_CurrentPlayer.PlayerColor;
            if (m_CurrentPlayer == r_BlackPlayer)
            {
                m_CurrentPlayer = r_WhitePlayer;
            }
            else
            {
                m_CurrentPlayer = r_BlackPlayer;
            }

            m_LegalPlays = currentLegalPlays();
            OnVisualUpdate();
            if (m_LegalPlays.Count == 0)
            {
                checkWinner();
            }

            if (m_CurrentPlayer.IsAi)
            {
            int[] AiCoordinate = chooseRandomMove();
            AIActions?.Invoke(AiCoordinate[0], AiCoordinate[1]);
            }
        }

        private int[] chooseRandomMove()
        {
            Random RNG = new Random();
            int[] randomValue = m_LegalPlays[RNG.Next(0, m_LegalPlays.Count())];

            return randomValue;
        }

        protected virtual void OnVisualUpdate()
        {
            UpdateVisuals?.Invoke();
        }

        private void checkWinner()
        {
            Player? winner = null;
            int blackScore = 0;
            int whiteScore = 0;
            int winnerScore=0, loserScore=0;

            for (int i = 0; i < r_Board.Size; i++)
            {
                for (int j = 0; j < r_Board.Size; j++)
                {
                    if (r_Board.Cells[i, j].CellColor == ePlayerColor.Black)
                    {
                        blackScore++;
                    }
                    if (r_Board.Cells[i, j].CellColor == ePlayerColor.White)
                    {
                        whiteScore++;
                    }
                }
            }

            if (blackScore > whiteScore)
            {
                winner = r_BlackPlayer;
                winnerScore = blackScore;
                loserScore  = whiteScore;
            }
            else if (whiteScore > blackScore)
            {
                winner = r_WhitePlayer;
                winnerScore = whiteScore;
                loserScore = blackScore;
            }
            else
            {
                winnerScore = whiteScore;
                loserScore = winnerScore;
            }
            EndGameActions?.Invoke(winner,winnerScore,loserScore);
        }
    }
}
