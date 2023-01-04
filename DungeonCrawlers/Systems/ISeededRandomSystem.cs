using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface ISeededRandomSystem
    {
        int[] CreateSeeds(int quantity);
        ulong GetSeededRandom(int seed, ulong lowerBound, ulong upperBound);
        ulong GetRandom(ulong lowerBound, ulong upperBound);
        ICharacter SelectRandom(IEnumerable<ICharacter> characterParty);
        IMonster SelectRandom(IEnumerable<IMonster> monsterParty);
    }
}