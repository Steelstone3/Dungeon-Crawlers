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
    public class CombatControllerShould
    {
        private Mock<IDisplayer> _displayer = new Mock<IDisplayer>();
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<IEnemyController> _enemyController = new Mock<IEnemyController>();
        private ICombatController _combatController = new CombatController();

        [Fact]
        public void DisplayCombatants()
        {
            //Given
            _displayer.Setup(x => x.Write("Allies"));
            _displayer.Setup(x => x.Write("Foes"));
            _characterController.Setup(x => x.DisplayParty(_displayer.Object));
            _enemyController.Setup(x => x.DisplayParty(_displayer.Object));

            //When
            _combatController.DisplayCombatants(_displayer.Object,
            _characterController.Object,
            _enemyController.Object);

            //Then
            _displayer.Verify(x => x.Write("Allies"));
            _displayer.Verify(x => x.Write("Foes"));
            _characterController.Verify(x => x.DisplayParty(_displayer.Object));
            _enemyController.Verify(x => x.DisplayParty(_displayer.Object));
        }

        [Fact]
        public void PlayerTurn()
        {
            //Given
            var monster = new Mock<IMonster>();

            var enemyParty = new List<IMonster>()
            {
                new Monster(new Goblin()),
                new Monster(new Goblin()),
                new Monster(new Goblin()),
            };

            _enemyController.Setup(x => x.PartyMembers).Returns(enemyParty);
            _characterController.Setup(x => x.SelectOpponent(_enemyController.Object.PartyMembers)).Returns(monster.Object);
            _characterController.Setup(x => x.AttackOpponent(monster.Object));

            //When
            _combatController.PlayerTurn(_displayer.Object,
            _characterController.Object,
            _enemyController.Object);

            //Then
            _characterController.InSequence(new MockSequence());
            _characterController.Verify(x => x.SelectOpponent(_enemyController.Object.PartyMembers));
            _characterController.Verify(x => x.AttackOpponent(monster.Object));
        }

        [Fact]
        public void OpponentTurn()
        {
            //Given
            var character = new Mock<ICharacter>();
            
            var characterParty = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Jeff"),
                new Character("Jeff"),
            };

            _characterController.Setup(x => x.PartyMembers).Returns(characterParty);
            _enemyController.Setup(x => x.SelectOpponent(_characterController.Object.PartyMembers)).Returns(character.Object);
            _enemyController.Setup(x => x.AttackOpponent(character.Object));

            //When
            _combatController.OpponentTurn(_displayer.Object,
            _characterController.Object,
            _enemyController.Object);

            //Then
            _enemyController.InSequence(new MockSequence());
            _enemyController.Verify(x => x.SelectOpponent(_characterController.Object.PartyMembers));
            _enemyController.Verify(x => x.AttackOpponent(character.Object));
        }
    }
}