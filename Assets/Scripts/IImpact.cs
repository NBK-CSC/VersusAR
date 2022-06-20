public interface IWeapon
{
    public int WeaponLevel { get;}
    public float SecondsBetweenImpact { get;}
    public void Impact();
    public bool CanImpact();
}
