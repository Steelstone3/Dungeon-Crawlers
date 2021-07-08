using System.Collections.Generic;

namespace DungeonCrawlers.Contracts.Builders
{
    public interface ICharacterBuilder
    {
        ICharacter BuildCharacter(IDisplayer displayer);
        IList<ICharacter> BuildCharacterParty(int numberOfPartyMembers);
    }
}