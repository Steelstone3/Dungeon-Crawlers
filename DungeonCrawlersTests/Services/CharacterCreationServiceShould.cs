using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
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
            var displayer = new Mock<IDisplayer>();

            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildCharacter(displayer.Object));

            var characterController = new Mock<ICharacterController>();
            characterController.Setup(x => x.CreateCharacter(displayer.Object, characterBuilder.Object));
            characterController.Setup(x => x.CreateCharacterParty(3));
            var characterCreationService = new CharacterCreationService();
            
            //When
            characterCreationService.CreateCharacterParty(displayer.Object, characterController.Object, characterBuilder.Object, 3);

            //Then
            characterController.Verify(x => x.CreateCharacter(displayer.Object, characterBuilder.Object));
            characterController.Verify(x => x.CreateCharacterParty(3));
            characterController.Verify(x => x.DisplayCharacterParty(displayer.Object));
        }
    }
}