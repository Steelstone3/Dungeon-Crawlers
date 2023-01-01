using System.Collections.Generic;
using System.Linq;
using DungeonCrawlers.Presenters;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers.States
{
    public class CharacterCreationState : GameState
    {
        private readonly IPresenter presenter;
        private readonly IGameRepository gameRepository;
        private readonly ICharacterCreationSystem characterCreation;
        private readonly IEnumerable<int> seeds;

        public CharacterCreationState(IGameStateRepository gameStateRepository, IPresenter presenter, IGameRepository gameRepository, ICharacterCreationSystem characterCreation, IEnumerable<int> seeds) : base(gameStateRepository)
        {
            this.presenter = presenter;
            this.gameRepository = gameRepository;
            this.characterCreation = characterCreation;
            this.seeds = seeds;
        }

        public override void StartState()
        {
            gameRepository.CharacterParty.AddRange(characterCreation.CreateMultiple(3, seeds.ToArray()));
            gameRepository.CharacterParty.Add(characterCreation.Create());

            presenter.PrintParty(gameRepository.CharacterParty);
        }
    }
}