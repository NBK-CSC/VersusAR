using System;
using UnityEngine;
using Weapon;

[RequireComponent(typeof(AudioSource))]
public class SoldierAudioManager : MonoBehaviour
{
    private Soldier _soldier;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _soldier = GetComponent<Soldier>();
    }

    private void OnEnable()
    {
        _soldier.WeaponImpacted += PlayImpact;
        _soldier.WeaponReloaded += PlayReload;
        _soldier.WeaponReceived += PlayDraw;
    }
    
    private void OnDisable()
    {
        _soldier.WeaponImpacted -= PlayImpact;
        _soldier.WeaponReloaded -= PlayReload;
        _soldier.WeaponReceived -= PlayDraw;
    }

    private void PlayDraw(IImpacting weapon, Action<bool> action)
    {
        _audioSource.PlayOneShot(weapon.DrawAudio,weapon.DrawAudioVolume);
    }
    
    private void PlayImpact(IImpacting weapon, Action<bool> action)
    {
        _audioSource.PlayOneShot(weapon.ImpactAudio,weapon.ImpactAudioVolume);
    }
    
    private void PlayReload(IRecharging weapon, Action<bool> action)
    {
        _audioSource.PlayOneShot(weapon.ReloadAudio,weapon.ImpactAudioVolume);
    }
}
