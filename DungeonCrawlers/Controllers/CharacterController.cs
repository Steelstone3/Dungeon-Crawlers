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
                displayer.Write($"{character.Name} the {character.Race.Name} {character.CombatRole.Name}");
            }
        }

         public void DisplayCharacterAbilities(IDisplayer displayer, ICharacter character)
        {
                displayer.Write($"{character.Name} the {character.Race.Name} {character.CombatRole.Name}");
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

        public IMonster AttackOpponent(IDisplayer displayer, ICharacter character, IMonster monster)
        {
            //Select a combat ability then apply the damage to the enemy
            //This will need to be assigned to the correct index
            //Combat abilities need to be implemented
            
            //displayer.ReadNumeric("Select combat ability:", 0, character.CombatAbilities.Count - 1);
            return null;
        }
    }
}