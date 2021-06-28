using DungeonCrawlers.Game.Encounters;
using Xunit;

namespace DungeonCrawlersTests.Dungeons
{
    public class CombatEncountersShould
    {
        //TODO AH generate based on biome
        [Fact]
        public void GenerateACombatEncounterBasedOnBiome()
        {
            var combatEncounter = new CombatEncounter();

            Assert.NotNull(combatEncounter.Monsters);
            Assert.NotEmpty(combatEncounter.Monsters);
        }
    }
}