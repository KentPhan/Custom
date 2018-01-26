using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGameAndRecordKeeper
{
    public class Game
    {
        public Game()
        {

        }
        
        public void PlayGame(ScoreBoard scoreBoard)
        {
            Console.WriteLine("Type 'rock', 'paper', or'scissors'");


            string playerPlayed = Console.ReadLine();
            if (playerPlayed.ToLower().Equals("rock"))
            {

            }
            else if (playerPlayed.ToLower().Equals("paper"))
            {

            }
            else if (playerPlayed.ToLower().Equals("scissors"))
            {

            }
            else if (playerPlayed.ToLower().Equals("quit"))
            {

            }
            else
            {

            }

        }

        



    }
}
