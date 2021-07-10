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

        public IMonster SelectOpponent(IList<IMonster> enemyParty)
        {
            throw new System.NotImplementedException();
        }

        public void AttackOpponent(IMonster @object)
        {
            throw new System.NotImplementedException();
        }
    }
}