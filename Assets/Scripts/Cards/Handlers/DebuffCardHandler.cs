namespace MemoryCardGame.Cards.Handlers
{
    public class DebuffCardHandler : BaseCardHandler
    {
        protected override bool TryHandle(Card card)
        {
            if (card is DebuffCard debuffCard)
            {
                debuffCard.Debuff.Apply();
                GameCore.Instance.HandleEffect(card);

                return true;
            }

            return false;
        }
    }
}