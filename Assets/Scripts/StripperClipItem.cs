using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName="StripperClipItem", order=51)]
public class StripperClipItem : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
}
