using System.Collections.Generic;
using DungeonCrawlers.Contracts.Helper;
using DungeonCrawlers.Controllers.Characters;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Characters
{
    public class CharacterBuilderShould
    {
        [Fact]
        public void GetUserCharacterName()
        {
            var text = "Enter character's name:";

            var genericDisplayHelper = new Mock<IGenericDisplayHelper>();
            genericDisplayHelper.Setup(x => x.ReadUserString(text));

            var characterBuilder = new CharacterBuilder(genericDisplayHelper.Object);

            characterBuilder.BuildCharacter();

            genericDisplayHelper.Verify(x => x.ReadUserString(text));
        }

        [Fact]
        public void GetUserCharacterCombatClass()
        {
            var combatClasses = new List<string>()
            {
                "Knight",
                "Wizard",
            };

            var text = "Select combat class:";

            var genericDisplayHelper = new Mock<IGenericDisplayHelper>();
            genericDisplayHelper.Setup(x => x.DisplayMenu(combatClasses));
            genericDisplayHelper.Setup(x => x.ReadUserNumericInput(text, 0, 1)).Returns(0);

            var characterBuilder = new CharacterBuilder(genericDisplayHelper.Object);

            characterBuilder.BuildCharacter();

            genericDisplayHelper.InSequence(new MockSequence());

            genericDisplayHelper.Verify(x => x.DisplayMenu(combatClasses));
            genericDisplayHelper.Verify(x => x.ReadUserNumericInput(text, 0, 1));
        }

        [Fact]
        public void GetUserCharacterRace()
        {
            var characterRace = new List<string>()
            {
                "Dwarf",
                "Elf",
                "Gnome",
                "HalfElf",
                "HalfGiant",
                "Halfling",
                "HalfOrc",
                "Human",
                "Lizardfolk",
                "Orc",
                "Wolfen",
            };

            var text = "Select character race:";

            var genericDisplayHelper = new Mock<IGenericDisplayHelper>();
            genericDisplayHelper.Setup(x => x.DisplayMenu(characterRace));
            genericDisplayHelper.Setup(x => x.ReadUserNumericInput(text, 0, 9)).Returns(0);

            var characterBuilder = new CharacterBuilder(genericDisplayHelper.Object);

            characterBuilder.BuildCharacter();

            genericDisplayHelper.InSequence(new MockSequence());

            genericDisplayHelper.Verify(x => x.DisplayMenu(characterRace));
            genericDisplayHelper.Verify(x => x.ReadUserNumericInput(text, 0, 9));
        }

        [Theory]
        [InlineData(4, 1, 1, "Sally", "Elf", "Wizard")]
        [InlineData(6, 5, 0, "Chloe", "Halfling", "Knight")]
        [InlineData(100, 100, 100, "Chloe", "Halfling", "Knight")]
        public void BuildARandomCharacter(int nameSeed, int characterRaceSeed, int combatClassSeed, string characterName, string characterRace, string combatClass)
        {
            var genericDisplayHelper = new Mock<IGenericDisplayHelper>();

            var characterBuilder = new CharacterBuilder(genericDisplayHelper.Object);

            var character = characterBuilder.BuildRandomCharacter(nameSeed, characterRaceSeed, combatClassSeed);

            Assert.Equal(characterName, character.Name);
            Assert.Equal(characterRace, character.CharacterRace.Name);
            Assert.Equal(combatClass, character.CombatClass.Name);
        }

        [Fact(Skip = "Write a test to check a character is created and returned")]
        public void BuildACharacter()
        {
        }
        
    
    }
}