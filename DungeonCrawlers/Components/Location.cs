using DungeonCrawlers.Components;

namespace DungeonCrawlers.Entities
{
    public class Location : ILocation
    {
        public Location(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }
        
        public int X { get; set; }
        public int Y { get; set; }
    }
}