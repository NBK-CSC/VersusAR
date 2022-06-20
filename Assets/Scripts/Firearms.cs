using UnityEngine;

public class Firearms : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Ammunition _ammunitionTemlate;
    [SerializeField] private int _weaponLevel;
    [SerializeField] private int _amountAmmunitionsInStripperСlip;
    [SerializeField] private int _numberMaxAmmunitionsInStripperСlip;
    [SerializeField] private float _secondsBetweenShot;
    [SerializeField] private float _timeReload;
    
    public float TimeReload => _timeReload;
    public int AmountAmmunitionsInStripperСlip => _amountAmmunitionsInStripperСlip;
    public float SecondsBetweenImpact => _secondsBetweenShot;
    public int WeaponLevel => _weaponLevel;
    private void Start()
    {
        ReloadWeapon();
    }

    public bool CanImpact()
    {
        return _amountAmmunitionsInStripperСlip > 0;
    }
    
    public void ReloadWeapon()
    {
        _amountAmmunitionsInStripperСlip = _numberMaxAmmunitionsInStripperСlip;
    }

    public void Impact()
    {
        var rotationAmmunition = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0);
        Instantiate(_ammunitionTemlate, _shootPoint.position, rotationAmmunition);
        _amountAmmunitionsInStripperСlip--;
    }
}
