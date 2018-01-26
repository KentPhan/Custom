using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGameAndRecordKeeper
{
    public class ScoreBoard
    {
        //Track Scores
        private int PlayerWins;
        private int PlayerLosses;
        private int Draws;
        /// <summary>
        /// Total Games Played
        /// </summary>
        private int TotalGames
        {
            get
            {
                return PlayerWins + PlayerLosses + Draws;
            }
        }

        /// <summary>
        /// Calculate Win Ratio
        /// </summary>
        private string WinRatio
        {
            get
            {

                return ((float)PlayerWins / (float)TotalGames).ToString("0.00");
            }
        }
        
        // Track Options Played
        private int RocksPlayed;
        private int PapersPlayed;
        private int ScissorsPlayed;
        
        #region Constructor

        public ScoreBoard()
        {
            this.PlayerWins = 0;
            this.PlayerLosses = 0;
            this.RocksPlayed = 0;
            this.PapersPlayed = 0;
            this.ScissorsPlayed = 0;
        }

        #endregion

        #region Publics

        public void MarkPlayerWin(PlayOption playerPlayed)
        {
            IncrementPlayOption(playerPlayed);
            this.PlayerWins++;
        }

        public void MarkPlayerLoss(PlayOption playerPlayed)
        {
            IncrementPlayOption(playerPlayed);
            this.PlayerLosses++;
        }

        public void MarkDraw(PlayOption playerPlayed)
        {
            IncrementPlayOption(playerPlayed);
            this.Draws++;
        }
        
        public void DiplayData()
        {
            Console.WriteLine("Total Games:" + this.TotalGames);
            Console.WriteLine("Player Wins:" + this.PlayerWins);
            Console.WriteLine("Player Losses:" + this.PlayerLosses);
            Console.WriteLine("Draws:" + this.Draws);
            Console.WriteLine("Rocks Played:" + this.RocksPlayed);
            Console.WriteLine("Papers Played:" + this.PapersPlayed);
            Console.WriteLine("Scissors Played:" + this.ScissorsPlayed);
            Console.WriteLine("Win Ratio:" + this.WinRatio);
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Increment proper Play Option Count
        /// </summary>
        /// <param name="playerPlayed"></param>
        private void IncrementPlayOption(PlayOption playerPlayed)
        {
            if (playerPlayed == PlayOption.PAPER)
            {
                this.PapersPlayed++;
            }
            else if (playerPlayed == PlayOption.ROCK)
            {
                this.RocksPlayed++;
            }
            else
            {
                this.ScissorsPlayed++;
            }
        }

        #endregion

    }
}
