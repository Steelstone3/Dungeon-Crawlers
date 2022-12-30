using System.Collections.Generic;
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

        public IEnumerable<ICharacter> CreateMultiple(byte quantity)
        {
            var characterParty = new List<ICharacter>();

            for (int i = 0; i < quantity; i++)
            {
                characterParty.Add(gamePresenter.CreateCharacter());
            }

            return characterParty;
        }
    }
}