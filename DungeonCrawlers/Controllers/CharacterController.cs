using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;

namespace DungeonCrawlers.States
{
    public class CharacterController : ICharacterController
    {
        public ICharacter CreateCharacter(IDisplayer displayer, ICharacterBuilder characterBuilder)
        {
            return characterBuilder.BuildCharacter(displayer);
        }

        public void DisplayCharacterParty(IDisplayer displayer)
        {
            throw new System.NotImplementedException();
        }

        public IList<ICharacter> CreateCharacterParty(int numberOfPartyMembers)
        {
            throw new System.NotImplementedException();
        }
    }
}