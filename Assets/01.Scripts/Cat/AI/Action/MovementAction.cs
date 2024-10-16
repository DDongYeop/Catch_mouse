using UnityEngine;

public class MovementAction : AIAction
{
    [Header("Movement")]
    [SerializeField] private Vector2 _xValue;
    [SerializeField] private Vector2 _yValue;

    private Transform _root;
    private Vector2 _endPos;

    private void Start() 
    {
        _root = _brain.transform.parent;
    }

    public override void OnStart()
    {
        float xValue = Random.Range(_xValue.x, _xValue.y);
        float yValue = Random.Range(_yValue.x, _yValue.y);
        _endPos = new Vector2(xValue, yValue);

        _catController.Dir = (int)Mathf.Sign(transform.position.x - _endPos.x);

        _catController.Animator.SetMovement(true);
    }

    public override void TakeAction()
    {
        _root.position = Vector2.MoveTowards(_root.position, _endPos, _catController.Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _endPos) <= 0.01f)
            _brain.ChangeState(_transition.PositiveState);
    }

    public override void OnEnd()
    {
        _catController.Animator.SetMovement(false);
    }
}
