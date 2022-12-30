using System;

namespace DungeonCrawlers.Systems
{
    public class SeededRandomSystem : ISeededRandomSystem
    {
        public ulong GetSeededRandom(int seed, ulong lowerBound, ulong upperBound)
        {
            Random random = new(seed);
            return (ulong)random.NextInt64((long)lowerBound, (long)upperBound);
        }
    }
}