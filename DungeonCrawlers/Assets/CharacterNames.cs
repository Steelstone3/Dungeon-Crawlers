using System.Linq;

namespace DungeonCrawlers.Assets
{
    public static class CharacterNames
    {
        public static string[] Prefixes => OrderedList(prefixes);
        public static string[] FirstNames => OrderedList(firstName);
        public static string[] Surname => OrderedList(surname);
        public static string[] Suffixes => OrderedList(prefixes);

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
    }
}