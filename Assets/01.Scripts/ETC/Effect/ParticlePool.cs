using System.Collections;
using UnityEngine;

public class ParticlePool : PoolableMono
{
    private ParticleSystem _particleSystem;

    private void Awake() 
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public override void Init()
    {
        StartCoroutine(ParticleCo());
    }

    private IEnumerator ParticleCo()
    {
        yield return new WaitForSeconds(_particleSystem.duration + 0.5f);
        PoolManager.Instance.Push(this);
    }
}
