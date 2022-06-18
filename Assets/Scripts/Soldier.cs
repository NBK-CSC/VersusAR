using System.Collections;
using Unity;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _secondsBetweenShot;
    [SerializeField] private int _amountAmmunitionInMagazine;

    private float _lastShootTime;
    private Animator _animator;
    
    private void Start()    {
        _animator = GetComponent<Animator>();
    }
    
    private void Update(){
        if (_lastShootTime <= 0){
            Fire();
            _lastShootTime = 30;
        }
        _lastShootTime -= Time.deltaTime;
    }

    private void Fire(){
        StartCoroutine(DelayShoot());
    }
    
    IEnumerator DelayShoot() {
        while(_amountAmmunitionInMagazine>0){
            _animator.SetTrigger("Shoot");
            _weapon.Shoot();
            _amountAmmunitionInMagazine--;
            yield return new WaitForSeconds(_secondsBetweenShot);
        }
        Reload();
    }

    private void Reload(){
        _animator.SetTrigger("Reload");
        _amountAmmunitionInMagazine = 30;//TODO
    }

    public void TakeDamage(int damage){
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die() {
        
    }   
}
