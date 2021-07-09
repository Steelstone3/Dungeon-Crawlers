using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Controllers
{
    public class DungeonController : IDungeonController
    {
        public DungeonController()
        {

        }

        //TODO For testing purposes. Is this a good idea???
        public DungeonController(List<IDungeon> dungeons)
        {
            Dungeons = dungeons;
        }

        public IList<IDungeon> Dungeons{get; set;}
        public IDungeon CurrentDungeon { get; set; }

        public void GenerateDungeons(IDungeonBuilder dungeonBuilder)
        {
            Dungeons = dungeonBuilder.BuildDungeons();
        }

        public void DisplayDungeons(IDisplayer displayer)
        {
            foreach(var dungeon in Dungeons)
            {
                displayer.Write($"Dungeon: {dungeon.Name}");
            }
        }
    }
}