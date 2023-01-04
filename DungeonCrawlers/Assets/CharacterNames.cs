using System.Linq;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.Assets
{
    public static class CharacterNames
    {
        private static readonly SeededRandomSystem random = new();

        public static string[] Prefixes => OrderedList(prefixes);
        public static string[] FirstNames => OrderedList(firstName);
        public static string[] Surname => OrderedList(surname);
        public static string[] Suffixes => OrderedList(suffixes);

        private readonly static string[] prefixes = new string[]
        {
            "Dr",
            "Mr",
            "Master",
            "Miss",
            "Ms",
            "Mrs",
            "Lady",
            "Lord",
            "Count",
            "Countess",
        };

        private readonly static string[] firstName = new string[]
        {
            "Jeff",
            "Bill",
            "Harry",
            "Lily",
            "Bob",
            "April",
        };

        private readonly static string[] surname = new string[]
        {
            "Jefferson",
            "Billiston",
            "Harken",
            "Wilston",
            "Bobbinton",
            "Snow",
        };

        private readonly static string[] suffixes = new string[]
        {
            "",
            "Jr",
            "Snr",
            "I",
            "II",
            "III",
            "IV",
            "V",
            "The First",
            "The Second",
            "The Third",
            "The Fourth",
            "The Fifth",
            "Voidness",
            "Lightness",
        };

        private static string[] OrderedList(string[] list)
        {
            return list.OrderBy(l => l).ToArray();
        }

        public static string GetRandomPrefix(int seed)
        {
            var randomIndex = random.GetSeededRandom(seed, 0, (ulong)Prefixes.Length);

            return Prefixes[randomIndex];
        }

        public static string GetRandomFirstName(int seed)
        {
            var randomIndex = random.GetSeededRandom(seed, 0, (ulong)FirstNames.Length);

            return FirstNames[randomIndex];
        }

        public static string GetRandomSurname(int seed)
        {
            var randomIndex = random.GetSeededRandom(seed, 0, (ulong)Surname.Length);

            return Surname[randomIndex];
        }

        public static string GetRandomSuffix(int seed)
        {
            var randomIndex = random.GetSeededRandom(seed, 0, (ulong)Suffixes.Length);

            return Suffixes[randomIndex];
        }
    }
}