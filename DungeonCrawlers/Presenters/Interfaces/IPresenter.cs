using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;
using Spectre.Console;

namespace DungeonCrawlers.Presenters.Interfaces
{
    public interface IPresenter
    {
        ICharacterPresenter CharacterPresenter { get; }
        void Print(string message);
        void Print(Table table);
        string GetString(string message);
        string SelectString(string message, string[] options);
        Table CreateTable();
        ICharacter SelectCharacter(IEnumerable<ICharacter> characters);
        IMonster SelectMonster(IEnumerable<IMonster> monsters);
    }
}