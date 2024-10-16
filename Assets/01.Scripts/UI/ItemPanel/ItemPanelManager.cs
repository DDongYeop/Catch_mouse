using System.Collections.Generic;
using UnityEngine;

public class ItemPanelManager : MonoBehaviour
{
    private Dictionary<ItemPanelType, GameObject> _itemPanelDic = new Dictionary<ItemPanelType, GameObject>();
    
    private void Awake() 
    {
        for (int i = 0; i < transform.GetChild(0).childCount; ++i)
            _itemPanelDic.Add((ItemPanelType)i, transform.GetChild(0).GetChild(i).gameObject);
    }

    private void Start() 
    {
        ChangePanel(ItemPanelType.BACKGROUND);
    }

    public void ChangePanel(ItemPanelType type)
    {
        foreach (var itemPanel in _itemPanelDic)
            itemPanel.Value.SetActive(false);

        _itemPanelDic[type].SetActive(true);
    }
}
