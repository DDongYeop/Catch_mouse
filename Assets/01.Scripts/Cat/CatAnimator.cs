using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    [Header("Components")]
    private Animator _animator;

    [Header("Hash")]
    private int _movementHash = Animator.StringToHash("Movement");

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovement(bool value)
    {
        _animator.SetBool(_movementHash, value);
    }
}
