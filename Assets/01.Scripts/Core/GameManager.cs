using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    }

    private void Start() 
    {
        GamePlay = true;

        if (!PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetInt("Money", 0);
        Money = PlayerPrefs.GetInt("Money");
    }

    private void CreatePool()
    {
        PoolManager.Instance = new PoolManager(transform);
        _poolingList.PoolList.ForEach(p => PoolManager.Instance.CreatePool(p.Prefab, p.Count));
    }
}