using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Game.Characters;

namespace DungeonCrawlers.Controllers.Characters
{
    public class CharacterPartyController : ICharacterPartyController
    {
        private const int _maxNumberOfCharacterPartyMembers = 4;
        private const int _minNumberOfCharacterPartyMembers = 1;

        public IEnumerable<ICharacter> CharacterParty { get; private set; }

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

        private int SetCharacterPartyLimit(int numberOfCharacters)
        {
            if(numberOfCharacters > _maxNumberOfCharacterPartyMembers)
            {
                return _maxNumberOfCharacterPartyMembers;
            }
            else if(numberOfCharacters < 0)
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