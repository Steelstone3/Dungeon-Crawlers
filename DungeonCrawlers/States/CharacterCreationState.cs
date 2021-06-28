using System;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Game;

namespace DungeonCrawlers.States
{
    public class CharacterCreationState : GameState
    {
        IGameController _gameController;
        ICharacterPartyController _characterPartyController;

        public CharacterCreationState(IGameController gameController, ICharacterPartyController characterPartyController) : base(gameController, characterPartyController)
        {
            _gameController = gameController;
            _characterPartyController = characterPartyController;
        }

        public override void StartState()
        {
            //TODO AH Generic Display
            //TODO AH Character Builder
            Console.WriteLine("Character Creation");

            _characterPartyController.CreateACharacterParty(4);
            _characterPartyController.DisplayCharacterPartyMembers();

            StopState();
        }

        public override void StopState()
        {
            GoToState(new ExplorationState(_gameController, _characterPartyController));
        }
    }
}