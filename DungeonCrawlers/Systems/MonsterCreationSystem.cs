using System.Collections.Generic;
using DungeonCrawlers.Assets;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public class MonsterCreationSystem : IMonsterCreationSystem
    {
        public IEnumerable<IMonster> CreateMultiple(int quantity, int[] seeds)
        {
            var monsterParty = new List<IMonster>();

            for (int i = 0; i < quantity; i++)
            {
                monsterParty.Add(CreateRandomMonster(seeds[0], seeds[i]));
            }

            return monsterParty;
        }

        private static IMonster CreateRandomMonster(int raceSeed, int seed)
        {
            return new Monster
            (
                new Name
                (
                    "",
                    MonsterNames.GetRandomFirstName(seed),
                    MonsterNames.GetRandomSurname(seed),
                    ""
                ),
                new Race
                (
                    MonsterNames.GetRandomRace(raceSeed)
                ),
                new Health(100, 100, 25)
            );
        }

    }
}