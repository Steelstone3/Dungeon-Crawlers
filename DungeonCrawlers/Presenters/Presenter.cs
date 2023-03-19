using System.Collections.Generic;
using System.Data;
using System.Linq;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters.Interfaces;
using Spectre.Console;

namespace DungeonCrawlers.Presenters
{
    public class Presenter : IPresenter
    {
        public Presenter()
        {
            CharacterPresenter = new CharacterPresenter(this);
        }

        public ICharacterPresenter CharacterPresenter
        {
            get;
        }

        public void Print(string message)
        {
            AnsiConsole.MarkupLine(message);
        }

        public void Print(Table table)
        {
            AnsiConsole.Write(table);
        }

        public string GetString(string message)
        {
            return AnsiConsole.Ask<string>(message);
        }

        public string SelectString(string message, string[] options)
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title(message)
                .AddChoices(options));
        }

        public Table CreateTable()
        {
            Table table = new();
            table.AddColumn("Name");
            table.AddColumn("Race");
            table.AddColumn("Health");

            return table;
        }

        public ICharacter SelectCharacter(IEnumerable<ICharacter> characters)
        {
            SelectionPrompt<ICharacter> selectionPrompt = new() { Converter = c => $"{c.Name.FirstName} {c.Name.Surname}" };

            return AnsiConsole.Prompt(selectionPrompt
            .Title("Select character:")
            .AddChoices(characters.Where(c => c.Health.CurrentHealth > 0)));
        }

        public IMonster SelectMonster(IEnumerable<IMonster> monsters)
        {
            SelectionPrompt<IMonster> selectionPrompt = new() { Converter = m => $"{m.Name.FirstName} {m.Name.Surname}" };

            return AnsiConsole.Prompt(selectionPrompt
            .Title("Select monster:")
            .AddChoices(monsters.Where(m => m.Health.CurrentHealth > 0)));
        }
    }
}