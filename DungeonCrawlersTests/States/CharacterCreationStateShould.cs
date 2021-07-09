using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;
using DungeonCrawlers.Contracts.Builders;

namespace DungeonCrawlersTests
{
    public class CharacterCreationStateShould
    {
        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var message = "Character creation";
            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterController();
            var characterBuilder = SetupCharacterBuilderMock(displayer);
            var characterCreationService = SetupCharacterCreationService(displayer, characterController, characterBuilder);
            var gameController = SetupGameController(displayer, characterCreationService, characterBuilder, characterController);

            var characterCreationState = new CharacterCreationState(displayer.Object,
            gameController.Object,
            characterCreationService.Object,
            characterBuilder.Object,
            characterController.Object);

            //When
            characterCreationState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            characterCreationService.Verify(x => x.CreateCharacterParty(displayer.Object, characterController.Object, characterBuilder.Object, 3));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //Given
            var message = "Starting game...";
            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterController();
            var characterBuilder = SetupCharacterBuilderMock(displayer);
            var characterCreationService = SetupCharacterCreationService(displayer, characterController, characterBuilder);
            var gameController = SetupGameController(displayer, characterCreationService, characterBuilder, characterController);

            var characterCreationState = new CharacterCreationState(displayer.Object,
            gameController.Object,
            characterCreationService.Object,
            characterBuilder.Object,
            characterController.Object);

            //When
            characterCreationState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            gameController.Verify(x => x.CurrentGameState.StartState());
        }

        private Mock<IDisplayer> SetupDisplayerMock(string message)
        {
            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write(message));

            return displayer;
        }

        private Mock<IGameController> SetupGameController(Mock<IDisplayer> displayer, Mock<ICharacterCreationService> characterCreationService, Mock<ICharacterBuilder> characterBuilder, Mock<ICharacterController> characterController)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new CharacterCreationState(displayer.Object, gameController.Object, characterCreationService.Object, characterBuilder.Object, characterController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }

        private Mock<ICharacterCreationService> SetupCharacterCreationService(Mock<IDisplayer> displayer, Mock<ICharacterController> characterController, Mock<ICharacterBuilder> characterBuilder)
        {
            var characterCreationService = new Mock<ICharacterCreationService>();
            characterCreationService.Setup(x => x.CreateCharacterParty(displayer.Object, characterController.Object, characterBuilder.Object, 3));

            return characterCreationService;
        }

        private Mock<ICharacterBuilder> SetupCharacterBuilderMock(Mock<IDisplayer> displayer)
        {
            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildCharacter(displayer.Object));

            return characterBuilder;
        }

        private Mock<ICharacterController> SetupCharacterController()
        {
            var characterController = new Mock<ICharacterController>();

            return characterController;
        }
    }
}