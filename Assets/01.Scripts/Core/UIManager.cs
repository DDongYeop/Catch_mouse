using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("SettingPanel")]
    [SerializeField] private GameObject _settingPanel;

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
}
