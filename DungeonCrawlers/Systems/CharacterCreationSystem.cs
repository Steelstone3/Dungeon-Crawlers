using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using DungeonCrawlers.Assets;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.Systems;

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
                // TODO AH Command to spawn a random character.

                // Could be done from a predefined list of characters which is shuffled 
                // with the selection being removed from the list each time

                // Could also be done with a list of random names and races similarly
                characterParty.Add(CreateRandomCharacter());
            }

            return characterParty;
        }

        private ICharacter CreateRandomCharacter()
        {
            return null;
        }
    }
}