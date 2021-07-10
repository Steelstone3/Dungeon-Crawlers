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
        void DisplayParty(IDisplayer displayer);
        void AddPartyMember(ICharacter character);
        void AddPartyMembers(IList<ICharacter> characters);
        IMonster SelectOpponent(IList<IMonster> enemyParty);
        void AttackOpponent(IMonster @object);
    }
}