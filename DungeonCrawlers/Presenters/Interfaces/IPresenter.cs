using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.Presenters.Interfaces
{
    public interface IPresenter
    {
        ICharacterPresenter CharacterPresenter { get; }
        void Print(string message);
        string GetString(string message);
        string SelectString(string message, string[] options);
        ICharacter SelectCharacter(IEnumerable<ICharacter> characters);
        IMonster SelectMonster(IEnumerable<IMonster> monsters);
        void PrintParty(IEnumerable<ICharacter> characters);
        void PrintParty(IEnumerable<IMonster> monsters);
    }
}