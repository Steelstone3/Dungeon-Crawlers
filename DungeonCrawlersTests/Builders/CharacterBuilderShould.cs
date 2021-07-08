using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Game.Characters.Races;
using DungeonCrawlers.Game.Combat.CombatRoles;
using DungeonCrawlers.Builders;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Builders
{
    public class CharacterBuilderShould
    {
        //TODO AH Check what on earth is going on with the write menu mock
        [Fact]
        public void BuildCharacter()
        {
            var displayer = SetupDisplayerMock();

            var characterBuilder = new CharacterBuilder();

            var character = characterBuilder.BuildCharacter(displayer.Object);

            displayer.InSequence(new MockSequence());
            displayer.Verify(x => x.ReadString("Enter character's name:"));
            //displayer.Verify(x => x.WriteMenu(CreateRaceList()));
            displayer.Verify(x => x.ReadNumeric("Enter character's race:", 0, 2));
            //displayer.Verify(x => x.WriteMenu(CreateCombatClassList()));
            displayer.Verify(x => x.ReadNumeric("Enter character's combat role:", 0, 3));

            Assert.NotNull(character);
            Assert.Equal("Alex", character.Name);
            Assert.NotNull(character.Description);
            Assert.NotNull(character.Race);
            Assert.NotNull(character.CombatRole);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(4, 4)]
        [InlineData(5, 4)]
        [InlineData(-1, 1)]
        [InlineData(10, 4)]
        public void BuildCharacterParty(int partySize, int expectedSize)
        {
            var characterBuilder = new CharacterBuilder();

            var characterParty = characterBuilder.BuildCharacterParty(partySize);

            Assert.NotEmpty(characterParty);
            Assert.NotNull(characterParty);
            Assert.Equal(expectedSize, characterParty.Count);
        }

        private Mock<IDisplayer> SetupDisplayerMock()
        {
            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.ReadString("Enter character's name:")).Returns("Alex");
            displayer.Setup(x => x.WriteMenu(CreateRaceList()));
            displayer.Setup(x => x.ReadNumeric("Enter character's race:", 0, 2)).Returns(0);
            displayer.Setup(x => x.WriteMenu(CreateCombatClassList()));
            displayer.Setup(x => x.ReadNumeric("Enter character's combat role:", 0, 3)).Returns(0);

            return displayer;
        }

        private IList<string> CreateRaceList()
        {
            return new List<string>()
            {
                nameof(Dwarf),
                nameof(Elf),
                nameof(Human),
            };
        }

        private IList<string> CreateCombatClassList()
        {
            return new List<string>()
            {
                nameof(Bard),
                nameof(Knight),
                nameof(Rogue),
                nameof(Wizard),
            };
        }
    }
}