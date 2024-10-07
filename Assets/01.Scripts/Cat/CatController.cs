using UnityEngine;
using UnityEngine.EventSystems;

public class CatController : MonoBehaviour
{
    [Header("Animator")]
    [HideInInspector] public CatAnimator Animator;

    [Header("Movement")]
    public float Speed;

    [Header("Money")]
    [SerializeField] private LayerMask _whatIsCat;
    [SerializeField] private float _getPercent;
    [SerializeField] private int _addMoney;

    private void Awake() 
    {
        Animator = GetComponentInChildren<CatAnimator>();
    }

    private void Update() 
    {
        TouchCheck();
    }

    private void TouchCheck() //입력을 확인
    {
        if (!Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject())
            return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        if (!Physics2D.Raycast(pos, Vector2.zero, 1, _whatIsCat))
            return;

        PoolManager.Instance.Pop("MeowSound");
 
        float value = Random.Range(0.0f, 100.0f);
        if (value <= _getPercent)
            GameManager.Instance.Money += _addMoney;
    }
}
