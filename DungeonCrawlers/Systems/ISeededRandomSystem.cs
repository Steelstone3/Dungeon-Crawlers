namespace DungeonCrawlers.Systems
{
    public interface ISeededRandomSystem
    {
        ulong GetSeededRandom(int seed, ulong lowerBound, ulong upperBound);
    }
}