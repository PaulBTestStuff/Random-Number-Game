using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Number_Game
{
    public class Definitions
    {
        public enum GuessResult
        {
            Fail = 0,
            Incorrect = 1,
            Higher = 2,
            Lower = 3,
            Correct = 4
        }

        public enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
    }
}
