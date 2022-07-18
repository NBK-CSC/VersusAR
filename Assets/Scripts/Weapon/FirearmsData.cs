using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName="FirearmsData",menuName = "Weapon Data/Firearms Data",order=51)]
    public class FirearmsData:ScriptableObject
    {
        [Header("Characteristic")]
        [SerializeField] private int _weaponLevel;
        [SerializeField] private int _numberMaxAmmunitionsInStripperСlip;
        [SerializeField] private int _numberMaxStripperСlip;

        [Header("Time")]
        [SerializeField] private float _secondsBetweenShot;
        [SerializeField] private float _shutterTwistTime;
        [SerializeField] private float _timeReload;
  
        [Header("Audio/Sprites")]
        [SerializeField] private Sprite _sprite;
        [SerializeField] private AudioClip _impactAudio;
        [SerializeField] private AudioClip _reloadAudio;
        
        public int WeaponLevel => _weaponLevel;
        public int NumberMaxAmmunitionsInStripperСlip => _numberMaxAmmunitionsInStripperСlip;
        public int NumberMaxStripperСlip => _numberMaxStripperСlip;
        public float SecondsBetweenShot => _secondsBetweenShot;
        public float ShutterTwistTime => _shutterTwistTime;
        public float TimeReload => _timeReload;
        public Sprite Sprite => _sprite;
        public AudioClip ImpactAudio => _impactAudio;
        public AudioClip ReloadAudio => _reloadAudio;
    }
}
