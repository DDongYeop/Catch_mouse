using System.Collections.Generic;
using UnityEngine;

public class ShopCatPanel : MonoBehaviour
{
    private Transform _contectTrm;

    [Header("SpawnObj")]
    [SerializeField] private GameObject _horizontalLayoutGroup;
    [SerializeField] private CatPanel _catPanel;
    private List<GameObject> _spawnObject = new List<GameObject>();
    private List<CatPanel> _catPanels = new List<CatPanel>();
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
        _catPanels = new List<CatPanel>();

        for (int i = 0; i < (int)CatType.END; ++i)
        {
            if (i % 2 == 0)
            {
                _currentHorizontal = Instantiate(_horizontalLayoutGroup, _contectTrm).transform;
                _spawnObject.Add(_currentHorizontal.gameObject);
            }
            CatPanel panel = Instantiate(_catPanel, _currentHorizontal);
            _catPanels.Add(panel);
            panel.Init((CatType)i);
        }
    }

    public void ChangeCat(CatType type)
    {
        GameManager.Instance.Cat.TypeChange(type);

        for (int i = 0; i < (int)CatType.END; ++i)
        {
            if (PlayerPrefs.GetInt(((CatType)i).ToString()) == 2)
            {
                PlayerPrefs.SetInt(((CatType)i).ToString(), 1);
                break;
            }
        }

        PlayerPrefs.SetInt(type.ToString(), 2);
        foreach (var panel in _catPanels)
            panel.ChangeCat();
    }
}
