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

    [Header("Type")]
    private CatType _type;

    [Header("Other")]
    [HideInInspector] public int Dir = 1;

    private void Awake() 
    {
        Animator = GetComponentInChildren<CatAnimator>();
    }
    
    private void Start() 
    {
        Init();
    }

    private void Update() 
    {
        TouchCheck();
    }

    private void Init()
    {
        for (int i = 0; i < (int)CatType.END; ++i)
        {
            CatType type = (CatType)i;
            if (PlayerPrefs.GetInt(type.ToString()) == 2)
            {
                Animator.AnimatorChange(type);
                break;
            }
        }
    }

    private void TouchCheck() //입력을 확인
    {
        // 입력 & UI 체크
        if (!Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject()) 
            return;

        // 고양이인지 체크
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        if (!Physics2D.Raycast(pos, Vector2.zero, 1, _whatIsCat))
            return;

        PoolManager.Instance.Pop("MeowSound");
 
        float value = Random.Range(0.0f, 1.0f);
        if (value <= _getPercent / 100.0f)
            GameManager.Instance.Money += _addMoney;
    }

    public void CatTypeChange(CatType type)
    {
        _type = type;
        Animator.AnimatorChange(type);
    }
}
