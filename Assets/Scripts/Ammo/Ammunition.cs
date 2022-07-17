using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _distanceFlightAmmunition;
    private Vector3 _startPosition;
    public float DistanceFlightAmmunition => _distanceFlightAmmunition;
    protected virtual void Start()
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

    protected virtual void DestroyAmmunition()
    {
        Destroy(gameObject);
    }
}
