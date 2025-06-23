using System;
using System.Collections.Generic;
using MemoryCardGame.Cards.Decorators;
using MemoryCardGame.Cards.Proxy;
using MemoryCardGame.Cards.Strategies;
using UnityEngine;
using Random = System.Random;

namespace MemoryCardGame.Cards.Factory
{
    public class DebuffCardFactory : ICardFactory
    {
        private static DebuffCard _predefinedCard = Resources.LoadAll<DebuffCard>("Cards/Debuff")[0];
        private static Dictionary<DebuffType, IEffectStrategy> _predefinedDebuffs = new()
        {
            { DebuffType.ShuffleCards, new ShuffleCardsStrategy() },
            { DebuffType.SubtractPoint, new SubtractPointStrategy() }
        };
        
        public Card CreateCard()
        {
            var cloned = _predefinedCard.Clone() as DebuffCard;
            var random = new Random();
            
            cloned.Debuff = _predefinedDebuffs[(DebuffType)random.Next(0, Enum.GetNames(typeof(DebuffType)).Length)];

            var decorated = ScriptableObject.CreateInstance<AudioCardDecorator>();
            decorated.SetBase(cloned);
            decorated.ClipProxy = new AudioClipProxy("Audio/Cards/" + cloned?.Path);

            return decorated;
        }
    }
}