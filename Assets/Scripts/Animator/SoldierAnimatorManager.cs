using System;
using System.Collections;
using UnityEngine;
using Weapon;

public class SoldierAnimatorManager : MonoBehaviour
{
    [SerializeField] private Soldier _soldier;
    [SerializeField] private Animator _soldierAnimator;

    private bool _canResume;
    
    private void OnEnable()
    {
        _soldier.WeaponReceived += PlayDraw;
        _soldier.WeaponImpacted += PlayImpact;
        _soldier.WeaponReloaded += PlayReload;
    }
    
    private void OnDisable()
    {
        _soldier.WeaponReceived -= PlayDraw;
        _soldier.WeaponImpacted -= PlayImpact;
        _soldier.WeaponReloaded -= PlayReload;
    }
    
    private void PlayDraw(IWeapon weapon, Action <bool> assignerAllow)
    {
        _soldierAnimator.SetInteger("WeaponLevel_int", weapon.WeaponLevel);
        _soldierAnimator.SetFloat("WeaponLevel_float", weapon.WeaponLevel);
        StartCoroutine(DelayDraw(assignerAllow));
    }
    
    private IEnumerator DelayDraw(Action <bool> assignerAllow)
    {
        assignerAllow(false);
        _soldierAnimator.SetTrigger("Draw");
        yield return new WaitForSeconds(_soldier.SecondsAtDraw);
        assignerAllow(true);
    }

    private void PlayImpact(IWeapon weapon, Action <bool> assignerAllow)
    {
        StartCoroutine(DelayImpact(weapon, assignerAllow));
    }

    private IEnumerator DelayImpact(IWeapon weapon, Action <bool> assignerAllow)
    {
        _soldierAnimator.SetTrigger("Impact");
        yield return new WaitForSeconds(weapon.SecondsBetweenImpact);
        assignerAllow(true);
    }

    private void PlayReload(Firearms weapon,Action <bool> assignerAllow )
    {
        StartCoroutine(DelayReload(weapon, assignerAllow));
    }
    
    private IEnumerator DelayReload(Firearms weapon, Action <bool> assignerAllow)
    {
        assignerAllow(false);
        _soldierAnimator.SetTrigger("Reload");
        yield return new WaitForSeconds(weapon.TimeReload);
        assignerAllow(true);
    }
}
