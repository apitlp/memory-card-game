using MemoryCardGame.Cards.Strategies;
using UnityEngine;

namespace MemoryCardGame.Cards
{
    [CreateAssetMenu(fileName = "NewDebuffCard", menuName = "MemoryCardGame/DebuffCard")]
    public class DebuffCard : Card
    {
        public IEffectStrategy Debuff { get; set; }

        public override IPrototype Clone()
        {
            var clone = CloneAs<DebuffCard>();
            clone.Debuff = Debuff;

            return clone;
        }

        public override void OnClick()
        {
            
        }
    }
}