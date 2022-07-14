using System;
using DungeonCrawlers.Components.Character;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public static class CharacterCreation
    {
        public static Character Create(CharacterMetaData characterMetaData)
        {
            return new Character(characterMetaData);
        }
    }
}