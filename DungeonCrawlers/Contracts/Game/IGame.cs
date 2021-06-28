using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Game;

namespace DungeonCrawlers.Game
{
    public interface IGame
    {
        void StartGame(IGameController gameController, ICharacterPartyController characterPartyController);
    }
}