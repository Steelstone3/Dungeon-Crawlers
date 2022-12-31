using System.Collections.Generic;
using System.Linq;
using DungeonCrawlers.Assets;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;

namespace DungeonCrawlersTests.Systems
{
    public class CharacterCreationSystem : ICharacterCreationSystem
    {
        private readonly IGamePresenter gamePresenter;

        public CharacterCreationSystem(IGamePresenter gamePresenter)
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
                    CharacterNames.GetRandomPrefix(seed),
                    CharacterNames.GetRandomFirstName(seed),
                    CharacterNames.GetRandomSurname(seed),
                    CharacterNames.GetRandomSuffix(seed)
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