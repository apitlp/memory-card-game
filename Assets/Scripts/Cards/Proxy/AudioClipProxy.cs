using UnityEngine;

namespace MemoryCardGame.Cards.Proxy
{
    public class AudioClipProxy : IPrototype
    {
        private string _path;
        private AudioClip _clip;

        public AudioClip Clip
        {
            get
            {
                if (_clip == null)
                    _clip = Resources.Load<AudioClip>(_path);
                
                return _clip;
            } 
        }

        public AudioClipProxy(string path)
        {
            _path = path;
        }

        public bool IsValid() => Clip != null;

        public IPrototype Clone()
        {
            return new AudioClipProxy(_path);
        }
    }
}