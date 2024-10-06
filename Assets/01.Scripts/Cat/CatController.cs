using UnityEngine;

public class CatController : MonoBehaviour
{
    [Header("Animator")]
    [HideInInspector] public CatAnimator Animator;

    [Header("Movement")]
    public float Speed;

    private void Awake() 
    {
        Animator = GetComponentInChildren<CatAnimator>();
    }
}
