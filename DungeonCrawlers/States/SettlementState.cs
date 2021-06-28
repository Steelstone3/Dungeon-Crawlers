using System;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Game;

namespace DungeonCrawlers.States
{
    public class SettlementState : GameState
    {
        IGameController _gameController;
        ICharacterPartyController _characterPartyController;

        public SettlementState(IGameController gameController, ICharacterPartyController characterPartyController) : base(gameController, characterPartyController)
        {
            _gameController = gameController;
            _characterPartyController = characterPartyController;
        }

        public override void StartState()
        {
            StopState();
        }

        public override void StopState()
        {
            //GoToState(new ExplorationState());
        }
    }
}