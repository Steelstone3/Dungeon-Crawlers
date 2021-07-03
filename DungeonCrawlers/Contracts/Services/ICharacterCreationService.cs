using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;

namespace DungeonCrawlers.States
{
    public interface ICharacterCreationService
    {
        void CreateCharacterParty(IDisplayer displayer, ICharacterController characterController, ICharacterBuilder characterBuilder, int numberOfPartyMembers);
    }
}