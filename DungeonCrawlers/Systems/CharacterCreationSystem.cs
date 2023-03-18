using System.Collections.Generic;
using DungeonCrawlers.Assets;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.Systems.Interfaces;

namespace DungeonCrawlers.Systems
{
    public class CharacterCreationSystem : ICharacterCreationSystem
    {
        private readonly ICharacterPresenter gamePresenter;

        public CharacterCreationSystem(ICharacterPresenter gamePresenter)
        {
            this.gamePresenter = gamePresenter;
        }

        public ICharacter Create()
        {
            return gamePresenter.CreateCharacter();
        }

        public IEnumerable<ICharacter> CreateMultiple(byte quantity, int[] seeds)
        {
            var characterParty = new List<ICharacter>();

            for (int i = 0; i < quantity; i++)
            {
                characterParty.Add(CreateRandomCharacter(seeds[i]));
            }

            return characterParty;
        }

        private static ICharacter CreateRandomCharacter(int seed)
        {
            return new Character
            (
                new Name
                (
                    CharacterNames.GetRandomFirstName(seed),
                    CharacterNames.GetRandomSurname(seed)
                ),
                new Race
                (
                    RaceNames.GetRandomRace(seed)
                ),
                new Health(100, 100, 25),
                new Armour(100, 100, 5),
                new Weapon(WeaponNames.GetRandomName(seed), WeaponNames.GetRandomDescription(seed), 5, 1)
            );
        }
    }
}