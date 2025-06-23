using System;
using System.Collections.Generic;

namespace MemoryCardGame.Cards
{
    public static class CardsExtensions
    {
        public static void Shuffle(this List<Card> cards)
        {
            var random = new Random();
            
            var n = cards.Count;
            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                (cards[n], cards[k]) = (cards[k], cards[n]);
            }
        }

        public static void Deconstruct(this List<Card> cards, out Card left, out Card right)
        {
            left = cards[0];
            right = cards[1];
        }

        public static int GetIndex(this List<Card> cards, Card card)
        {
            return cards.FindIndex(c => c is not null && 
                Card.GetBaseCard(c).Id == Card.GetBaseCard(card).Id);
        }
    }
}