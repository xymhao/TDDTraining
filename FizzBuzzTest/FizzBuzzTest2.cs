using NUnit.Framework;

namespace FizzBuzzTest
{
    //1,2,fizz,4,buzz,....,14,fizz buzz
    [TestFixture]
    public class FizzBuzzTest2
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Say_Number_When_Value_Number()
        {
            AssertGameNumber(1, "1");
        }

        [Test]
        public void Should_Say_Fizz_When_Isdivisble_3()
        {
            AssertGameNumber(3, "Fizz");
        }

        [Test]
        public void Should_Say_Buzz_When_isDivisible_5()
        {
            AssertGameNumber(5, "Buzz");
        }

        [Test]
        public void Should_Say_FizzBuzz_When_IsDivisible_3_5()
        {
            AssertGameNumber(15, "FizzBuzz");
        }
        private static void AssertGameNumber(int value, string expectedValue)
        {
            var game = new GameNumberNew(value);
            Assert.AreEqual(game.Say(), expectedValue);
        }
    }

    public class GameNumberNew
    {
        public int Number { get; }

        public GameNumberNew(int number)
        {
            Number = number;
        }

        public string Say()
        {
            if (Number % 3==0 && Number % 5 == 0)
            {
                return "FizzBuzz";
            }
            if (Number % 5 == 0)
                return "Buzz";
            if (Number % 3 == 0)
            {
                return "Fizz";
            }
            return Number.ToString();
        }
    }
}
