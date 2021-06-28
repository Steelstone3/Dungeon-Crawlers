using System.Collections.Generic;

namespace DungeonCrawlers.Contracts.Character
{
    public interface ICharacterPartyController
    {
        IEnumerable<ICharacter> CharacterParty{get;}
        void CreateACharacterParty(int numberOfCharacters);
        void DisplayCharacterPartyMembers();
    }
}