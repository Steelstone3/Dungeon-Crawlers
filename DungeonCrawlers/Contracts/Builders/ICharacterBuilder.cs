using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Characters;

namespace DungeonCrawlers.Contracts.Builders
{
    public interface ICharacterBuilder
    {
        ICharacter BuildCharacter(IDisplayer displayer);
        IList<ICharacter> BuildCharacterParty(int numberOfPartyMembers);
    }
}