using System;
using System.Collections;
using System.Linq;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.Assets
{
    public class WeaponNames
    {
        public static string[] Names => names.OrderBy(n => n).ToArray();
        public static string[] Descriptions => descriptions.OrderBy(d => d).ToArray();

        private readonly static string[] names = new string[]
        {
            "Halbeard",
            "Axe",
            "Sword",
            "Longsword",
            "Shortsword",
            "Dagger",
            "Mace"
        };

        private readonly static string[] descriptions = new string[]
        {
            "Hacked",
            "Slashed",
            "Smashed",
            "Bashed",
            "Whacked",
            "Booped"
        };

        public static string GetRandomName(int seed)
        {
            var randomIndex = new SeededRandomSystem().GetSeededRandom(seed, 0, (ulong)Names.Length);

            return Names[randomIndex];
        }

        public static string GetRandomDescription(int seed)
        {
            var randomIndex = new SeededRandomSystem().GetSeededRandom(seed, 0, (ulong)Descriptions.Length);

            return Descriptions[randomIndex];
        }
    }
}