using System;
using System.Collections.Generic;
using MemoryCardGame.Cards.Decorators;
using MemoryCardGame.Cards.Proxy;
using MemoryCardGame.Cards.Strategies;
using UnityEngine;
using Random = System.Random;

namespace MemoryCardGame.Cards.Factory
{
    public class BonusCardFactory : ICardFactory
    {
        private static BonusCard _predefinedCard = Resources.LoadAll<BonusCard>("Cards/Bonus")[0];
        private static Dictionary<BonusType, IEffectStrategy> _predefinedBonuses = new()
        {
            { BonusType.AdditionalTime, new AdditionalTimeStrategy() },
            { BonusType.AddPoint, new AddPointStrategy() }
        };
        
        public Card CreateCard()
        {
            var cloned = _predefinedCard.Clone() as BonusCard;
            var random = new Random();
            
            cloned.Bonus = _predefinedBonuses[(BonusType)random.Next(0, Enum.GetNames(typeof(BonusType)).Length)];

            var decorated = ScriptableObject.CreateInstance<AudioCardDecorator>();
            decorated.SetBase(cloned);
            decorated.ClipProxy = new AudioClipProxy("Audio/Cards/" + cloned.Path);

            return decorated;
        }
    }
}