using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Game.CharacterRaces;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.CombatClasses;

namespace DungeonCrawlers.Controllers.Characters
{
    public class CharacterPartyController : ICharacterPartyController
    {
        private const int _maxNumberOfCharacterPartyMembers = 4;
        private const int _minNumberOfCharacterPartyMembers = 1;

        public IEnumerable<ICharacter> CharacterParty { get; private set; }

        public void CreateAMainCharacter()
        {
            
            /*new CharacterBuilder();
            new Character("bob", new Human(), new Knight());*/
        }

        public void CreateACharacterParty(int numberOfCharacters)
        {
            var characterParty = new List<ICharacter>();

            var limitedNumberOfCharacters = SetCharacterPartyLimit(numberOfCharacters);

            for (int i = 0; i < limitedNumberOfCharacters; i++)
            {
                characterParty.Add(new Character());
            }

            CharacterParty = characterParty;
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