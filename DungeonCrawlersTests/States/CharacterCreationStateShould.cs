using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;

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
            var characterCreationService = SetupCharacterCreationService(characterController);
            var gameController = SetupGameController(displayer, characterCreationService, characterController);

            var characterCreationState = new CharacterCreationState(displayer.Object,
            gameController.Object,
            characterCreationService.Object,
            characterController.Object);

            //When
            characterCreationState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            characterCreationService.Verify(x => x.CreateCharacterParty(characterController.Object, 3));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //Given
            var message = "Starting game...";
            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterController();
            var characterCreationService = SetupCharacterCreationService(characterController);
            var gameController = SetupGameController(displayer, characterCreationService, characterController);

            var characterCreationState = new CharacterCreationState(displayer.Object, gameController.Object, characterCreationService.Object, characterController.Object);
            
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

        private Mock<IGameController> SetupGameController(Mock<IDisplayer> displayer, Mock<ICharacterCreationService> characterCreationService, Mock<ICharacterController> characterController)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new CharacterCreationState(displayer.Object, gameController.Object, characterCreationService.Object, characterController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }

        private Mock<ICharacterCreationService> SetupCharacterCreationService(Mock<ICharacterController> characterController)
        {
            var characterCreationService = new Mock<ICharacterCreationService>();
            characterCreationService.Setup(x => x.CreateCharacterParty(characterController.Object, 3));

            return characterCreationService;
        }

        private Mock<ICharacterController> SetupCharacterController()
        {
            var characterController = new Mock<ICharacterController>();

            return characterController;
        }
    }
}