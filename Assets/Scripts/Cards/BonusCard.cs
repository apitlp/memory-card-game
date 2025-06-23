using MemoryCardGame.Cards.Strategies;
using UnityEngine;

namespace MemoryCardGame.Cards
{
    [CreateAssetMenu(fileName = "NewBonusCard", menuName = "MemoryCardGame/BonusCard")]
    
    public class BonusCard : Card
    {
        public IEffectStrategy Bonus { get; set; }
        
        public override IPrototype Clone()
        {
            var clone = CloneAs<BonusCard>();
            clone.Bonus = Bonus;

            return clone;
        }

        public override void OnClick()
        {
            
        }
    }
}