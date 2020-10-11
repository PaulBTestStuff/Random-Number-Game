using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Random_Number_Game.Definitions;

namespace Random_Number_Game
{
    public class GameControl
    {
        private Easy easy;
        private Medium medium;
        private Hard hard;

        private Difficulty _CurrentDifficulty;

        /// <summary>
        /// Generates instance of the required difficulty class. Called from the UI
        /// </summary>
        public void SetNewGame(Difficulty difficulty)
        {
            try
            {
                // Could do this with reflection. Is it worth it? 

                easy = null;
                medium = null;
                hard = null;

                _CurrentDifficulty = difficulty;

                switch (_CurrentDifficulty)
                {
                    case Difficulty.Easy: easy = new Easy(); break;
                    case Difficulty.Medium: medium = new Medium(); break;
                    case Difficulty.Hard: hard = new Hard(); break;
                }
            }
            catch (Exception Ex)
            {
                //TBD. Log the exception
                throw(new Exception("New game failure"));
            }
        }

        /// <summary>
        /// Guess processing. Checks the user's guess and return the results
        /// </summary>
        public GuessResult CheckGuess(int guess, out int remainingGuesses)
        {
            remainingGuesses = 0;
            try
            {
                switch (_CurrentDifficulty)
                {
                    case Difficulty.Easy: return easy.guessRes(guess, out remainingGuesses);
                    case Difficulty.Medium: return medium.guessRes(guess, out remainingGuesses);
                    case Difficulty.Hard: return hard.guessRes(guess, out remainingGuesses);
                }
                return GuessResult.Fail;
            }
            catch (Exception ex)
            {
                //TBD. Log the exception
                return GuessResult.Fail;
            }
        }

        /// <summary>
        /// Puts together display text containing the number range
        /// </summary>
        public string GetStatusText()
        {
            int minrnd = 0;
            int maxrnd = 0;

            try
            {
                switch (_CurrentDifficulty)
                {
                    case Difficulty.Easy:
                        minrnd = easy.MinRnd;
                        maxrnd = easy.MaxRnd;
                        break;

                    case Difficulty.Medium:
                        minrnd = medium.MinRnd;
                        maxrnd = medium.MaxRnd;
                        break;

                    case Difficulty.Hard:
                        minrnd = hard.MinRnd;
                        maxrnd = hard.MaxRnd;
                        break;
                }
                return ("Guess a number between " + minrnd + " and " + maxrnd + ". ");

            }
            catch (Exception ex)
            {
                //TBD. Log the exception
                return ("Status text failure. ");
            }
        }

    }
}
