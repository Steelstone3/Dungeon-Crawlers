using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class CharacterControllerShould
    {
        [Fact]
        public void CreateACharacter()
        {
            var displayer = new Mock<IDisplayer>();
            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildCharacter(displayer.Object)).Returns(new Character("bob"));
            var characterController = new CharacterController();

            var character = characterController.CreateCharacter(displayer.Object, characterBuilder.Object);

            characterBuilder.Verify(x => x.BuildCharacter(displayer.Object));
        }

        [Fact]
        public void CreateACharacterPartyWithLimits()
        {
            //Given
            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildCharacterParty(3)).Returns(new List<ICharacter>());
            var characterController = new CharacterController();

            //When
            var characterParty = characterController.CreateCharacterParty(characterBuilder.Object, 3);

            //Then
            characterBuilder.Verify(x => x.BuildCharacterParty(3));
        }

        [Fact]
        public void DisplayPartyMembers()
        {
            //Given
            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Jeff the Human Knight"));
            displayer.Setup(x => x.Write("Bob the Human Knight"));
            displayer.Setup(x => x.Write("Steve the Human Knight"));

            var characters = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Bob"),
                new Character("Steve"),
            };

            var characterController = new CharacterController();
            characterController.AddPartyMembers(characters);

            //When
            characterController.DisplayCharacterParty(displayer.Object);

            //Then
            displayer.Verify(x => x.Write("Jeff the Human Knight"));
            displayer.Verify(x => x.Write("Bob the Human Knight"));
            displayer.Verify(x => x.Write("Steve the Human Knight"));
        }

        [Fact]
        public void AddCharacterToParty()
        {
            //Given
            ICharacterController characterController = new CharacterController();
            ICharacter character = new Character("Jeff");

            //When
            characterController.AddPartyMember(character);

            //Then
            Assert.NotNull(characterController.PartyMembers);
            Assert.NotEmpty(characterController.PartyMembers);
            Assert.Equal(1, characterController.PartyMembers.Count);
        }

        [Fact]
        public void AddCharactersToParty()
        {
            //Given
            var characterController = new CharacterController();
            var characters = new List<ICharacter>()
            {
                new Character("Jeff"),
                new Character("Bob"),
                new Character("Steve"),
            };

            //When
            characterController.AddPartyMembers(characters);

            //Then
            Assert.NotNull(characterController.PartyMembers);
            Assert.NotEmpty(characterController.PartyMembers);
            Assert.Equal(3, characterController.PartyMembers.Count);
        }

        [Fact(Skip = "Not implemented yet")]
        public void DisplayPartyMembersAbilities()
        {

        }
    }
}