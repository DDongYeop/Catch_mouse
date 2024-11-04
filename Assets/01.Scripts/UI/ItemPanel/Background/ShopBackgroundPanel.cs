using System.Collections.Generic;
using UnityEngine;

public class ShopBackgroundPanel : MonoBehaviour
{
    private Transform _contectTrm;

    [Header("Background")]
    [SerializeField] private SpriteRenderer _background;

    [Header("SpawnObj")]
    [SerializeField] private GameObject _horizontalLayoutGroup;
    [SerializeField] private BackgroundPanel _backgroundPanel;
    private List<GameObject> _spawnObject = new List<GameObject>();
    private List<BackgroundPanel> _backgroundPanels = new List<BackgroundPanel>();
    private Transform _currentHorizontal;

    private void Awake() 
    {
        _contectTrm = transform.GetChild(0).GetChild(0).GetChild(0);
    }

    private void OnEnable() 
    {
        foreach (var obj in _spawnObject)
            Destroy(obj);
            
        _spawnObject = new List<GameObject>();
        _backgroundPanels = new List<BackgroundPanel>();

        for (int i = 0; i < (int)BackgroundType.END; ++i)
        {
            if (i % 2 == 0)
            {
                _currentHorizontal = Instantiate(_horizontalLayoutGroup, _contectTrm).transform;
                _spawnObject.Add(_currentHorizontal.gameObject);
            }
            BackgroundPanel panel = Instantiate(_backgroundPanel, _currentHorizontal);
            _backgroundPanels.Add(panel);
            panel.Init((BackgroundType)i);
        }
    }

    public void ChangeBackground(BackgroundType type)
    {
        _background.sprite = DataManager.Instance.GetBackgroundData(type).Image;

        for (int i = 0; i < (int)BackgroundType.END; ++i)
        {
            if (PlayerPrefs.GetInt(((BackgroundType)i).ToString()) == 2)
            {
                PlayerPrefs.SetInt(((BackgroundType)i).ToString(), 1);
                break;
            }
        }

        PlayerPrefs.SetInt(type.ToString(), 2);
        foreach (var panel in _backgroundPanels)
            panel.ChangeBackground();
    }
}
