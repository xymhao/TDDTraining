using System;
using NUnit.Framework;
using FizzBuzz;

namespace FizzBuzzTest
{
    public class FizzBuzzTest
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        [TestCase(8)]
        public void Should_Say_1_When_Value(int value)
        {
            AssertGameNumber(value.ToString(), value);
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        public void Should_Say_Fizz_When_Value_is_Divisible_3(int value)
        {
            AssertGameNumber("Fizz", value);
        }

        [TestCase(5)]
        [TestCase(10)]
        public void Should_Say_Buzz_Value_Is_divisible_5(int value)
        {
            AssertGameNumber("Buzz", value);
        }

        [TestCase(15)]
        public void Should_Say_FizzBuzz_is_divisible_3_5(int value)
        {
            AssertGameNumber("FizzBuzz", value);
        }

        [Test]
        public void Should_Say_Fizz_Whern_Value_Contains_3()
        {
            AssertGameNumber("Fizz", 13);
        }

        [Test]
        public void Should_Say_Buzz_Whern_Value_Contains_5()
        {
            AssertGameNumber("Buzz", 51);
        }

        private static void AssertGameNumber(string expectedWords, int value)
        {
            var game = new GameNumber(value);
            Assert.AreEqual(expectedWords, game.Say());
        }
    }
}
//1,2,Fizee,4,Buzz,Fizz....14,FizzBuzz