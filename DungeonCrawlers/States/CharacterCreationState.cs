using System.Collections.Generic;
using System.Linq;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.States.Interfaces;
using DungeonCrawlers.Systems;
using DungeonCrawlers.Systems.Interfaces;

namespace DungeonCrawlers.States
{
    public class CharacterCreationState : GameState
    {
        private const int CHARACTER_QUANTITY = 3;
        private readonly IGameStateRepository gameStateRepository;
        private readonly IPresenter presenter;
        private readonly IGameRepository gameRepository;
        private readonly ICharacterCreationSystem characterCreation;
        private readonly ISeededRandomSystem seededRandomSystem;

        public CharacterCreationState(IGameStateRepository gameStateRepository, IPresenter presenter, IGameRepository gameRepository, ICharacterCreationSystem characterCreation, ISeededRandomSystem seededRandomSystem) : base(gameStateRepository)
        {
            this.gameStateRepository = gameStateRepository;
            this.presenter = presenter;
            this.gameRepository = gameRepository;
            this.characterCreation = characterCreation;
            this.seededRandomSystem = seededRandomSystem;
        }

        public override void StartState()
        {
            gameRepository.CharacterParty.AddRange(characterCreation.CreateMultiple(CHARACTER_QUANTITY, seededRandomSystem.CreateSeeds(CHARACTER_QUANTITY)));
            gameRepository.CharacterParty.Add(characterCreation.Create());

            presenter.CharacterPresenter.PrintParty(gameRepository.CharacterParty);

            GoToState(new DungeonState(gameStateRepository, presenter, gameRepository, new DungeonCreationSystem(new RoomCreationSystem(seededRandomSystem, new MonsterCreationSystem())), new CombatSystem(presenter, seededRandomSystem)));
        }
    }
}