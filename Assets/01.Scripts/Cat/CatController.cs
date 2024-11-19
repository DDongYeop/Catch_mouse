using UnityEngine;
using UnityEngine.EventSystems;

public class CatController : MonoBehaviour, GetTouch
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

    public void CatTypeChange(CatType type)
    {
        _type = type;
        Animator.AnimatorChange(type);
    }

    public bool Touch()
    {
        PoolManager.Instance.Pop("MeowSound");
 
        float value = Random.Range(0.0f, 1.0f);
        if (value <= (_getPercent + Background.CurrentBackground.AddMoneyPercent) / 100.0f)
        {
            GameManager.Instance.Money += _addMoney;
            return true;
        }
        return false;
    }
}
