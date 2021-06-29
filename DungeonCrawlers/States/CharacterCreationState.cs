using System;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Game;
using DungeonCrawlers.Controllers.Characters;
using DungeonCrawlers.Helpers;
using DungeonCrawlers.Services.Character;

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
            var display = new GenericDisplayHelper();          
            var characterBuilder = new CharacterBuilder(display);
            var characterPartyService = new CharacterPartyService(_characterPartyController);

            display.DisplayText("Character Creation");

            characterPartyService.CreateCharacterParty(characterBuilder);
            characterPartyService.DisplayCharacterParty();

            StopState();
        }

        public override void StopState()
        {
            GoToState(new ExplorationState(_gameController, _characterPartyController));
        }
    }
}