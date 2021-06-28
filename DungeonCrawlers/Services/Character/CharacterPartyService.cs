using System;
using DungeonCrawlers.Contracts.Character;

namespace DungeonCrawlers.Services.Character
{
    public class CharacterPartyService
    {
        private ICharacterPartyController _characterPartyController;

        public CharacterPartyService(ICharacterPartyController characterPartyController)
        {
            _characterPartyController = characterPartyController;
        }

        public void CreateCharacterParty()
        {
            _characterPartyController.CreateAMainCharacter();
            _characterPartyController.CreateACharacterParty(3);
        }
    }
}