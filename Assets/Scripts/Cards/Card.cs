using System;
using MemoryCardGame.Cards.Decorators;
using UnityEngine;

namespace MemoryCardGame.Cards
{ 
    public abstract class Card : ScriptableObject, IPrototype
    {
        public string Path;
        public string Content;
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public static Card GetBaseCard(Card card)
        {
            return card is AudioCardDecorator decorator ? decorator.Card : card;
        }
        
        protected T CloneAs<T>() where T : Card
        {
            var clone = CreateInstance<T>();

            clone.Content = Content;
            clone.Path = Path;

            return clone;
        }
        
        public abstract IPrototype Clone();

        public virtual void OnClick()
        {
        }
    }
}