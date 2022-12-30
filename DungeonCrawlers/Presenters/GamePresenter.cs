using DungeonCrawlers.Assets;
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

            var selectedRace = presenter.SelectString("Enter race:", RaceNames.Races);

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
    }
}