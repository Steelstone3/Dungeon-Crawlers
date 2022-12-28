namespace DungeonCrawlersTests.Components
{
    internal interface IHealth
    {
        byte CurrentHealth { get; }
        byte MaximumHealth { get; }
        byte RegenerationRate { get; }
    }
}