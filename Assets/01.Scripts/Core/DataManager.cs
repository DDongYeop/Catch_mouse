using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public List<CatSO> CatDatas = new List<CatSO>();
    private Dictionary<CatType, CatSO> _catDictionary = new Dictionary<CatType, CatSO>();

    private void Awake() 
    {
        if (Instance != null)
            Debug.LogError("Multiple DataManager is running");
        Instance = this;
    }

    private void Start() 
    {
        for (int i = 0; i < CatDatas.Count; ++i)
            _catDictionary.Add(CatDatas[i].Type, CatDatas[i]);
    }

    public CatSO GetData(CatType type) => _catDictionary[type];

    [ContextMenu("DeleteAllData")]
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
