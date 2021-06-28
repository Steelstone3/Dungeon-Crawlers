using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Game;
using DungeonCrawlers.States;

namespace DungeonCrawlers.Game
{
    public class LaunchGame : IGame
    {
        public void StartGame(IGameController gameController, ICharacterPartyController characterPartyController)
        {
            gameController.CurrentGameState = new CharacterCreationState(gameController, characterPartyController);
            gameController.CurrentGameState.StartState();
        }
    }
}