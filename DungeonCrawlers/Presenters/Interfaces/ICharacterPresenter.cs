using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.Presenters.Interfaces
{
    public interface ICharacterPresenter
    {
        ICharacter CreateCharacter();
        void PrintParty(IEnumerable<ICharacter> characters);
        void PrintParty(IEnumerable<IMonster> monsters);
    }
}