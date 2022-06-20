using UnityEngine;

public class FinderWeapon : MonoBehaviour
{
    [SerializeField] private Soldier _soldier;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IWeapon>(out IWeapon weapon))
        {
            ((Firearms)weapon).transform.parent = transform;
            ((Firearms)weapon).transform.rotation = transform.rotation;
            ((Firearms)weapon).transform.localPosition = new Vector3(0, 0, 0);
            _soldier.Weapon = weapon;
        }
    }
}
