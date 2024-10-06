using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    [Header("AI")]
    private AIBrain _brain;
    private AIAction[] _action;

    private void Awake() 
    {
        _brain = GetComponent<AIBrain>();
        _action = GetComponentsInChildren<AIAction>();
    }

    public void OnStart()
    {
        foreach (var action in _action)
            action.OnStart();
    }

    public void UpdateState()
    {
        TakeAction();
    }

    public void OnEnd()
    {
        foreach (var action in _action)
            action.OnEnd();
    }

    private void TakeAction()
    {
        foreach (var action in _action)
            action.TakeAction();
    }
}
