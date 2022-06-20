using UnityEngine;

public class Steelarms : MonoBehaviour, IWeapon
{
    [SerializeField] private int _damage;
    [SerializeField] private int _weaponLevel;
    [SerializeField] private float _secondsBetweenHit;
    public int WeaponLevel => _weaponLevel;
    public float SecondsBetweenImpact => _secondsBetweenHit;

    public void Impact() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Soldier soldier))
            soldier.TakeDamage(_damage);
    }
    
    public bool CanImpact()
    {
        return true;
    }
}
