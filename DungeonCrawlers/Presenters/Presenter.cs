using System.Collections.Generic;
using System.Reflection.Metadata;
using DungeonCrawlers.Entities;
using Spectre.Console;
using Spectre.Console.Rendering;

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

        public void PrintParty(IEnumerable<ICharacter> characters)
        {
            var table = CreateTable();

            foreach (var character in characters)
            {
                var name = new Markup($"{character.Name.FirstName} {character.Name.Surname}");
                var race = new Markup(character.Race.Name);
                var statistics = new Markup($"[red]♥ {character.Health.CurrentHealth}/{character.Health.MaximumHealth} ♥[/] | [yellow]{character.Armour.CurrentArmour}/{character.Armour.MaximumArmour}[/] | ↑ 0xp");
                var row = new Markup[] { name, race, statistics };

                table.AddRow(row);
            }

            AnsiConsole.Write(table);
        }

        public void PrintParty(IEnumerable<IMonster> monsters)
        {
            var table = CreateTable();

            foreach (var monster in monsters)
            {
                var name = new Markup($"{monster.Name.FirstName}");
                var race = new Markup(monster.Race.Name);
                var statistics = new Markup($"[red]♥ {monster.Health.CurrentHealth}/{monster.Health.MaximumHealth} ♥[/]");
                var row = new Markup[] { name, race, statistics };

                table.AddRow(row);
            }

            AnsiConsole.Write(table);
        }

        private static Table CreateTable()
        {
            var table = new Table();
            table.AddColumn("Name");
            table.AddColumn("Race");
            table.AddColumn("Statistics");

            return table;
        }
    }
}