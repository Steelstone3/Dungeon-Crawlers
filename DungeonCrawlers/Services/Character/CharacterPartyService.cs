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

        public void CreateCharacterParty(ICharacterBuilder characterBuilder)
        {
            _characterPartyController.CreateCharacter(characterBuilder);
            _characterPartyController.CreateCharacterParty(3, characterBuilder);
        }

        public void DisplayCharacterParty()
        {
            _characterPartyController.DisplayCharacterPartyMembers();
        }
    }
}