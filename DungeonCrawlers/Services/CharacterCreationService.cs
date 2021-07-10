using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;

namespace DungeonCrawlers.States
{
    public class CharacterCreationService : ICharacterCreationService
    {
        public void CreateCharacterParty(IDisplayer displayer, ICharacterController characterController, ICharacterBuilder characterBuilder, int numberOfPartyMembers)
        {
            //TODO AH May need to return the character controller

            var character = characterController.CreateCharacter(displayer, characterBuilder);
            var characters = characterController.CreateCharacterParty(characterBuilder, numberOfPartyMembers);
            characterController.AddPartyMember(character);
            characterController.AddPartyMembers(characters);
            characterController.DisplayParty(displayer);
        }
    }
}