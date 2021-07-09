using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Characters;

namespace DungeonCrawlers.Contracts
{
    public interface ICharacterController
    {
        IList<ICharacter> PartyMembers { get; }
        ICharacter CreateCharacter(IDisplayer displayer, ICharacterBuilder characterBuilder);
        IList<ICharacter> CreateCharacterParty(ICharacterBuilder characterBuilder, int numberOfPartyMembers);
        void DisplayCharacterParty(IDisplayer displayer);
        void AddPartyMember(ICharacter character);
        void AddPartyMembers(IList<ICharacter> characters);
    }
}