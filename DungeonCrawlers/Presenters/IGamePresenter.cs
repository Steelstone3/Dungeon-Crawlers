using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Presenters
{
    public interface IGamePresenter
    {
        ICharacter CreateCharacter();
        void PrintParty(IEnumerable<ICharacter> characters);
        void PrintParty(IEnumerable<IMonster> monsters);
    }
}