using System;
using System.Collections.Generic;
using System.Linq;
using DungeonCrawlers.Entities;

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

        public ICharacter SelectRandom(IEnumerable<ICharacter> characterParty)
        {
            Random random = new();
            return characterParty.ToArray()[random.Next(0, characterParty.Count() - 1)];
        }

        public IMonster SelectRandom(IEnumerable<IMonster> monsterParty)
        {
            Random random = new();
            return monsterParty.ToArray()[random.Next(0, monsterParty.Count() - 1)];
        }
    }
}