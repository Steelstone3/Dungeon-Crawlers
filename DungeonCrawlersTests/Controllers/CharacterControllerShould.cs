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

            Assert.NotNull(character);
        }

        [Theory(Skip = "This test first followed by")]
        [InlineData(0, 1)]
        [InlineData(5, 4)]
        [InlineData(-1, 1)]
        [InlineData(10, 4)]
        public void CreateACharacterPartyWithLimits(int partySize, int expectedSize)
        {
            //Given
            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildCharacterParty()).Returns(new List<ICharacter>());
            var characterController = new CharacterController();

            //When
            var characterParty = characterController.CreateCharacterParty(partySize);
            
            //Then
            characterBuilder.Verify(x => x.BuildCharacterParty());

            Assert.NotEmpty(characterParty);
            Assert.NotNull(characterParty);
            Assert.Equal(expectedSize, characterParty.Count);
        }

        [Fact(Skip ="bob")]
        public void DisplayPartyMembers()
        {
            var characterParty = new List<string>()
            {
                "Bob the Human Knight",
                "Gerald the Elf Wizard"
            };

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.WriteMenu(characterParty));

            var characterController = new CharacterController();

            characterController.DisplayCharacterParty(displayer.Object);
        }

        [Fact(Skip ="Not implemented yet")]
        public void DisplayPartyMembersAbilities()
        {

        }
    }
}