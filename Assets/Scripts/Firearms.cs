using UnityEngine;

public class Firearms : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _defaultTransformParent;
    [SerializeField] private Ammunition _ammunitionTemlate;
    [SerializeField] private int _weaponLevel;
    [SerializeField] private int _amountAmmunitionsInStripperСlip;
    [SerializeField] private int _numberMaxAmmunitionsInStripperСlip;
    [SerializeField] private float _secondsBetweenShot;
    [SerializeField] private float _timeReload;

    public float DistanceImpact => _ammunitionTemlate.DistanceFlightAmmunition;
    public float TimeReload => _timeReload;
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

    public void ChangeQuality(Transform transformParent, bool isActive=false)
    {
        Transform tempTransformParent;
        if (transformParent is null)
            tempTransformParent = _defaultTransformParent;
        else tempTransformParent = transformParent;
        transform.parent =tempTransformParent;
        transform.rotation = tempTransformParent.rotation;
        transform.localPosition = new Vector3(0, 0, 0);
        //_collider.enabled = isActive;
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
