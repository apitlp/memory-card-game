namespace MemoryCardGame.Cards.Strategies
{
    public class SubtractPointStrategy : IEffectStrategy
    {
        public void Apply()
        {
            GameCore.Instance.Players[GameCore.Instance.CurrentPlayerIndex].SubtractPoint();
            GameCore.Instance.NotifyPointsChanged();
        }
    }
}