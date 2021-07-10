using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Characters;

namespace DungeonCrawlers.Contracts.Controllers
{
    public interface IEnemyController
    {
        IList<IMonster> PartyMembers { get; }
        void GenerateEnemies();
        void DisplayParty(IDisplayer displayer);
        ICharacter SelectOpponent(IList<ICharacter> partyMembers);
        void AttackOpponent(ICharacter character);
    }
}