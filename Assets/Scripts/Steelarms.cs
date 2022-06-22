using System;
using UnityEngine;

public class Steelarms : MonoBehaviour, IWeapon
{
    [SerializeField] private int _damage;
    [SerializeField] private int _weaponLevel;
    [SerializeField] private float _secondsBetweenHit;
    [SerializeField] private float _distanceAttack;
    [SerializeField] private Soldier _owner;
    
    public float DistanceImpact => _distanceAttack;
    public int WeaponLevel => _weaponLevel;
    public float SecondsBetweenImpact => _secondsBetweenHit;

    public void Impact() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Soldier soldier) && !Equals(_owner, soldier))
            soldier.TakeDamage(_damage);
    }
    
    public void ChangeQuality(Transform transformParent, bool isActive=false)
    {
        transform.parent =transformParent;
        transform.rotation = transformParent.rotation;
        transform.localPosition = new Vector3(0, 0, 0);
        gameObject.SetActive(!isActive);
    }
    
    public bool CanImpact()
    {
        return true;
    }
}
