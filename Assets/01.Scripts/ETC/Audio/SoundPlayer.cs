using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : PoolableMono
{
    private AudioSource _audioSource;

    private void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Init()
    {
        _audioSource.Play();

        StopAllCoroutines();
        StartCoroutine(ReturnPool());
    }

    private IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(_audioSource.clip.length + 0.5f);
        PoolManager.Instance.Push(this);
    }
}
