using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Characters;

namespace DungeonCrawlers.States
{
    public class CharacterController : ICharacterController
    {
        public IList<ICharacter> PartyMembers { get; private set; } = new List<ICharacter>();

        public ICharacter CreateCharacter(IDisplayer displayer, ICharacterBuilder characterBuilder)
        {
            return characterBuilder.BuildCharacter(displayer);
        }

        public void DisplayParty(IDisplayer displayer)
        {
            foreach (var character in PartyMembers)
            {
                displayer.Write($"Health: {character.CombatRole.Health}, {character.Name} the {character.Race.Name} {character.CombatRole.Name}");
            }
        }

        public void DisplayCharacterAbilities(IDisplayer displayer, ICharacter character)
        {
            displayer.Write($"{character.Name} the {character.Race.Name} {character.CombatRole.Name}");
            
            foreach (var combatAbility in character.CombatRole.CombatAbilities)
            {
                displayer.Write($"{combatAbility.Name}");
            }
        }

        public IList<ICharacter> CreateCharacterParty(ICharacterBuilder characterBuilder, int numberOfPartyMembers)
        {
            return characterBuilder.BuildCharacterParty(numberOfPartyMembers);
        }

        public void AddPartyMember(ICharacter character)
        {
            PartyMembers.Add(character);
        }

        public void AddPartyMembers(IList<ICharacter> characters)
        {
            foreach (var character in characters)
            {
                PartyMembers.Add(character);
            }
        }

        public ICharacter SelectPlayer(IDisplayer displayer)
        {
            DisplayParty(displayer);

            return PartyMembers[displayer.ReadNumeric("Select character:", 0, PartyMembers.Count - 1)];
        }

        public IMonster SelectOpponent(IDisplayer displayer, IList<IMonster> enemyParty)
        {
            foreach (var partyMember in enemyParty)
            {
                displayer.Write($"{partyMember.Name} the {partyMember.Race.Name}");
            }

            return enemyParty[displayer.ReadNumeric("Select opponent:", 0, enemyParty.Count - 1)];
        }

        public void AttackOpponent(IDisplayer displayer, ICharacter character, IMonster monster)
        {
            DisplayCharacterAbilities(displayer, character);
            var combatAbility = character.CombatRole.CombatAbilities[displayer.ReadNumeric("Select combat ability:", 0, character.CombatRole.CombatAbilities.Count - 1)];
            monster.Race.Health -= combatAbility.Damage;
        }
    }
}