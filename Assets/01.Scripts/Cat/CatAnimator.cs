using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    [Header("Components")]
    private CatController _catController;
    private Animator _animator;

    [Header("Hash")]
    private int _movementHash = Animator.StringToHash("Movement");

    private void Awake() 
    {
        _catController = transform.parent.GetComponent<CatController>();
        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        transform.localScale = new Vector3(_catController.Dir != 1 ? _catController.Dir : 1, 1, 1);
    }

    public void SetMovement(bool value)
    {
        _animator.SetBool(_movementHash, value);
    }

    public void AnimatorChange(CatType type)
    {
        var resourceName = "Cat/Animator/" + type.ToString();
        _animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resourceName);
    }
}
