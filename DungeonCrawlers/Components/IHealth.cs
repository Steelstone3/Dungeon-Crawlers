namespace DungeonCrawlers.Components
{
    public interface IHealth
    {
        byte CurrentHealth { get; }
        byte MaximumHealth { get; }
        byte RegenerationRate { get; }
    }
}