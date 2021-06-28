using DungeonCrawlers.Components.Interfaces;

namespace DungeonCrawlers.Components
{
    public class Armour : IArmour
    {
        public Armour(byte currentArmour, byte maximumArmour, byte repairRate)
        {
            CurrentArmour = currentArmour;
            MaximumArmour = maximumArmour;
            RepairRate = repairRate;
        }

        public byte CurrentArmour { get; }
        public byte MaximumArmour { get; }
        public byte RepairRate { get; }
    }
}