using System.Linq;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.Presenters.Interfaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Presenters
{
    public class CharacterPresenterShould
    {
        private const string HUMAN = "Human";
        private readonly Mock<IPresenter> presenter = new();
        private readonly ICharacterPresenter gamePresenter;

        public CharacterPresenterShould()
        {
            gamePresenter = new CharacterPresenter(presenter.Object);
        }

        [Fact]
        public void CreatePlayerCharacter()
        {
            // Given
            var races = new string[]
            {
                HUMAN,
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
            presenter.Setup(p => p.Print("Character creation"));
            presenter.Setup(p => p.GetString("Enter first name:"));
            presenter.Setup(p => p.GetString("Enter surname:"));
            presenter.Setup(p => p.SelectString("Enter race:", orderedRaces)).Returns(HUMAN);
            presenter.Setup(p => p.GetString("Enter a weapon name:"));
            presenter.Setup(p => p.GetString("Describe the weapon's attack:"));
            presenter.Setup(p => p.Print($"Selected race: {HUMAN}"));

            // When
            ICharacter character = gamePresenter.CreateCharacter();

            // Then
            presenter.VerifyAll();
            Assert.NotNull(character);
            Assert.NotNull(character.Name);
            Assert.NotNull(character.Race);
            Assert.NotNull(character.Health);
            Assert.NotNull(character.Armour);
        }
    }
}