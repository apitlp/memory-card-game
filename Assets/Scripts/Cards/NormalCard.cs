using UnityEngine;

namespace MemoryCardGame.Cards
{
    [CreateAssetMenu(fileName = "NewNormalCard", menuName = "MemoryCardGame/NormalCard")]
    public class NormalCard : Card
    {
        public override IPrototype Clone()
        {
            return CloneAs<NormalCard>();
        }

        public override void OnClick()
        {
            
        }
    }
}