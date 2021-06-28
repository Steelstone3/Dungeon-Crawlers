namespace DungeonCrawlers.Game.Combat.DamageEffects
{
    public class Bleeding : DamageEffect
    {
        public Bleeding()
        {
            Name = nameof(Bleeding.GetType);
            Description = "Bleeding effect";
        }
    }
}