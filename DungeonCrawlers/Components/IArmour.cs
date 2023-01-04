namespace DungeonCrawlers.Components
{
    public interface IArmour
    {
        byte CurrentArmour { get; }
        byte MaximumArmour { get; }
        byte RepairRate { get; }
    }
}