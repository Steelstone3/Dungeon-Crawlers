using System;
using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.States
{
    public class NewGameState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;

        public NewGameState(IDisplayer displayer, IGameController gameController) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
        }

        public override void StartState()
        {
            _displayer.Write("New game selected");

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("New game started");
            GoToState(new CharacterCreationState(_displayer, 
            _gameController, 
            new CharacterCreationService(), 
            new CharacterBuilder(), 
            new CharacterController()));
        }
    }
}