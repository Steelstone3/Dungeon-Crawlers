namespace DungeonCrawlers.Game.CharacterRaces
{
    public class Human : CharacterRace
    {
       public Human()
       {
           Name = nameof(Human.GetType);
           Description = "A diverse, common and nomadic race";
       }
    }
}