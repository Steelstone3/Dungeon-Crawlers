namespace DungeonCrawlers.Components
{
    public interface IWeapon
    {
        string Name { get; }
        string AttackDescription { get; }
        int MaximumDamage { get; }
        int MinimumDamage { get; }
    }
}