using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Character;

namespace DungeonCrawlers.Controllers.Characters
{
    public class CharacterPartyController : ICharacterPartyController
    {
        private const int _maxNumberOfCharacterPartyMembers = 4;
        private const int _minNumberOfCharacterPartyMembers = 1;

        public IList<ICharacter> CharacterParty { get; private set; } = new List<ICharacter>();

        public void CreateCharacter(ICharacterBuilder characterBuilder)
        {
            CharacterParty.Add(characterBuilder.BuildCharacter());
        }

        public void CreateCharacterParty(int numberOfCharacters, ICharacterBuilder characterBuilder)
        {
            var random = new Random();
            var limitedNumberOfCharacters = SetCharacterPartyLimit(numberOfCharacters);

            for (int i = 0; i < limitedNumberOfCharacters; i++)
            {
                CharacterParty.Add(characterBuilder.BuildRandomCharacter(random.Next(0,8), random.Next(0,9), random.Next(0,1)));
            }
        }

        public void DisplayCharacterPartyMembers()
        {
            foreach (var character in CharacterParty)
            {
                Console.WriteLine($"{character.Name}, {character.CharacterRace.Name}, {character.CombatClass.Name}");
            }
        }

        public void DisplayCharacterPartyMemberAbilities(ICharacter partyMember)
        {
            Console.WriteLine($"{partyMember.Name}, {partyMember.CharacterRace.Name}, {partyMember.CombatClass.Name}");
            
            foreach (var combatAbility in partyMember.CombatClass.CombatAbilities)
            {
                Console.WriteLine($"{combatAbility.Name}, {combatAbility.Damage}, {combatAbility.DamageType}");
            }
        }

        private int SetCharacterPartyLimit(int numberOfCharacters)
        {
            if (numberOfCharacters > _maxNumberOfCharacterPartyMembers)
            {
                return _maxNumberOfCharacterPartyMembers;
            }
            else if (numberOfCharacters < 0)
            {
                return _minNumberOfCharacterPartyMembers;
            }
            else
            {
                return numberOfCharacters;
            }
        }
    }
}