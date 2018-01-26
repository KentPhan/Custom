using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGameAndRecordKeeper
{
    class Program
    {

        public enum STATE
        {
            MAINROOM,
            QUIT
        }
        
        static void Main(string[] args)
        {

            Console.WriteLine("This program is a simple Rock Paper Scissor Game while keeping track of user score. Type 'help' for help");
            
            STATE currentState = STATE.MAINROOM;

            ScoreBoard scoreBoard = new ScoreBoard();
            
            while(currentState != STATE.QUIT)
            {
                string input = Console.ReadLine();
                
                if (input.ToLower().Equals("help"))
                {
                    Console.WriteLine("Type 'play' to play the game.");
                    Console.WriteLine("Type 'score' to see the current score board of the game.");
                    Console.WriteLine("Type 'quit' to quit the game.");
                }
                else if(input.ToLower().Equals("play"))
                {
                    Game newGame = new Game();
                    newGame.PlayGame(scoreBoard);
                }
                else if(input.ToLower().Equals("score"))
                {
                    scoreBoard.DiplayData();
                }
                else if(input.ToLower().Equals("quit"))
                {
                    currentState = STATE.QUIT;
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }
            }

            Console.WriteLine("Thanks for playing");
        }
    }
}
