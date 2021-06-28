using System.Linq;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.Assets
{
    public static class MonsterNames
    {
        public static string[] FirstNames => firstNames.OrderBy(fn => fn).ToArray();
        public static string[] Surnames => surnames.OrderBy(sn => sn).ToArray();
        public static string[] Races => races.OrderBy(r => r).ToArray();

        private readonly static string[] firstNames = new string[]
        {
            "Gendrid",
            "Fodark",
            "Vashnir",
        };

        private readonly static string[] surnames = new string[]
        {
            "Genshin",
            "Gofer",
            "Yunper",
        };

        private readonly static string[] races = new string[]
        {
            "Green-Dragon",
            "Black-Dragon",
            "Red-Dragon",
            "Blue-Dragon",
            "Orange-Dragon",
            "Violet-Dragon",
            "Orange-Dragon",
            "Wvern",
            "Zombie",
            "Mummy",
            "Wraith",
            "Henchman",
            "Bandit",
            "Goblin",
            "Orc",
            "Killer-Bunny",
        };

        public static string GetRandomFirstName(int seed)
        {
            var randomIndex = new SeededRandomSystem().GetSeededRandom(seed, 0, (ulong)FirstNames.Length);

            return FirstNames[randomIndex];
        }

        public static string GetRandomSurname(int seed)
        {
            var randomIndex = new SeededRandomSystem().GetSeededRandom(seed, 0, (ulong)Surnames.Length);

            return Surnames[randomIndex];
        }

        public static string GetRandomRace(int seed)
        {
            var randomIndex = new SeededRandomSystem().GetSeededRandom(seed, 0, (ulong)Races.Length);

            return Races[randomIndex];
        }
    }
}