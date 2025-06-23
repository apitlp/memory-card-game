namespace MemoryCardGame.Cards.Strategies
{
    public class ShuffleCardsStrategy : IEffectStrategy
    {
        public void Apply()
        {
            GameCore.Instance.Cards.Shuffle();
        }
    }
}