using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;

    private bool canShot=true;
    private int _amountAmmunitionsInStripperСlip;
    private float _lastShotTime;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Update(){
        if (_health> 0 && TryDetectEnemy() && canShot)
        {
            canShot = false;
            UseWeapon();
        }
    }

    private void UseWeapon()
    {
        StartCoroutine(_amountAmmunitionsInStripperСlip <= 0 ? DelayReload() : DelayShoot());
    }
    
    IEnumerator DelayShoot()
    {
        _animator.SetTrigger("Shoot");
        _weapon.Shoot();
        _amountAmmunitionsInStripperСlip--;
        yield return new WaitForSeconds(_weapon.SecondsBetweenShot);
        if (_amountAmmunitionsInStripperСlip<=0)
            yield return StartCoroutine(DelayReload());
        canShot = true;
    }

    IEnumerator DelayReload()
    {
        canShot = false;
        _animator.SetTrigger("Reload");
        yield return new WaitForSeconds(_weapon.TimeReload);
        _amountAmmunitionsInStripperСlip = _weapon.NumberMaxAmmunitionsInStripperСlip;//TODO
        canShot = true;
    }

    public void TakeDamage(int damage){
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private bool TryDetectEnemy()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
            return hit.collider.gameObject.TryGetComponent<Soldier>(out Soldier soldier);
        return false;
    }

    private void Die() {
        
    }   
}
