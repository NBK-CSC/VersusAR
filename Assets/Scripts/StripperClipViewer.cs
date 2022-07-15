using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StripperClipViewer : MonoBehaviour
{
    [SerializeField] private Image _imageTemplate;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private int _distanceBetweenItems;
    
    private List<Image> _stripperClipItems=new List<Image>();
    

    public void ShowNumberStripperClip(int numberStripperClip, StripperClipItem stripperClipItem)
    {
        _imageTemplate.sprite = stripperClipItem.Sprite;
        for (int i = 0; i <= numberStripperClip; i++)
        {
            float x = (i - numberStripperClip * 0.5f)*_distanceBetweenItems;
            var view=Instantiate(_imageTemplate,transform);
            view.transform.localPosition = new Vector3(x, transform.position.y, 0);
            view.transform.rotation=transform.rotation;
            _stripperClipItems.Add(view);
        }
    }

    private void OnEnable()
    {
        _soldier.WeaponReloaded += ShowNumberStripperClip;
    }

    private void OnDisable()
    {
        _soldier.WeaponReloaded -= ShowNumberStripperClip;
    }
}
