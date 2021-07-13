using System;
using DungeonCrawlers.Contracts.Game.Characters;
using DungeonCrawlers.Contracts.Game.Characters.Race;

namespace DungeonCrawlers.Game.Enemies
{
    public class Monster : IMonster
    {
        public Monster(IMonsterRace race)
        {
            Race = race;
            Name = "Jeff";
            Description = string.Empty;
        }

        public IMonsterRace Race { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}