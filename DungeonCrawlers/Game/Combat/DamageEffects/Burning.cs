namespace DungeonCrawlers.Game.Combat.DamageEffects
{
    public class Burning : DamageEffect
    {
        public Burning()
        {
            Name = nameof(Burning.GetType);
            Description = "Burning effect";
        }
    }
}