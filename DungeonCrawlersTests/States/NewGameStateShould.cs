using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.States;
using DungeonCrawlers.States.Interfaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class NewGameStateShould
    {
        private readonly Mock<IGameStateRepository> gameStateRepository = new();
        private readonly Mock<IPresenter> presenter = new();
        private readonly IGameState gameState;

        public NewGameStateShould()
        {
            gameStateRepository.Setup(gsr => gsr.GameState).Returns(gameState);
            gameStateRepository.Setup(gsr => gsr.GameState.StartState());
            gameState = new NewGameState(gameStateRepository.Object, presenter.Object);
        }

        [Fact]
        public void StartGame()
        {
            // Given
            presenter.Setup(p => p.Print("New game started"));

            // When
            gameState.StartState();

            // Then
            presenter.VerifyAll();
            gameStateRepository.VerifyAll();
        }
    }
}