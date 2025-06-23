using System.Collections.Generic;
using System.Linq;
using MemoryCardGame.Cards.Decorators;
using MemoryCardGame.Cards.Proxy;
using UnityEngine;

namespace MemoryCardGame.Cards.Factory
{
    public class NormalCardFactory : ICardFactory
    {
        private static List<NormalCard> _predefinedCards = Resources.LoadAll<NormalCard>("Cards/Normal").ToList();

        private static int _currIndex = 0;
        
        public Card CreateCard()
        {
            var cloned = _predefinedCards[_currIndex % _predefinedCards.Count].Clone() as NormalCard;
            _currIndex++;

            var decorated = ScriptableObject.CreateInstance<AudioCardDecorator>();
            decorated.SetBase(cloned);
            decorated.ClipProxy = new AudioClipProxy("Audio/Cards/" + cloned?.Path);
            
            return decorated;
        }
    }
}