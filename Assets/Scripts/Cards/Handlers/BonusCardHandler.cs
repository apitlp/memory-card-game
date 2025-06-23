namespace MemoryCardGame.Cards.Handlers
{
    public class BonusCardHandler : BaseCardHandler
    {
        protected override bool TryHandle(Card card)
        {
            if (card is BonusCard bonusCard)
            {
                bonusCard.Bonus.Apply();
                GameCore.Instance.HandleEffect(card);

                return true;
            }

            return false;
        }
    }
}