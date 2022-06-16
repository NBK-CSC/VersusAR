using Unity;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _secondBetweenShot;

    private float _lastShootTime;
    private Animator _animator;

    private void Update()
    {
        if (_lastShootTime <= 0)
        {
            Fire();
            _lastShootTime = _secondBetweenShot;
        }

        _lastShootTime -= Time.deltaTime;
    }

    private void Fire()
    {
        _animator.Play("infantry_combat_shoot");
        _weapon.Shoot();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        
    }
}
