namespace DungeonCrawlersTests.Components
{
    internal class Health : IHealth
    {
        public Health(byte currentHealth, byte maximumHealth, byte regenerationRate)
        {
            CurrentHealth = currentHealth;
            MaximumHealth = maximumHealth;
            RegenerationRate = regenerationRate;
        }

        public byte CurrentHealth { get; }
        public byte MaximumHealth { get; }
        public byte RegenerationRate { get; }
    }
}