using System;
using System.Collections.Generic;

namespace DungeonCrawlers.Contracts.Character
{
    public interface ICharacterPartyController
    {
        IList<ICharacter> CharacterParty{get;}
        void CreateCharacterParty(int numberOfCharacters, ICharacterBuilder characterBuilder);
        void DisplayCharacterPartyMembers();
        void DisplayCharacterPartyMemberAbilities(ICharacter partyMember);
        void CreateCharacter(ICharacterBuilder characterBuilder);
    }
}