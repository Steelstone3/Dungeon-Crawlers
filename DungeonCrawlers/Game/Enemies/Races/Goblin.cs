using System;
using DungeonCrawlers.Game.Characters.Races.MonsterRaces;

namespace DungeonCrawlers.Game.Characters.Enemies
{
    public class Goblin : MonsterRace
    {
        public Goblin()
        {
            Name = nameof(Goblin);
            Description = string.Empty;
            Health = 10;
            Damage = new Random().Next(1, 5);
        }
    }
}