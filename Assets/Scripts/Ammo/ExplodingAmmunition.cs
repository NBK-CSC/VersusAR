using System.Collections;
using UnityEngine;

public class ExplodingAmmunition : Ammunition
{
    [SerializeField] private ParticleSystem _exploadingParticleSystem;

    protected override void Start()
    {

    }
    
    protected override void DestroyAmmunition()
    {
        StartCoroutine(DelayExplode());
        gameObject.GetComponent<Renderer>().enabled=false;
        _speed = 0f;
    }

    private IEnumerator DelayExplode()
    {
        _exploadingParticleSystem.Play();
        while (_exploadingParticleSystem.isPlaying)
            yield return null;
        base.DestroyAmmunition();
    }
}
