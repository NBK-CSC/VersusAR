using System;
using System.Collections;
using UnityEngine;
using Weapon;
using Random = UnityEngine.Random;

public class SoldierAnimatorManager : MonoBehaviour
{
    [SerializeField] private Soldier _soldier;
    
    private Animator _soldierAnimator;
    
    private void Start()
    {
        _soldierAnimator = _soldier.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _soldier.WeaponReceived += PlayDraw;
        _soldier.WeaponImpacted += PlayImpact;
        _soldier.WeaponReloaded += PlayReload;
        _soldier.SoldierDied += PlayDie;
    }
    
    private void OnDisable()
    {
        _soldier.WeaponReceived -= PlayDraw;
        _soldier.WeaponImpacted -= PlayImpact;
        _soldier.WeaponReloaded -= PlayReload;
        _soldier.SoldierDied += PlayDie;

    }
    
    private void PlayDraw(IImpacting weapon, Action <bool> assignerAllow)
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

    private void PlayImpact(IImpacting weapon, Action <bool> assignerAllow)
    {
        StartCoroutine(DelayImpact(weapon, assignerAllow));
    }

    private IEnumerator DelayImpact(IImpacting weapon, Action <bool> assignerAllow)
    {
        _soldierAnimator.SetTrigger("Impact");
        yield return new WaitForSeconds(weapon.SecondsBetweenImpact);
        assignerAllow(true);
    }

    private void PlayReload(IRecharging weapon,Action <bool> assignerAllow )
    {
        StartCoroutine(DelayReload(weapon, assignerAllow));
    }
    
    private IEnumerator DelayReload(IRecharging weapon, Action <bool> assignerAllow)
    {
        assignerAllow(false);
        _soldierAnimator.SetTrigger("Reload");
        yield return new WaitForSeconds(weapon.TimeReload);
        assignerAllow(true);
    }

    private void PlayDie()
    {
        _soldierAnimator.SetInteger("Death_int",Random.Range(1,5));
        _soldierAnimator.SetTrigger("Death");
    }
}
