using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName="SteelarmsData",menuName = "Weapon Data/Steelarms Data", order=51)]
    public class SteelarmsData:ScriptableObject
    {
        [Header("Characteristic")]
        [SerializeField] private int _damage;
        [SerializeField] private int _weaponLevel;
        [SerializeField] private float _secondsBetweenHit;
        [SerializeField] private float _distanceAttack;
        [Header("Audio")]
        [SerializeField] private AudioClip _impactAudio;

        public int Damage => _damage;
        public int WeaponLevel => _weaponLevel;
        public float SecondsBetweenHit => _secondsBetweenHit;
        public float DistanceAttack => _distanceAttack;
        public AudioClip ImpactAudio => _impactAudio;
    }
}