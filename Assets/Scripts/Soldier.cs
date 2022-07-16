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
    
    private bool canShot=true;
    private Animator _animator;

    public int Health => _health;
    public event UnityAction<int> HealthChanged;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetWeapon(_defaultWeapon);
    }
    
    private void Update()
    {
        if (_health> 0 && TryDetectEnemy() && canShot)
        {
            canShot = false;
            UseWeapon();
        }
    }

    private void UseWeapon()
    {
        StartCoroutine(_weapon.CanImpact() ? DelayShoot(): DelayReload() );
    }
    
    IEnumerator DelayShoot()
    {
        _animator.SetTrigger("Impact");
        _weapon.Impact();
        yield return new WaitForSeconds(_weapon.SecondsBetweenImpact);
        if (!_weapon.CanImpact() && _weapon is Firearms)
            yield return StartCoroutine(DelayReload());
        canShot = true;
    }

    IEnumerator DelayReload()
    {
        canShot = false;
        _animator.SetTrigger("Reload");
        yield return new WaitForSeconds(((Firearms)_weapon).TimeReload);
        ((Firearms)_weapon).ReloadWeapon();
        canShot = true;
    }

    IEnumerator DelayDraw()
    {
        canShot = false;
        _animator.SetTrigger("Draw");
        yield return new WaitForSeconds(_secondsAtDraw);
        canShot = true;
    }

    public void TakeDamage(int damage){
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
            Die();
    }

    private bool TryDetectEnemy()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, _weapon.DistanceImpact, ~(1 << 8)))
            return hit.collider.gameObject.TryGetComponent<Soldier>(out Soldier soldier);
        return false;
    }

    public void SetWeapon(IWeapon weapon)
    {
        _weapon?.ChangeQuality(_weapon is Firearms?null:_transformWeaponContainer, !(_weapon is  Firearms));
        _weapon = weapon;
        _animator.SetInteger("WeaponLevel_int", _weapon.WeaponLevel);
        _animator.SetFloat("WeaponLevel_float", _weapon.WeaponLevel);
        StartCoroutine(DelayDraw());
        _weapon.ChangeQuality(_transformWeaponContainer);
    }

    private void Die() {
        _animator.SetInteger("Death_int",Random.Range(1,5));
        _animator.SetTrigger("Death");
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();
        collider.enabled = false;
    }
}
