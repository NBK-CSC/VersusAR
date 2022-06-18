using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shoopPoint;
    [SerializeField] private Bullet _bulletTemlate;
    
    public void Shoot()
    {
        Instantiate(_bulletTemlate, _shoopPoint.position, transform.rotation);
    }

}
