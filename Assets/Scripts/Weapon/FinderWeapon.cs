using UnityEngine;
using Object = UnityEngine.Object;

namespace Weapon
{
    public class FinderWeapon : MonoBehaviour
    {
        [SerializeField] private Soldier _soldier;
        
        private WeaponCard _currentWeaponCard;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<WeaponCard>(out var weaponCard) && _soldier.CanSetWeapon())
            {
                _soldier.SetWeapon(weaponCard.GetWeapon());
                _currentWeaponCard = weaponCard;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<WeaponCard>(out var weaponCard) && Object.Equals(weaponCard, _currentWeaponCard))
            {
                _soldier.SetWeapon();
                _currentWeaponCard = null;
            }
        }
    }
}
