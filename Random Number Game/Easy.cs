using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Random_Number_Game.Definitions;

namespace Random_Number_Game
{
    public class Easy : BaseRandomNumber
    {
        private const int MINRANDOM = 0;
        private const int MAXRANDOM = 10;
        private const int MAXGUESSES = 4;

        public int MaxRnd
        {
            get { return MAXRANDOM; }
        }

        public int MinRnd
        {
            get { return MINRANDOM; }
        }

        public int MaxGuess
        {
            get { return MAXGUESSES; }
        }

        public Easy()
        {
            MinRandom = MINRANDOM;
            MaxRandom = MAXRANDOM;
            MaxGuesses = MAXGUESSES;

            if(!GenerateRandomNumber())
            {
                throw (new Exception("Random number generator failure"));
            }
        }

        public GuessResult guessRes(int guess, out int remainingGuesses)
        {
            remainingGuesses = 0;
            return base.guessResult(guess, out remainingGuesses);
        }

    }
}
