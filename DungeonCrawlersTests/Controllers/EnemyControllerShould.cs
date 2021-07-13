using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Characters;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.Characters.Enemies;
using DungeonCrawlers.Game.Enemies;
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
            _displayer.Setup(x => x.Write("Health: 10, Jeff the Goblin"));
            _enemyController.GenerateEnemies();

            //When
            _enemyController.DisplayParty(_displayer.Object);

            //Then
            _displayer.Verify(x => x.Write("Health: 10, Jeff the Goblin"));
        }

        [Fact]
        public void AutomaticallySelectOpponent()
        {
            //Given
            var characters = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Jeff"),
                new Character("Jeff"),
            };

            //When
            var character = _enemyController.SelectOpponent(_displayer.Object, characters);

            //Then
            Assert.NotNull(character);
        }

        [Fact]
        public void AutomaticallyAttackOpponent()
        {
            //Given
            var character = new Character("Jeff");
            var monster = new Monster(new Goblin());
            
            _enemyController.GenerateEnemies();

            //When
            _enemyController.AttackOpponent(character);

            //Then
            Assert.NotNull(character);
            Assert.InRange(character.CombatRole.Health, 25, 29);
        }

        //Cycle through each party member
        //Display that characters abilities
        //Allow the player to select an opponent
        //Allow the player to select the character ability
        //The character ability
    }
}