using System.Collections.Generic;
using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Game.Locations;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class DungeonControllerShould
    {
        [Fact]
        public void GenerateDungeons()
        {
            //Given
            var dungeonBuilder = new Mock<IDungeonBuilder>();
            dungeonBuilder.Setup(x => x.BuildDungeons()).Returns(new List<IDungeon>());

            var dungeonController = new DungeonController();

            //When
            dungeonController.GenerateDungeons(dungeonBuilder.Object);

            //Then
            dungeonBuilder.Verify(x => x.BuildDungeons());
        }

        [Fact]
        public void DisplayDungeons()
        {
            //Given
            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Dungeon: A Dungeon"));
            var dungeons = new List<IDungeon>()
            {
                new Dungeon(new EncounterBuilder(), new EnemyController()),
            };

            var dungeonController = new DungeonController(dungeons);

            //When
            dungeonController.DisplayDungeons(displayer.Object);

            //Then
            displayer.Verify(x => x.Write("Dungeon: A Dungeon"));
        }
    }
}