namespace DungeonCrawlers.Components
{
    public class Weapon : IWeapon
    {
        public Weapon(string name, string attackDescription, int maximumDamage, int minimumDamage)
        {
            Name = name;
            AttackDescription = attackDescription;
            MaximumDamage = maximumDamage;
            MinimumDamage = minimumDamage;
        }

        public string Name { get; }
        public string AttackDescription { get; }
        public int MaximumDamage { get; }
        public int MinimumDamage { get; }
    }
}