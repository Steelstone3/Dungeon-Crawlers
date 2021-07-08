using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class CharacterCreationServiceShould
    {
        [Fact]
        public void CreateACharacterParty()
        {
            //Given
            var character = new Character("Bob");
            var characters = new List<ICharacter>();

            var displayer = new Mock<IDisplayer>();

            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildCharacter(displayer.Object)).Returns(character);
            characterBuilder.Setup(x => x.BuildCharacterParty(3)).Returns(characters);

            var characterController = new Mock<ICharacterController>();
            characterController.Setup(x => x.CreateCharacter(displayer.Object, characterBuilder.Object)).Returns(character);
            characterController.Setup(x => x.CreateCharacterParty(characterBuilder.Object, 3)).Returns(characters);
            characterController.Setup(x => x.AddPartyMember(character));
            characterController.Setup(x => x.AddPartyMembers(characters));
            
            var characterCreationService = new CharacterCreationService();
            
            //When
            characterCreationService.CreateCharacterParty(displayer.Object, characterController.Object, characterBuilder.Object, 3);

            //Then
            characterController.InSequence(new MockSequence());

            characterController.Verify(x => x.CreateCharacter(displayer.Object, characterBuilder.Object));
            characterController.Verify(x => x.CreateCharacterParty(characterBuilder.Object, 3));
            characterController.Verify(x => x.AddPartyMember(character));
            characterController.Verify(x => x.AddPartyMembers(characters));
            characterController.Verify(x => x.DisplayCharacterParty(displayer.Object));
        }
    }
}