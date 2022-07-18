using UnityEngine;

namespace Weapon
{
    public class Steelarms : MonoBehaviour, IImpacting
    {
        [SerializeField] private SteelarmsData _weaponData;
        [SerializeField] private Soldier _owner;
        [SerializeField] private ParticleSystem _particleTrackBlow;
        [SerializeField] private Transform _defaultTransformParent;

        public float DistanceImpact => _weaponData.DistanceAttack;
        public int WeaponLevel => _weaponData.WeaponLevel;
        public float SecondsBetweenImpact => _weaponData.SecondsBetweenHit;
        public SteelarmsData WeaponData => _weaponData;

        public void Impact()
        {
            _particleTrackBlow.Play();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Soldier soldier) && !Equals(_owner, soldier))
                soldier.TakeDamage(_weaponData.Damage);
        }
    
        public void ChangeQuality(Transform transformParent, bool isNotActive)
        {
            Transform tempTransformParent = transformParent ? transformParent : _defaultTransformParent;
            transform.parent =tempTransformParent;
            transform.rotation = tempTransformParent.rotation;
            transform.localPosition = new Vector3(0, 0, 0);
            gameObject.SetActive(!isNotActive);
        }
    
        public bool CanImpact()
        {
            return gameObject.activeSelf;
        }
    }
}
