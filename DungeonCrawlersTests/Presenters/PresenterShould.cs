using DungeonCrawlers.Presenters;
using Xunit;

namespace DungeonCrawlersTests.Presenters
{
    public class PresenterShould
    {
        private readonly IPresenter presenter = new Presenter();

        [Fact]
        public void ContainsCharacterPresenter()
        {
            // Then
            Assert.NotNull(presenter.CharacterPresenter);
        }
    }
}