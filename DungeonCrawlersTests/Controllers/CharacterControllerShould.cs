using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Characters;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.Characters.Enemies;
using DungeonCrawlers.Game.Enemies;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class CharacterControllerShould
    {
        private Mock<IDisplayer> _displayer = new Mock<IDisplayer>();
        private Mock<ICharacterBuilder> _characterBuilder = new Mock<ICharacterBuilder>();
        private ICharacterController _characterController = new CharacterController();
        private Mock<ICharacter> _character = new Mock<ICharacter>();

        [Fact]
        public void CreateACharacter()
        {
            _characterBuilder.Setup(x => x.BuildCharacter(_displayer.Object)).Returns(_character.Object);
            _characterController = new CharacterController();

            var character = _characterController.CreateCharacter(_displayer.Object, _characterBuilder.Object);

            _characterBuilder.Verify(x => x.BuildCharacter(_displayer.Object));
        }

        [Fact]
        public void CreateACharacterPartyWithLimits()
        {
            //Given
            _characterBuilder.Setup(x => x.BuildCharacterParty(3)).Returns(new List<ICharacter>());
            _characterController = new CharacterController();

            //When
            var characterParty = _characterController.CreateCharacterParty(_characterBuilder.Object, 3);

            //Then
            _characterBuilder.Verify(x => x.BuildCharacterParty(3));
        }

        [Fact(Skip = "Need to implement combat abilities")]
        public void DisplayCharacterAbilities()
        {
            _displayer.Setup(x => x.Write("Jeff the Human Knight"));
            _displayer.Setup(x => x.Write("Some Ability"));
            _displayer.Setup(x => x.Write("Some Other Ability"));

            _characterController.DisplayCharacterAbilities(_displayer.Object, new Character("Jeff"));

            _displayer.Verify(x => x.Write("Jeff the Human Knight"));
            _displayer.Verify(x => x.Write("Some Ability"));
            _displayer.Verify(x => x.Write("Some Other Ability"));
        }

        [Fact]
        public void DisplayPartyMembers()
        {
            //Given
            _displayer.Setup(x => x.Write("Jeff the Human Knight"));
            _displayer.Setup(x => x.Write("Bob the Human Knight"));
            _displayer.Setup(x => x.Write("Steve the Human Knight"));

            var characters = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Bob"),
                new Character("Steve"),
            };

            _characterController.AddPartyMembers(characters);

            //When
            _characterController.DisplayParty(_displayer.Object);

            //Then
            _displayer.Verify(x => x.Write("Jeff the Human Knight"));
            _displayer.Verify(x => x.Write("Bob the Human Knight"));
            _displayer.Verify(x => x.Write("Steve the Human Knight"));
        }

        [Fact]
        public void AddCharacterToParty()
        {
            //When
            _characterController.AddPartyMember(_character.Object);

            //Then
            Assert.NotNull(_characterController.PartyMembers);
            Assert.NotEmpty(_characterController.PartyMembers);
            Assert.Equal(1, _characterController.PartyMembers.Count);
        }

        [Fact]
        public void AddCharactersToParty()
        {
            //Given
            var characters = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Bob"),
                new Character("Steve"),
            };

            //When
            _characterController.AddPartyMembers(characters);

            //Then
            Assert.NotNull(_characterController.PartyMembers);
            Assert.NotEmpty(_characterController.PartyMembers);
            Assert.Equal(3, _characterController.PartyMembers.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void SelectPlayer(int selection)
        {
            //Given
            _displayer.Setup(x => x.Write("Jeff the Human Knight"));
            _displayer.Setup(x => x.ReadNumeric("Select character:", 0, 2)).Returns(selection);

            var characters = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Jeff"),
                new Character("Jeff"),
            };

            _characterController.AddPartyMembers(characters);

            //When
            var character = _characterController.SelectPlayer(_displayer.Object);

            //Then
            _displayer.Verify(x => x.Write("Jeff the Human Knight"));
            _displayer.Verify(x => x.ReadNumeric("Select character:", 0, 2));
            Assert.NotNull(character);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void SelectOpponent(int selection)
        {
            //Given
            _displayer.Setup(x => x.Write("Jeff the Goblin"));
            _displayer.Setup(x => x.ReadNumeric("Select opponent:", 0, 3)).Returns(selection);

            var enemies = new List<IMonster>()
            {
                new Monster(new Goblin()),
                new Monster(new Goblin()),
                new Monster(new Goblin()),
                new Monster(new Goblin()),
            };

            //When
            var monster = _characterController.SelectOpponent(_displayer.Object, enemies);

            //Then
            _displayer.Verify(x => x.Write("Jeff the Goblin"));
            _displayer.Verify(x => x.ReadNumeric("Select opponent:", 0, 3));
            Assert.NotNull(monster);
        }

        [Theory(Skip ="Next")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void AttackOpponent(int selection)
        {
            //Given
            var character = new Mock<ICharacter>();
            var monster = new Mock<IMonster>();
            monster.Setup(x => x.Health).Returns(50);

            _displayer.Setup(x => x.ReadNumeric("Select combat ability:", 0, 3)).Returns(selection);

            //When
            var damagedMonster = _characterController.AttackOpponent(_displayer.Object, character.Object, monster.Object);

            //Then
            _displayer.Verify(x => x.ReadNumeric("Select combat ability:", 0, 3));
            Assert.NotNull(damagedMonster);
            Assert.NotEqual(monster.Object.Health, damagedMonster.Health);
        }
    }
}