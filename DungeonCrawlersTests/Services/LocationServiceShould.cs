using System.Collections.Generic;
using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Game.Locations;
using DungeonCrawlers.Services;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class LocationServiceShould
    {
        [Fact]
        public void GenerateDungeon()
        {
            //Given
            var dungeonBuilder = new Mock<IDungeonBuilder>();
            var dungeonController = new Mock<IDungeonController>();
            dungeonController.Setup(x => x.GenerateDungeons(dungeonBuilder.Object));
            var dungeonCreationService = new LocationService();

            //When
            dungeonCreationService.GenerateDungeons(dungeonController.Object, dungeonBuilder.Object);

            //Then
            dungeonController.Verify(x => x.GenerateDungeons(dungeonBuilder.Object));
        }

        [Fact]
        public void DisplayLocations()
        {
            //Given
            var displayer = new Mock<IDisplayer>();
            var dungeonController = new Mock<IDungeonController>();
            dungeonController.Setup(x => x.DisplayDungeons(displayer.Object));

            var locationService = new LocationService();

            //When
            locationService.DisplayLocations(displayer.Object, dungeonController.Object);

            //Then
            dungeonController.Verify(x => x.DisplayDungeons(displayer.Object));
        }

        [Fact]
        public void SelectLocation()
        {
            //Given
            var displayer = new Mock<IDisplayer>();

            var dungeons = new List<IDungeon>()
            {
                new Dungeon(new EncounterBuilder(), new EnemyController()),
                new Dungeon(new EncounterBuilder(), new EnemyController()),
                new Dungeon(new EncounterBuilder(), new EnemyController()),
            };

            var locationService = new LocationService();

            //When
            var dungeon = locationService.SelectLocation(displayer.Object, dungeons);

            //Then
            displayer.Verify(x => x.ReadNumeric("Select dungeon to enter:", 0, dungeons.Count - 1));
            Assert.NotNull(dungeon);
        }
    }
}