using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.States
{
    public class CharacterCreationService : ICharacterCreationService
    {
        public void CreateCharacterParty(ICharacterController characterController, int numberOfPartyMembers)
        {
            characterController.CreateCharacter();
            characterController.CreateCharacterParty(numberOfPartyMembers);
        }
    }
}