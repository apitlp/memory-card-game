using MemoryCardGame.Cards.Proxy;
using UnityEngine;

namespace MemoryCardGame.Cards.Decorators
{
    public class AudioCardDecorator : Card
    {
        public Card Card { get; private set; }
        public AudioClipProxy ClipProxy { get; set; }

        public override void OnClick()
        {
            Card.OnClick();

            var audioClip = ClipProxy.Clip;
            if (audioClip is not null)
                AudioSource.PlayClipAtPoint(audioClip, Vector3.zero);
        }

        public override IPrototype Clone()
        {
            var clone = CloneAs<AudioCardDecorator>();
            clone.Card = Card.Clone() as Card;
            clone.ClipProxy = ClipProxy.Clone() as AudioClipProxy;

            return clone;
        }

        public void SetBase(Card card)
        {
            Card = card.Clone() as Card;
        }
    }
}