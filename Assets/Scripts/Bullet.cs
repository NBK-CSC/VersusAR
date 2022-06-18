using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    
    private void Update()
    {
        transform.Translate(Vector3.left * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Soldier soldier))
            soldier.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
