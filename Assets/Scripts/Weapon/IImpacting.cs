using UnityEngine;

namespace Weapon
{
    public interface IImpacting
    {
        public float DistanceImpact { get; }
        public int WeaponLevel { get;}
        public float SecondsBetweenImpact { get;}
        public AudioClip ImpactAudio { get;}
        public AudioClip DrawAudio { get;}
        public float ImpactAudioVolume { get;}
        public float DrawAudioVolume { get;}
        public void Impact();
        public bool CanImpact();
        public void ChangeQuality(Transform transformParent, bool isActive);
    }
}