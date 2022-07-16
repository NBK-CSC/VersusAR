using UnityEngine;

public class Steelarms : MonoBehaviour, IWeapon
{
    [Header("Characteristic")]
    [SerializeField] private int _damage;
    [SerializeField] private int _weaponLevel;
    [SerializeField] private float _secondsBetweenHit;
    [SerializeField] private float _distanceAttack;
    [Header("Others")]
    [SerializeField] private Soldier _owner;
    [SerializeField] private ParticleSystem _particleTrackBlow;
    [SerializeField] private Transform _defaultTransformParent;

    public float DistanceImpact => _distanceAttack;
    public int WeaponLevel => _weaponLevel;
    public float SecondsBetweenImpact => _secondsBetweenHit;

    public void Impact()
    {
        _particleTrackBlow.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Soldier soldier) && !Equals(_owner, soldier))
            soldier.TakeDamage(_damage);
    }
    
    public void ChangeQuality(Transform transformParent, bool isNotActive)
    {
        Transform tempTransformParent = transformParent ?? _defaultTransformParent;
        transform.parent =tempTransformParent;
        transform.rotation = tempTransformParent.rotation;
        transform.localPosition = new Vector3(0, 0, 0);
        gameObject.SetActive(!isNotActive);
    }
    
    public bool CanImpact()
    {
        return gameObject.activeSelf;
    }
    
    public bool CanReload()
    {
        return false;
    }
}
