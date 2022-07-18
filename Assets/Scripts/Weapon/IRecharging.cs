using UnityEngine;

namespace Weapon
{
    public interface IRecharging:IImpacting
    {
        public float TimeReload { get;}
        public int AmountStripperСlip { get; }
        public AudioClip ReloadAudio { get; }
        public Sprite StripperClipSprite { get; }
        public bool CanReload();
        public void ReloadWeapon();
    }
}