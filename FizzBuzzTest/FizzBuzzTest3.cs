using System;
using NUnit.Framework;

namespace FizzBuzzTest
{
    //1,2,Fizz,4,Buzz,fizz,7,8,fizz,buzz
    [TestFixture]
    public class FizzBuzzTest3
    {
        [Test]
        [TestCase(arg1: 1, arg2: "1")]
        [TestCase(arg1: 3, arg2: "Fizz")]
        [TestCase(arg1: 5, arg2: "Buzz")]
        [TestCase(arg1: 15, arg2: "FizzBuzz")]
        public static void AssertGameNumber(int value, string expectNumber)
        {
            var game = new GameNumber3(number: value);
            Assert.AreEqual(expected: expectNumber, game.Say());
        }
    }

    internal class GameNumber3
    {
        public int Number { get; }

        public GameNumber3(int number)
        {
            this.Number = number;
        }

        internal string Say()
        {
            if (Number % 3 == 0 && Number % 5 == 0)
                return "FizzBuzz";

            if (IsDivisible(number: 3))
                return "Fizz";

            if (IsDivisible(number: 5))
                return "Buzz";

            return Number.ToString();
        }

        private bool IsDivisible(int number)
        {
            return Number % number == 0;
        }
    }
}