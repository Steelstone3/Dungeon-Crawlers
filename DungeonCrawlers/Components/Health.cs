using DungeonCrawlers.Components.Interfaces;

namespace DungeonCrawlers.Components
{
    public class Health : IHealth
    {
        public Health(byte currentHealth, byte maximumHealth, byte regenerationRate)
        {
            CurrentHealth = currentHealth;
            MaximumHealth = maximumHealth;
            RegenerationRate = regenerationRate;
        }

        public byte CurrentHealth { get; set; }
        public byte MaximumHealth { get; }
        public byte RegenerationRate { get; }
    }
}