namespace DungeonCrawlers.Components.Interfaces
{
    public interface IArmour
    {
        byte CurrentArmour { get; }
        byte MaximumArmour { get; }
        byte RepairRate { get; }
    }
}