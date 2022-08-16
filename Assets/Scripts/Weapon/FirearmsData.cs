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
        [SerializeField] private AudioClip _drawAudio;
        [SerializeField][Range(0,1)] private float _drawAudioVolume;
        [SerializeField] private AudioClip _impactAudio;
        [SerializeField][Range(0,1)] private float _impactAudioVolume;
        [SerializeField] private AudioClip _reloadAudio;
        [SerializeField][Range(0,1)] private float _reloadAudioVolume;
        
        public int WeaponLevel => _weaponLevel;
        public int NumberMaxAmmunitionsInStripperСlip => _numberMaxAmmunitionsInStripperСlip;
        public int NumberMaxStripperСlip => _numberMaxStripperСlip;
        public float SecondsBetweenShot => _secondsBetweenShot;
        public float ShutterTwistTime => _shutterTwistTime;
        public float TimeReload => _timeReload;
        public Sprite Sprite => _sprite;
        public AudioClip DrawAudio => _drawAudio;
        public AudioClip ImpactAudio => _impactAudio;
        public AudioClip ReloadAudio => _reloadAudio;
        public float DrawAudioVolume => _drawAudioVolume;
        public float ImpactAudioVolume => _impactAudioVolume;
        public float ReloadAudioVolume => _reloadAudioVolume;
    }
}
