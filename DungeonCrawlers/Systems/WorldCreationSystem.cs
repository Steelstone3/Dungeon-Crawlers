using System;
using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States;

namespace DungeonCrawlersTests.Systems
{
    public class WorldCreationSystem : IWorldCreationSystem
    {
        public IWorld Create()
        {
            var world = new World
            {
                worldGrid = new char[5, 5] { { '#', '#', '#', '#', '#' }, { '#', '.', '.', '.', '#' }, { '#', '.', '.', '.', '#' }, { '#', '.', '.', '.', '#' }, { '#', '#', '#', '#', '#' } }
            };

            return world;
        }
    }
}