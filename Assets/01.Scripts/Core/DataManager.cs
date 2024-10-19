using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public List<CatSO> CatDatas = new List<CatSO>();
    public List<BackgroundSO> BackgroundDatas = new List<BackgroundSO>();
    private Dictionary<CatType, CatSO> _catDictionary = new Dictionary<CatType, CatSO>();
    private Dictionary<BackgroundType, BackgroundSO> _backgroundDictionary = new Dictionary<BackgroundType, BackgroundSO>();

    private void Awake() 
    {
        if (Instance != null)
            Debug.LogError("Multiple DataManager is running");
        Instance = this;

        Init();
    }

    private void Init() 
    {
        for (int i = 0; i < CatDatas.Count; ++i)
            _catDictionary.Add(CatDatas[i].Type, CatDatas[i]);

        for (int i = 0; i < BackgroundDatas.Count; ++i)
            _backgroundDictionary.Add(BackgroundDatas[i].Type, BackgroundDatas[i]);
    }

    public CatSO GetCatData(CatType type) => _catDictionary[type];
    public BackgroundSO GetBackgroundData(BackgroundType type) => _backgroundDictionary[type];

    [ContextMenu("DeleteAllData")]
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
