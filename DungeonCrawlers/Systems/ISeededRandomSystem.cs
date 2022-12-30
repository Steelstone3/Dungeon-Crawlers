namespace DungeonCrawlers.Systems
{
    public interface ISeededRandomSystem
    {
        int[] CreateSeeds(int quantity);
        ulong GetSeededRandom(int seed, ulong lowerBound, ulong upperBound);
    }
}