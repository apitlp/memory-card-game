using UnityEngine;

namespace MemoryCardGame.Cards.Factory
{
    public interface ICardFactory
    {
        Card CreateCard();
    }
}