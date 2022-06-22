using UnityEngine;

public class FinderWeapon : MonoBehaviour
{
    [SerializeField] private Soldier _soldier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IWeapon>(out var weapon) && !(weapon is Steelarms))
            _soldier.SetWeapon(weapon);
    }
}
