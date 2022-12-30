using System;
using System.Collections.Generic;

namespace DungeonCrawlers.Systems
{
    public class SeededRandomSystem : ISeededRandomSystem
    {
        public int[] CreateSeeds(int quantity)
        {
            Random random = new();

            List<int> seeds = new();

            for (int i = 0; i < quantity; i++)
            {
                seeds.Add(random.Next());
            }

            return seeds.ToArray();
        }

        public ulong GetSeededRandom(int seed, ulong lowerBound, ulong upperBound)
        {
            Random random = new(seed);
            return (ulong)random.NextInt64((long)lowerBound, (long)upperBound);
        }
    }
}