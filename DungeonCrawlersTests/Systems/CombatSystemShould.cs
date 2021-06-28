using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.Systems;
using DungeonCrawlers.Systems.Interfaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class CombatSystemShould
    {
        private readonly Mock<ISeededRandomSystem> random = new();
        private readonly Mock<IPresenter> presenter = new();
        private readonly Mock<ICharacterPresenter> characterPresenter = new();
        private readonly ICombatSystem combatSystem;

        public CombatSystemShould()
        {
            combatSystem = new CombatSystem(presenter.Object, random.Object);
        }

        [Theory]
        [InlineData(25, 100, 75, true)]
        [InlineData(50, 100, 50, true)]
        [InlineData(75, 100, 25, true)]
        [InlineData(100, 100, 0, false)]
        [InlineData(101, 100, 0, false)]
        public void ExecutePlayerTurn(byte maximumDamage, byte currentHealth, byte remainingHealth, bool combatResult)
        {
            // Given
            IMonster monster = new Monster(new Name("Bob", "Harris"), null, new Health(currentHealth, 100, 0), null);
            ICharacter character = new Character(new Name("Lily", "Jones"), null, new Health(100, 100, 25), new Armour(100, 100, 5), new Weapon("Nibbles", "Boop", maximumDamage, maximumDamage));
            ICharacter[] characters = new ICharacter[] { character };
            IMonster[] monsters = new IMonster[] { monster };
            characterPresenter.Setup(p => p.PrintParty(characters));
            characterPresenter.Setup(p => p.PrintParty(monsters));
            presenter.Setup(p => p.SelectCharacter(characters)).Returns(character);
            presenter.Setup(p => p.SelectMonster(monsters)).Returns(monster);
            presenter.Setup(p => p.Print($"{character.Name.FirstName} {character.Name.Surname} used {character.Weapon.Name} and {character.Weapon.AttackDescription} {monster.Name.FirstName} {monster.Name.Surname} for {maximumDamage} damage"));
            presenter.Setup(p => p.CharacterPresenter).Returns(characterPresenter.Object);

            // When
            var isInCombat = combatSystem.PlayerTurn(characters, monsters);

            // Then
            presenter.VerifyAll();
            Assert.Equal(remainingHealth, monsters[0].Health.CurrentHealth);
            Assert.Equal(100, monsters[0].Health.MaximumHealth);
            Assert.Equal(0, monsters[0].Health.RegenerationRate);
            Assert.Equal(combatResult, isInCombat);
        }

        [Theory]
        [InlineData(25, 100, 75, true)]
        [InlineData(50, 100, 50, true)]
        [InlineData(75, 100, 25, true)]
        [InlineData(100, 100, 0, false)]
        [InlineData(101, 100, 0, false)]
        public void ExecuteMonsterTurn(byte maximumDamage, byte currentHealth, byte remainingHealth, bool combatResult)
        {
            // Given
            IMonster monster = new Monster(new Name("Lily", "Jones"), null, new Health(100, 100, 0), new Weapon("Nibbles", "Boop", maximumDamage, maximumDamage));
            ICharacter character = new Character(new Name("Bob", "Harris"), null, new Health(currentHealth, 100, 25), null, null);
            IMonster[] monsters = new IMonster[] { monster };
            ICharacter[] characters = new ICharacter[] { character };
            characterPresenter.Setup(p => p.PrintParty(characters));
            characterPresenter.Setup(p => p.PrintParty(monsters));
            random.Setup(p => p.SelectRandom(characters)).Returns(character);
            random.Setup(p => p.SelectRandom(monsters)).Returns(monster);
            presenter.Setup(p => p.Print($"{monster.Name.FirstName} {monster.Name.Surname} used {monster.Weapon.Name} and {monster.Weapon.AttackDescription} {character.Name.FirstName} {character.Name.Surname} for {maximumDamage} damage"));
            presenter.Setup(p => p.CharacterPresenter).Returns(characterPresenter.Object);

            // When
            var isInCombat = combatSystem.MonsterTurn(monsters, characters);

            // Then
            random.VerifyAll();
            presenter.VerifyAll();
            Assert.Equal(remainingHealth, characters[0].Health.CurrentHealth);
            Assert.Equal(100, characters[0].Health.MaximumHealth);
            Assert.Equal(25, characters[0].Health.RegenerationRate);
            Assert.Equal(combatResult, isInCombat);
        }
    }
}