using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    
    private void Update()
    {
        transform.Translate(Vector3.left * (_speed * Time.deltaTime));
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
