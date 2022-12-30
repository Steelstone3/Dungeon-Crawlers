using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using Moq;

namespace DungeonCrawlersTests.Systems
{
    internal class CharacterCreationSystem : ICharacterCreationSystem
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