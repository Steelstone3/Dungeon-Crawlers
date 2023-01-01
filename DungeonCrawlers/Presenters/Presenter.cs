using System.Collections.Generic;
using DungeonCrawlers.Entities;
using Spectre.Console;

namespace DungeonCrawlers.Presenters
{
    public class Presenter : IPresenter
    {
        public void Print(string message)
        {
            AnsiConsole.WriteLine(message);
        }

        public byte GetByte(string message, byte lowerBound, byte upperBound)
        {
            return AnsiConsole
                .Prompt(new TextPrompt<byte>(message)
                .ValidationErrorMessage($"[red]Value entered out of range: {lowerBound} - {upperBound}[/]")
                .Validate(value =>
                {
                    return value >= lowerBound && value <= upperBound
                        ? ValidationResult.Success()
                        : ValidationResult.Error($"[red]Enter a value in the range: {lowerBound} - {upperBound}[/]");
                }));
        }

        public byte GetByte(string message)
        {
            return AnsiConsole
                .Prompt(new TextPrompt<byte>(message)
                .ValidationErrorMessage($"[red]Enter a value in the range: {byte.MinValue} - {byte.MaxValue}[/]"));
        }

        public string GetString(string message)
        {
            return AnsiConsole.Ask<string>(message);
        }

        public bool GetConfirmation(string message)
        {
            return AnsiConsole.Confirm(message);
        }

        public string SelectString(string message, string[] options)
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title(message)
                .AddChoices(options));
        }

        public ICharacter SelectCharacter(IEnumerable<ICharacter> characters)
        {
            var selectionPrompt = new SelectionPrompt<ICharacter> { Converter = c => $"{c.Name.FirstName} {c.Name.Surname}" };

            return AnsiConsole.Prompt(selectionPrompt
            .Title("Select character:")
            .AddChoices(characters));
        }

        public IMonster SelectMonster(IEnumerable<IMonster> monsters)
        {
            var selectionPrompt = new SelectionPrompt<IMonster> { Converter = m => $"{m.Name.FirstName} {m.Name.Surname}" };

            return AnsiConsole.Prompt(selectionPrompt
            .Title("Select monster:")
            .AddChoices(monsters));
        }

        public void PrintParty(IEnumerable<ICharacter> characters)
        {
            var characterPartytable = CreateTable();
            characterPartytable.Title("Character Party");
            characterPartytable.AddColumn("Armour");
            characterPartytable.AddColumn("Expierence");

            foreach (var character in characters)
            {
                var name = new Markup($"{character.Name.FirstName} {character.Name.Surname}");
                var race = new Markup(character.Race.Name);
                var health = new Markup($"[red]♥ {character.Health.CurrentHealth}/{character.Health.MaximumHealth} ♥[/]");
                var armour = new Markup($"[yellow]{character.Armour.CurrentArmour}/{character.Armour.MaximumArmour}[/]");
                var expierence = new Markup($"↑ 0xp");
                var row = new Markup[] { name, race, health, armour, expierence };

                characterPartytable.AddRow(row);
            }

            AnsiConsole.Write(characterPartytable);
        }

        public void PrintParty(IEnumerable<IMonster> monsters)
        {
            var monsterPartyTable = CreateTable();
            monsterPartyTable.Title("Monster Party");

            foreach (var monster in monsters)
            {
                var name = new Markup($"{monster.Name.FirstName}");
                var race = new Markup(monster.Race.Name);
                var health = new Markup($"[red]♥ {monster.Health.CurrentHealth}/{monster.Health.MaximumHealth} ♥[/]");
                var row = new Markup[] { name, race, health };

                monsterPartyTable.AddRow(row);
            }

            AnsiConsole.Write(monsterPartyTable);
        }

        private static Table CreateTable()
        {
            var table = new Table();
            table.AddColumn("Name");
            table.AddColumn("Race");
            table.AddColumn("Health");

            return table;
        }
    }
}