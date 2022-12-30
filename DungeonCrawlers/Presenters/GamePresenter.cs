using System.Linq;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Presenters
{
    public class GamePresenter : IGamePresenter
    {
        private readonly IPresenter presenter;

        public GamePresenter(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        public ICharacter CreateCharacter()
        {
            presenter.Print("Character creation");

            var selectedRace = SelectRace();

            presenter.Print($"Selected race: {selectedRace}");

            return new Character(
                new Name(
                    presenter.GetString("Enter prefix:"),
                    presenter.GetString("Enter first name:"),
                    presenter.GetString("Enter surname:"),
                    presenter.GetString("Enter suffix:")
                ),
                new Race(selectedRace),
                new Health(100, 100, 25), new Armour(100, 100, 5)
            );
        }

        private string SelectRace()
        {
            var races = new string[]
            {
                "Human",
                "Elf",
                "Dwarf",
                "Halfling",
                "Giant",
                "Half-Orc",
                "Half-Elf",
                "Gnome",
                "Bunny-Folk",
                "Tortile",
                "Mer-Folk",
                "Linux-User"
            };
            var orderedRaces = races.OrderBy(r => r).ToArray();

            return presenter.SelectString("Enter race:", orderedRaces);
        }
    }
}