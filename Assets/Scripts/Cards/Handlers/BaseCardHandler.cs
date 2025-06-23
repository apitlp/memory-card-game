using UnityEngine;

namespace MemoryCardGame.Cards.Handlers
{
    public abstract class BaseCardHandler
    {
        protected BaseCardHandler Next;

        public void SetNext(BaseCardHandler next)
        {
            Next = next;
        }

        public void Handle(Card card)
        {
            card = Card.GetBaseCard(card);
                
            if (!TryHandle(card) && Next is not null)
                Next.Handle(card);
        }

        protected abstract bool TryHandle(Card card);
    }
}