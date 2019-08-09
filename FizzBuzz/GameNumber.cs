using System;

namespace FizzBuzz
{
    public class GameNumber
    {
        private int Number { get; }

        public GameNumber(int value)
        {
            this.Number = value;
        }

        public string Say()
        {
            if (Isdivisible(3) && Isdivisible(5))
                return "FizzBuzz";

            if (Isdivisible(3))
                return "Fizz";

            if (Isdivisible(5))
                return "Buzz";

            return Number.ToString();
        }

        private bool Isdivisible(int baseVal)
        {
            return Number % baseVal == 0;
        }
    }
}