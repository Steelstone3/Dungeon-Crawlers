using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.States
{
    public interface ICharacterCreationService
    {
        void CreateCharacterParty(ICharacterController characterController, int numberOfPartyMembers);
    }
}