using UnityEngine;

public interface IWeapon
{
    public float DistanceImpact { get; }
    public int WeaponLevel { get;}
    public float SecondsBetweenImpact { get;}
    public void Impact();
    public bool CanImpact();
    public void ChangeQuality(Transform transformParent, bool isActive=false);
}
