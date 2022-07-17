using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName="StripperClipItem", order=51)]
    public class StripperClipItem : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite => _sprite;
    }
}
