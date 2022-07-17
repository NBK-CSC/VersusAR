using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Weapon
{
    public class StripperClipViewer : MonoBehaviour
    {
        [SerializeField] private Image _imageTemplate;
        [SerializeField] private Soldier _soldier;
        [SerializeField] private int _distanceBetweenItems;
    
        private List<Image> _stripperClipItems=new List<Image>();

        private void ShowNumberStripperClip(Firearms weapon, Action<bool> action )
        {
            DeleteSprites();
            _imageTemplate.sprite = weapon.StripperClip.Sprite;
            for (int i = 0; i <= weapon.AmountStripperСlip; i++)
            {
                float x = (i - weapon.AmountStripperСlip * 0.5f)*_distanceBetweenItems;
                var view=Instantiate(_imageTemplate,transform);
                view.transform.localPosition = new Vector3(x, transform.position.y, 0);
                view.transform.rotation=transform.rotation;
                _stripperClipItems.Add(view);
            }
        }

        private void OnEnable()
        {
            _soldier.WeaponReloaded += ShowNumberStripperClip;
            _soldier.WeaponHandedOver += DeleteSprites;
        }

        private void OnDisable()
        {
            _soldier.WeaponReloaded -= ShowNumberStripperClip;
            _soldier.WeaponHandedOver -= DeleteSprites;
        }

        private void DeleteSprites()
        {
            foreach (var stripperClipItem in _stripperClipItems)
            {
                Destroy(stripperClipItem);
            }
        }
    }
}
