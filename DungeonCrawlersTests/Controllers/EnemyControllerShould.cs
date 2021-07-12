using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Characters;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Game.Characters;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class EnemyControllerShould
    {
        private Mock<IDisplayer> _displayer = new Mock<IDisplayer>();
        private IEnemyController _enemyController = new EnemyController();

        [Fact]
        public void GenerateEnemies()
        {
            _enemyController.GenerateEnemies();

            Assert.NotNull(_enemyController.PartyMembers);
            Assert.NotEmpty(_enemyController.PartyMembers);
        }

        [Fact]
        public void DisplayEnemyPartyMembers()
        {
            //Given
            _displayer.Setup(x => x.Write("Jeff the Goblin"));
            _enemyController.GenerateEnemies();

            //When
            _enemyController.DisplayParty(_displayer.Object);

            //Then
            _displayer.Verify(x => x.Write("Jeff the Goblin"));
        }

        [Fact(Skip = "Skip")]
        public void AutomaticallySelectPlayer()
        {
            //Given
            //When
            //Then
        }

        [Fact]
        public void AutomaticallySelectOpponent()
        {
            //Given
            _displayer.Setup(x => x.Write("Jeff the Human Knight"));

            var characters = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Jeff"),
                new Character("Jeff"),
            };

            //When
            var character = _enemyController.SelectOpponent(_displayer.Object, characters);

            //Then
            _displayer.Verify(x => x.Write("Jeff the Human Knight"));
            Assert.NotNull(character);
        }

        [Fact(Skip = "Not implemented yet")]
        public void AutomaticallyAttackOpponent()
        {
            //Given
            //When
            //Then
        }

        //Cycle through each party member
        //Display that characters abilities
        //Allow the player to select an opponent
        //Allow the player to select the character ability
        //The character ability
    }
}