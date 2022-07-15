using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Steelarms _defaultWeapon;
    [SerializeField] private Transform _transformWeaponContainer;
    [SerializeField] private float _secondsAtDraw;

    private IWeapon _weapon;
    
    private bool _canShot=true;
    private Animator _animator;

    public int Health => _health;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int, StripperClipItem> WeaponReloaded;
    
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
        if (!_weapon.CanReload() && !_weapon.CanImpact())
        {
            SetWeapon(_defaultWeapon);
            return;
        }
        StartCoroutine(_weapon.CanImpact() ? DelayShoot(): DelayReload() );
    }
    
    private IEnumerator DelayShoot()
    {
        _animator.SetTrigger("Impact");
        _weapon.Impact();
        yield return new WaitForSeconds(_weapon.SecondsBetweenImpact);
        if (!_weapon.CanImpact() && _weapon.CanReload())
            yield return StartCoroutine(DelayReload());
        _canShot = true;
    }

    private IEnumerator DelayReload()
    {
        _canShot = false;
        _animator.SetTrigger("Reload");
        yield return new WaitForSeconds(((Firearms)_weapon).TimeReload);
        Reload((Firearms)_weapon);
        _canShot = true;
    }

    private void Reload(Firearms weapon)
    {
        weapon.ReloadWeapon();
        WeaponReloaded?.Invoke(weapon.AmountStripperСlip,weapon.StripperClip);
    }

    private IEnumerator DelayDraw()
    {
        _canShot = false;
        _animator.SetTrigger("Draw");
        yield return new WaitForSeconds(_secondsAtDraw);
        _canShot = true;
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
        _animator.SetInteger("WeaponLevel_int", _weapon.WeaponLevel);
        _animator.SetFloat("WeaponLevel_float", _weapon.WeaponLevel);
        StartCoroutine(DelayDraw());
        _weapon.ChangeQuality(_transformWeaponContainer,false);
    }
}
