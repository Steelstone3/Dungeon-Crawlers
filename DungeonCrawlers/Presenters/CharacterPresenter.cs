using DungeonCrawlers.Assets;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters.Interfaces;

namespace DungeonCrawlers.Presenters
{
    public class CharacterPresenter : ICharacterPresenter
    {
        private readonly IPresenter presenter;

        public CharacterPresenter(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        public ICharacter CreateCharacter()
        {
            presenter.Print("Character creation");

            var selectedRace = presenter.SelectString("Enter race:", RaceNames.Races);

            presenter.Print($"Selected race: {selectedRace}");

            return new Character(
                new Name(
                    presenter.GetString("Enter first name:"),
                    presenter.GetString("Enter surname:")
                ),
                new Race(selectedRace),
                new Health(100, 100, 25), new Armour(100, 100, 5),
                new Weapon(presenter.GetString("Enter a weapon name:"), presenter.GetString("Describe the weapon's attack:"), 5, 1)
            );
        }
    }
}