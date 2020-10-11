using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Random_Number_Game.Definitions;

namespace Random_Number_Game
{
    public abstract class BaseRandomNumber
    {
        private int _RandomNumber;
        private int _CurrentGuessNumber;

        private int _MinRandom;
        protected int MinRandom
        {
            set { _MinRandom = value; }
        }

        private int _MaxRandom;
        protected int MaxRandom
        {
            set { _MaxRandom = value; }
        }

        private int _MaxGuesses;
        protected int MaxGuesses
        {
            set { _MaxGuesses = value; }
        }

        /// <summary>
        /// Random number generator
        /// </summary>
        protected bool GenerateRandomNumber()
        {
            Random random = new Random();

            try
            {
                _RandomNumber = random.Next(_MinRandom, _MaxRandom);
                _CurrentGuessNumber = _MaxGuesses;
                return true;
            }
            catch (Exception ex)
            {
                //TBD. Log the exception
                _RandomNumber = 0;
                return false;
            }
        }

        /// <summary>
        /// Check the guess against the random number
        /// </summary>
        protected virtual GuessResult guessResult(int guess, out int remainingGuesses)
        {
            GuessResult retval = GuessResult.Fail;
            try
            {
                if(--_CurrentGuessNumber == 0)
                {
                    retval = GuessResult.Incorrect;
                }
                else 
                {
                    retval = guess > _RandomNumber ? GuessResult.Higher :
                             guess < _RandomNumber ? GuessResult.Lower :
                             GuessResult.Correct;
                }
                remainingGuesses = _CurrentGuessNumber;
                return retval;
            }
            catch(Exception ex)
            {
                //TBD. Log the exception
                remainingGuesses = _CurrentGuessNumber;
                return GuessResult.Fail;
            }
        }
    }
}
