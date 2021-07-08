using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Controllers;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class LocationControllerShould
    {
        [Fact]
        public void GenerateDungeons()
        {
            //Given
            var locationBuilder = new Mock<ILocationBuilder>();
            locationBuilder.Setup(x => x.BuildDungeons()).Returns(new List<IDungeon>());

            var locationController = new LocationController();

            //When
            locationController.GenerateDungeons(locationBuilder.Object);

            //Then
            locationBuilder.Verify(x => x.BuildDungeons());
        }
    }
}