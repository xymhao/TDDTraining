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

        public GameNumber()
        {
        }

        public string Say()
        {
            if (IsDivisible(3) && IsDivisible(5))
                return "FizzBuzz";

            if (IsDivisible(3) || IsContainsNumber(3))
                return "Fizz";

            if (IsDivisible(5) || IsContainsNumber(5))
                return "Buzz";

            return Number.ToString();
        }

        private bool IsContainsNumber(int number)
        {
            return Number.ToString().Contains(number.ToString());
        }

        private bool IsDivisible(int baseVal)
        {
            return Number % baseVal == 0;
        }

    }
}