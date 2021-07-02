using Xunit;

namespace Name
{
    public class ExplorationState
    {


        [Fact]
        public void ExecutesTheStartState()
        {
           
        }

        [Fact]
        public void ExecutesTheStopState()
        {
           
        }

        /*private Mock<IDisplayer> SetupDisplayerMock(string message)
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
        }*/
    }
}