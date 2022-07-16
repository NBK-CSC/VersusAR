using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Firearms : MonoBehaviour, IWeapon
{

    [Header("Characteristic")]
    [SerializeField] private int _weaponLevel;
    [SerializeField] private int _numberMaxAmmunitionsInStripperСlip;
    [SerializeField] private int _numberMaxStripperСlip;
    [SerializeField] private float _secondsBetweenShot;
    [SerializeField] private float _timeReload;
    [SerializeField] private float _shutterTwistTime;
    
    [SerializeField] private StripperClipItem _stripperClipItem;
    
    [Header("Ammunition")]
    [SerializeField] private Ammunition _ammunitionTemlate;
    
    [Header("Others")]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _defaultTransformParent;
    [SerializeField] [CanBeNull] private ParticleSystem _particleEjectionShells;
    
    private int _amountAmmunitionsInStripperСlip;
    private int _amountStripperСlip;

    public float DistanceImpact => _ammunitionTemlate.DistanceFlightAmmunition;
    public float TimeReload => _timeReload;
    public float SecondsBetweenImpact => _secondsBetweenShot;
    public int WeaponLevel => _weaponLevel;
    public int AmountStripperСlip => _amountStripperСlip;
    public StripperClipItem StripperClip => _stripperClipItem;
    private void Start()
    {
        ReloadWeapon();
        Refill();
    }

    public bool CanImpact()
    {
        return _amountAmmunitionsInStripperСlip > 0;
    }

    public void ChangeQuality(Transform transformParent, bool isActive)
    {
        Transform tempTransformParent = transformParent ?? _defaultTransformParent;
        transform.parent =tempTransformParent;
        transform.rotation = tempTransformParent.rotation;
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public bool CanReload()
    {
        return _amountStripperСlip > 0;
    }

    public void ReloadWeapon()
    {
        if (_amountStripperСlip > 0)
        {
            _amountAmmunitionsInStripperСlip = _numberMaxAmmunitionsInStripperСlip;
            _amountStripperСlip--;
        }
    }


    private void Refill()
    {
        _amountStripperСlip = _numberMaxStripperСlip;
    }

    private IEnumerator DelayExtractionSpentSleeve()
    {
        yield return new WaitForSeconds(_shutterTwistTime);
        if (_particleEjectionShells)
            _particleEjectionShells.Play();
    }

    public void Impact()
    {
        var rotationAmmunition = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0);
        Instantiate(_ammunitionTemlate, _shootPoint.position, rotationAmmunition);
        StartCoroutine(DelayExtractionSpentSleeve());
        _amountAmmunitionsInStripperСlip--;
    }
}
