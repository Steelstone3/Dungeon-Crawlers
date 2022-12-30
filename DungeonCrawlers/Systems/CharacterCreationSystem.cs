using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;

namespace DungeonCrawlersTests.Systems
{
    public class CharacterCreationSystem : ICharacterCreationSystem
    {
        private readonly IGamePresenter gamePresenter;

        public CharacterCreationSystem(IGamePresenter gamePresenter)
        {
            this.gamePresenter = gamePresenter;
        }

        public ICharacter Create()
        {
            return gamePresenter.CreateCharacter();
        }
    }
}