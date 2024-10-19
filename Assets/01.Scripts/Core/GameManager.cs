using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Cat")]
    public CatController Cat;

    [Header("Coin")]
    [SerializeField] private TextMeshProUGUI _moneyText;
    private int _money;
    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            if (_moneyText)
                _moneyText.text = _money.ToString();
            PlayerPrefs.SetInt("Money", _money);
        }
    }

    [Header("Pooling")] 
    [SerializeField] private PoolingListSO _poolingList;

    [Header("Other")]
    public bool GamePlay = true;

    private void Awake() 
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;

        CreatePool();
        Init();
    }

    private void Init() 
    {
        if (!PlayerPrefs.HasKey(CatType.Cat01.ToString()))
        {
            for (int i = 0; i < (int)CatType.END; ++i)
                PlayerPrefs.SetInt(((CatType)i).ToString(), 0); 
            for (int i = 0; i < (int)BackgroundType.END; ++i)
                PlayerPrefs.SetInt(((BackgroundType)i).ToString(), 0); 
            PlayerPrefs.SetInt(CatType.Cat01.ToString(), 2); 
            PlayerPrefs.SetInt(BackgroundType.Background01.ToString(), 2); 
        }

        if (!PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetInt("Money", 0);
        Money = PlayerPrefs.GetInt("Money");

        GamePlay = true;
    }

    private void CreatePool()
    {
        PoolManager.Instance = new PoolManager(transform);
        _poolingList.PoolList.ForEach(p => PoolManager.Instance.CreatePool(p.Prefab, p.Count));
    }
}
