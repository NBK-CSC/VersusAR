using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private int _health;
    private IWeapon _weapon;
    
    private bool canShot=true;
    private float _lastShotTime;
    private Animator _animator;

    public int Health => _health;
    public IWeapon Weapon { set => _weapon= value; }
    public event UnityAction<int> HealthChanged;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        //_animator.SetInteger("LevelWeapon", _weapon.WeaponLevel);
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

    public void TakeDamage(int damage){
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
            Die();
    }

    private bool TryDetectEnemy()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~(1 << 8)))
            return hit.collider.gameObject.TryGetComponent<Soldier>(out Soldier soldier);
        return false;
    }
    
    private void Die() {
        _animator.SetInteger("DeathInt",Random.Range(1,5));
        _animator.SetTrigger("Death");
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();
        collider.enabled = false;
    }   
}
