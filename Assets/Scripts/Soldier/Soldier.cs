using System;
using UnityEngine;
using UnityEngine.Events;
using Weapon;

[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _secondsAtDraw;
    [SerializeField] private Steelarms _defaultWeapon;
    [SerializeField] private Transform _transformWeaponContainer;
    
    private IImpacting _weapon;
    private bool _canShot=true;
    private bool _usingSteelArms;

    public int Health => _health;
    public float SecondsAtDraw => _secondsAtDraw;
    
    public event UnityAction<int> HealthChanged;
    public event UnityAction<IImpacting, Action<bool>> WeaponReceived;
    public event UnityAction<IImpacting, Action<bool>> WeaponImpacted;
    public event UnityAction<IRecharging, Action<bool>> WeaponReloaded;
    public event UnityAction WeaponHandedOver;
    public event UnityAction SoldierDied;
    private void Start()
    {
        SetWeapon();
    }
    
    private void Update()
    {
        if (_health> 0 && TryDetectEnemy() && _canShot)
        {
            _canShot = false;
            if (_usingSteelArms)
                UseSteelarmsWeapon();
            else
                UseFirearmsWeapon();
        }
    }

    private void UseFirearmsWeapon()
    {
        if (_weapon.CanImpact())
            Impact();
        else if (((IRecharging)_weapon).CanReload())
            Reload((IRecharging)_weapon);
        else
            SetWeapon();
    }
    
    private void UseSteelarmsWeapon()
    {
        if (_weapon.CanImpact())
            Impact();
    }

    private void Impact()
    {
        _weapon.Impact();
        WeaponImpacted?.Invoke(_weapon,value=>_canShot=value);
    }
    
    private void Reload(IRecharging weapon)
    {
        weapon.ReloadWeapon();
        WeaponReloaded?.Invoke(weapon, value=>_canShot=value);
    }
    
    private bool TryDetectEnemy()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, _weapon.DistanceImpact, ~(1 << 8)))
            return hit.collider.gameObject.TryGetComponent<Soldier>(out Soldier soldier);
        return false;
    }
    
    private void Die() {
        SoldierDied?.Invoke();
        BoxCollider colliderComponent = gameObject.GetComponent<BoxCollider>();
        colliderComponent.enabled = false;
    }
    
    private void DropWeapon()
    {
        _weapon?.ChangeQuality(null, true);
        WeaponHandedOver?.Invoke();
    }
    
    public void TakeDamage(int damage){
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
            Die();
    }
    
    public bool CanSetWeapon()
    {
        return _usingSteelArms;
    }

    public void SetWeapon()
    {
        DropWeapon();
        _weapon = _defaultWeapon;
        _usingSteelArms = true;
        WeaponReceived?.Invoke(_weapon, value=>_canShot=value);
        _weapon.ChangeQuality(_transformWeaponContainer,false);
    }
    
    public void SetWeapon(IRecharging weapon)
    {
        DropWeapon();
        _weapon = weapon;
        _usingSteelArms = false;
        WeaponReceived?.Invoke(_weapon, value=>_canShot=value);
        _weapon.ChangeQuality(_transformWeaponContainer,false);
    }
}
