using System;
using System.Collections.Generic;

namespace DungeonCrawlers.Components.Character
{
    public class CharacterName
    {
        private readonly string prefix;
        private readonly string firstName;
        private readonly string surname;
        private readonly string suffix;

        public CharacterName(string prefix, string firstName, string surname, string suffix)
        {
            this.prefix = prefix;
            this.firstName = firstName;
            this.surname = surname;
            this.suffix = suffix;
        }

        public string GetCharacterName()
        {
            return $"{prefix} {firstName} {surname} {suffix}";
        }
    }
}