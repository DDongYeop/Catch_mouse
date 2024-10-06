using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    [Header("AI")]
    protected AIBrain _brain;
    protected AITransition _transition;

    private void Awake() 
    {
        _brain = GetComponentInParent<AIBrain>();
        _transition = GetComponentInParent<AITransition>();
    }

    public abstract void OnStart();
    public abstract void TakeAction();
    public abstract void OnEnd();
}
