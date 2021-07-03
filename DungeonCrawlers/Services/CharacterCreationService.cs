using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;

namespace DungeonCrawlers.States
{
    public class CharacterCreationService : ICharacterCreationService
    {
        public void CreateCharacterParty(IDisplayer displayer, ICharacterController characterController, ICharacterBuilder characterBuilder, int numberOfPartyMembers)
        {
            characterController.CreateCharacter(displayer, characterBuilder);
            characterController.CreateCharacterParty(numberOfPartyMembers);
            characterController.DisplayCharacterParty(displayer);
        }
    }
}