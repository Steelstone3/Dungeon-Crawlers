using System.Linq;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.Assets
{
    public static class RaceNames
    {
        public static string[] Races => races.OrderBy(r => r).ToArray();

        private readonly static string[] races = new string[]
        {
            "Human",
            "Elf",
            "Dwarf",
            "Halfling",
            "Giant",
            "Half-Orc",
            "Half-Elf",
            "Gnome",
            "Bunny-Folk",
            "Tortile",
            "Mer-Folk",
            "Linux-User"
        };

        public static string GetRandomRace(int seed)
        {
            var randomIndex = new SeededRandomSystem().GetSeededRandom(seed, 0, (ulong)Races.Length);

            return Races[randomIndex];
        }
    }
}