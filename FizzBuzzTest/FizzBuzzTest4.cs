using System;
using System.Collections.Generic;
using System.Text;
using FizzBuzz;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FizzBuzzTest
{
    [TestFixture]
    public class FizzBuzzTest4
    {
        [TestCase("1", 1)]
        [TestCase("Fizz", 3)]
        [TestCase("Buzz", 5)]
        [TestCase("FizzBuzz", 15)]
        public void AssertGameNumber(string expectedValue, int number)
        {
            var game = new GameNumber4(number);
            Assert.AreEqual(expectedValue, game.Say());
        }
    }

    public class GameNumber4
    {
        public int Number { get; set; }
        public GameNumber4(int number)
        {
            Number = number;
        }

        public object Say()
        {
            if (IsDivisibleBy((15)))
                return "FizzBuzz";

            if (IsDivisibleBy(3))
                return "Fizz";

            if (IsDivisibleBy(5))
                return "Buzz";

            return Number.ToString();
        }

        private bool IsDivisibleBy(int value)
        {
            return Number % value == 0;
        }
    }
}
