namespace DungeonCrawlers.Contracts.Character
{
    public interface ICharacterBuilder
    {
        ICharacter BuildCharacter();
        ICharacter BuildRandomCharacter(int nameSeed, int characterRaceSeed, int combatClassSeed);
    }
}