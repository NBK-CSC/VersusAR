using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shoopPoint;
    [SerializeField] private Bullet _bulletTemlate;
    [SerializeField] private int _numberMaxAmmunitionsInStripperСlip;
    [SerializeField] private float _secondsBetweenShot;
    [SerializeField] private float _timeReload;
    public int NumberMaxAmmunitionsInStripperСlip { get { return _numberMaxAmmunitionsInStripperСlip; } }
    public float SecondsBetweenShot { get { return _secondsBetweenShot; } }
    public float TimeReload { get { return _timeReload; } }

    public void Shoot()
    {
        Instantiate(_bulletTemlate, _shoopPoint.position, transform.rotation);
    }

}
