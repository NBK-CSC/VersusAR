using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Weapon
{
    public class Firearms : MonoBehaviour, IRecharging
    {
        [Header("Ammunition and Settings")]
        [SerializeField] private FirearmsData _weaponData;
        [SerializeField] private Ammunition _ammunitionTemlate;
    
        [Header("Others")]
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Transform _defaultTransformParent;
        [SerializeField] [CanBeNull] private ParticleSystem _particleEjectionShells;
    
        private int _amountAmmunitionsInStripperСlip;
        private int _amountStripperСlip;

        public float DistanceImpact => _ammunitionTemlate.DistanceFlightAmmunition;
        public float SecondsBetweenImpact => _weaponData.SecondsBetweenShot;
        public int WeaponLevel => _weaponData.WeaponLevel;
        public float TimeReload => _weaponData.TimeReload;
        public int AmountStripperСlip => _amountStripperСlip;
        public AudioClip ImpactAudio => _weaponData.ImpactAudio;
        public AudioClip ReloadAudio => _weaponData.ReloadAudio;
        public Sprite StripperClipSprite => _weaponData.Sprite;
        private void Start()
        {
            ReloadWeapon();
            Refill();
        }

        public bool CanImpact()
        {
            return _amountAmmunitionsInStripperСlip > 0;
        }

        public void ChangeQuality(Transform transformParent, bool isActive)
        {
            Transform tempTransformParent = transformParent ? transformParent : _defaultTransformParent;
            transform.parent =tempTransformParent;
            transform.rotation = tempTransformParent.rotation;
            transform.localPosition = new Vector3(0, 0, 0);
        }

        public bool CanReload()
        {
            return _amountStripperСlip > 0;
        }

        public void ReloadWeapon()
        {
            if (_amountStripperСlip > 0)
            {
                _amountAmmunitionsInStripperСlip = _weaponData.NumberMaxAmmunitionsInStripperСlip;
                _amountStripperСlip--;
            }
        }
        
        private void Refill()
        {
            _amountStripperСlip = _weaponData.NumberMaxStripperСlip;
        }

        private IEnumerator DelayExtractionSpentSleeve()
        {
            yield return new WaitForSeconds(_weaponData.ShutterTwistTime);
            if (_particleEjectionShells)
                _particleEjectionShells.Play();
        }

        public void Impact()
        {
            var rotationAmmunition = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0);
            Instantiate(_ammunitionTemlate, _shootPoint.position, rotationAmmunition);
            StartCoroutine(DelayExtractionSpentSleeve());
            _amountAmmunitionsInStripperСlip--;
        }
    }
}
