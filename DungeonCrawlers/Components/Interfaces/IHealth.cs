namespace DungeonCrawlers.Components.Interfaces
{
    public interface IHealth
    {
        byte CurrentHealth { get; set; }
        byte MaximumHealth { get; }
        byte RegenerationRate { get; }
    }
}