using UnityEngine;

public class WaitAction : AIAction
{
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    private float _currentTime = 0;

    public override void OnStart()
    {
        _currentTime = Random.Range(_minTime, _maxTime);
    }

    public override void TakeAction()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
            _brain.ChangeState(_transition.PositiveState);
    }

    public override void OnEnd()
    {
    }
}
