using DungeonCrawlers.Display;
using DungeonCrawlers.States;
using DungeonCrawlers.States.GameControl;
using DungeonCrawlers.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class CharacterCreationStateShould
    {
        private readonly Mock<IDisplayer> displayer;
        private readonly Mock<IGameController> gameController;
        private readonly Mock<ICharacterCreationSystem> characterCreation;

        public CharacterCreationStateShould()
        {
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Character creation started..."));

            characterCreation = new Mock<ICharacterCreationSystem>();
            characterCreation.Setup(x => x.Create(displayer.Object));

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new CharacterCreationState(displayer.Object, gameController.Object, characterCreation.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
        }

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var characterCreationState = new CharacterCreationState(displayer.Object, gameController.Object, characterCreation.Object);

            //When
            characterCreationState.StartState();

            //Then
            displayer.VerifyAll();
            gameController.VerifyAll();
            characterCreation.VerifyAll();
        }
    }
}