using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;

namespace DungeonCrawlers.Contracts
{
    public interface ICharacterController
    {
        ICharacter CreateCharacter(IDisplayer displayer, ICharacterBuilder characterBuilder);
        IList<ICharacter> CreateCharacterParty(int numberOfPartyMembers);
        void DisplayCharacterParty(IDisplayer displayer);
    }
}