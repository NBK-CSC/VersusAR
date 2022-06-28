using UnityEngine;

public class WeaponCard : MonoBehaviour
{
    [SerializeField] private Firearms _weapon;

    public Firearms GetWeapon()
    {
        return _weapon;
    }

}
