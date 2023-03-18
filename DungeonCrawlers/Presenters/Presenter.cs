using System.Collections.Generic;
using System.Linq;
using DungeonCrawlers.Entities;
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
            AnsiConsole.WriteLine(message);
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

        public void PrintParty(IEnumerable<ICharacter> characters)
        {
            Table characterPartytable = CreateTable();
            characterPartytable.Title("Character Party");
            characterPartytable.AddColumn("Armour");
            characterPartytable.AddColumn("Expierence");

            foreach (var character in characters)
            {
                Markup name = new($"{character.Name.FirstName} {character.Name.Surname}");
                Markup race = new(character.Race.Name);
                Markup health = new($"[red]♥ {character.Health.CurrentHealth}/{character.Health.MaximumHealth} ♥[/]");
                Markup armour = new($"[yellow]{character.Armour.CurrentArmour}/{character.Armour.MaximumArmour}[/]");
                Markup expierence = new("↑ 0xp");
                Markup[] row = new Markup[] { name, race, health, armour, expierence };

                characterPartytable.AddRow(row);
            }

            AnsiConsole.Write(characterPartytable);
        }

        public void PrintParty(IEnumerable<IMonster> monsters)
        {
            // AnsiConsole.Clear();
            Table monsterPartyTable = CreateTable();
            monsterPartyTable.Title("Monster Party");

            foreach (var monster in monsters)
            {
                Markup name = new($"{monster.Name.FirstName}");
                Markup race = new(monster.Race.Name);
                Markup health = new($"[red]♥ {monster.Health.CurrentHealth}/{monster.Health.MaximumHealth} ♥[/]");
                Markup[] row = new Markup[] { name, race, health };

                monsterPartyTable.AddRow(row);
            }

            AnsiConsole.Write(monsterPartyTable);
        }

        private static Table CreateTable()
        {
            Table table = new();
            table.AddColumn("Name");
            table.AddColumn("Race");
            table.AddColumn("Health");

            return table;
        }
    }
}