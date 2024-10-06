using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [Header("AI")]
    private AIState _currentState = null;

    [Header("Other")]
    [HideInInspector] public CatController Controller;

    private void Awake() 
    {
        Controller = GetComponentInParent<CatController>();
    }

    private void Start() 
    {
        ChangeState(transform.GetChild(0).GetComponent<AIState>());
    }

    private void Update() 
    {
        _currentState.UpdateState();
    }

    public void ChangeState(AIState nextState)
    {
        _currentState?.OnEnd();
        _currentState = nextState;
        _currentState.OnStart();
    }
}
