using System;
using System.Linq;
using FizzBuzz;

namespace FIzzBuzzConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var number in Enumerable.Range(1, 100))
            {
                var game = new GameNumber(number);
                Console.WriteLine(game.Say());
            }
            
            Console.Read();
        }
    }
}
