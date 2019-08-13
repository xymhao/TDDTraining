﻿using System;

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

            if (IsDivisible(3) || IsContainsNumber())
                return "Fizz";

            if (IsDivisible(5))
                return "Buzz";

            return Number.ToString();
        }

        private bool IsContainsNumber()
        {
            return Number.ToString().Contains("3");
        }

        private bool IsDivisible(int baseVal)
        {
            return Number % baseVal == 0;
        }

    }
}