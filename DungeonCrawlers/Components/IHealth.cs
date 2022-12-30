namespace DungeonCrawlers.Components
{
    public interface IHealth
    {
        byte CurrentHealth { get; set; }
        byte MaximumHealth { get; }
        byte RegenerationRate { get; }
    }
}