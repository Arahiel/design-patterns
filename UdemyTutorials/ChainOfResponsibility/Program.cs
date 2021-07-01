using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    public class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Creatures.AddRange(
            new List<Creature> { 
                new Goblin(game),
                new Goblin(game),
                new Goblin(game),
                new GoblinKing(game)
                });

            PrintCreatureProperties(game.Creatures);

            Console.WriteLine();
            ((Goblin)game.Creatures[0]).Dispose();
            game.Creatures.RemoveAt(0);
            PrintCreatureProperties(game.Creatures);

            Console.WriteLine();
            game.Creatures.Add(new GoblinKing(game));
            PrintCreatureProperties(game.Creatures);

            Console.WriteLine();
            ((Goblin)game.Creatures[3]).Dispose();
            game.Creatures.RemoveAt(3);
            PrintCreatureProperties(game.Creatures);

            Console.ReadKey();
        }

        private static void PrintCreatureProperties(List<Creature> goblinList)
        {
            foreach (var goblin in goblinList)
            {
                Console.WriteLine($"Goblin {goblinList.IndexOf(goblin)}: Attack: {goblin.Attack}, Defense: {goblin.Defense}");
            }
        }
    }
}
