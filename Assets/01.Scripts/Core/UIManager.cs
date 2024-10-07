using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Panel")]
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _shopPanel;

    private void Awake() 
    {
        if (Instance != null)
            Debug.LogError("Multiple UIManager is running");
        Instance = this;
    }

    public void SetSettingPanel(bool value)
    {
        _settingPanel.SetActive(value);
        GameManager.Instance.GamePlay = !value;
    }

    public void SetShopPanel(bool value)
    {
        _shopPanel.SetActive(value);
        GameManager.Instance.GamePlay = !value;
    }
}
