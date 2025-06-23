namespace MemoryCardGame.Cards.Strategies
{
    public class AdditionalTimeStrategy : IEffectStrategy
    {
        public void Apply()
        {
            GameCore.Instance.CurrentTime += 20f;
        }
    }
}