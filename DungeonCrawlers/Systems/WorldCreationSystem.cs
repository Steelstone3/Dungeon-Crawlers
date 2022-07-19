using System;
using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States;

namespace DungeonCrawlersTests.Systems
{
    public class WorldCreationSystem : IWorldCreationSystem
    {
        public IWorld Create(IDisplayer displayer)
        {
            displayer.Write("Creating world...");

            var world = new World();
            world.worldGrid = new char[,]{{'#', '#'}, {'#', '#'}};

            displayer.DrawMap(world.worldGrid);

            return world;
        }
    }
}