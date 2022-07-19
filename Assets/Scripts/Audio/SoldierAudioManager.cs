using System;
using UnityEngine;
using Weapon;

public class SoldierAudioManager : MonoBehaviour
{
    [SerializeField] private Soldier _soldier;
    
    private void OnEnable()
    {
        _soldier.WeaponImpacted += PlayImpact;
    }
    
    private void OnDisable()
    {
        _soldier.WeaponImpacted -= PlayImpact;
    }

    private void PlayImpact(IImpacting weapon, Action<bool> action)
    {
        
    }
}
