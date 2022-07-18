namespace Weapon
{
    public interface IRecharging:IImpacting
    {
        public FirearmsData WeaponData { get; }
        public float TimeReload { get;}
        public int AmountStripperСlip { get; }
        public bool CanReload();
        public void ReloadWeapon();
    }
}