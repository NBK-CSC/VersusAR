using UnityEngine;

public class FinderWeapon : MonoBehaviour
{
    [SerializeField] private Soldier _soldier;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IWeapon>(out IWeapon weapon))
            _soldier.SetWeapon(weapon);
    }
}
