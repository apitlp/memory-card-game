namespace MemoryCardGame.Cards.Strategies
{
    public class AddPointStrategy : IEffectStrategy
    {
        public void Apply()
        {
            GameCore.Instance.Players[GameCore.Instance.CurrentPlayerIndex].AddPoint();
            GameCore.Instance.NotifyPointsChanged();
        }
    }
}