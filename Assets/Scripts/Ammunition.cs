using System;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _distanceFlightAmmunition;
    private Vector3 _startPosition;
    public float DistanceFlightAmmunition => _distanceFlightAmmunition;
    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * (_speed * Time.deltaTime));
        if ((transform.position-_startPosition).sqrMagnitude>=_distanceFlightAmmunition*_distanceFlightAmmunition)
            DestroyAmmunition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && other.TryGetComponent(out Soldier soldier))
        {
            soldier.TakeDamage(_damage);
            DestroyAmmunition();
        }
    }

    public void DestroyAmmunition()
    {
        Destroy(gameObject);
    }
}
