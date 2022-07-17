using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Weapon;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _secondsAtDraw;
    [SerializeField] private Steelarms _defaultWeapon;
    [SerializeField] private Transform _transformWeaponContainer;
    
    private IWeapon _weapon;
    private bool _canShot=true;
    private Animator _animator;

    public int Health => _health;
    public float SecondsAtDraw => _secondsAtDraw;
    
    public event UnityAction<int> HealthChanged;
    public event UnityAction<IWeapon, Action<bool>> WeaponReceived;
    public event UnityAction<IWeapon, Action<bool>> WeaponImpacted;
    public event UnityAction<Firearms, Action<bool>> WeaponReloaded;
    public event UnityAction WeaponHandedOver;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetWeapon(_defaultWeapon);
    }
    
    private void Update()
    {
        if (_health> 0 && TryDetectEnemy() && _canShot)
        {
            _canShot = false;
            UseWeapon();
        }
    }

    private void UseWeapon()
    {
        if (_weapon.CanImpact())
            Impact();
        else if (_weapon.CanReload()!=true)
            SetWeapon(_defaultWeapon);
        else
            Reload((Firearms)_weapon);
    }

    private void Impact()
    {
        _weapon.Impact();
        WeaponImpacted?.Invoke(_weapon,value=>_canShot=value);
    }

    /*private IEnumerator DelayShoot()
    {
        _animator.SetTrigger("Impact");
        _weapon.Impact();
        yield return new WaitForSeconds(_weapon.SecondsBetweenImpact);
        if (!_weapon.CanImpact() && _weapon.CanReload())
            yield return StartCoroutine(DelayReload());
        _canShot = true;
    }*/

    /*private IEnumerator DelayReload()
    {
        _canShot = false;
        _animator.SetTrigger("Reload");
        yield return new WaitForSeconds(((Firearms)_weapon).TimeReload);
        Reload((Firearms)_weapon);
        _canShot = true;
    }*/

    private void Reload(Firearms weapon)
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
        _animator.SetInteger("Death_int",Random.Range(1,5));
        _animator.SetTrigger("Death");
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();
        collider.enabled = false;
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
        return _weapon is Steelarms;
    }

    public void SetWeapon(IWeapon weapon)
    {
        DropWeapon();
        _weapon = weapon ?? _defaultWeapon;
        WeaponReceived?.Invoke(weapon, value=>_canShot=value);
        _weapon.ChangeQuality(_transformWeaponContainer,false);
    }
}
