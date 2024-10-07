using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemPanelSelectButton : UI_Button
{
    private ItemPanelManager _itemPanel;

    [SerializeField] private ItemPanelType _panelType;

    private void Awake() 
    {
        _itemPanel = transform.parent.GetComponentInParent<ItemPanelManager>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        _itemPanel.ChangePanel(_panelType);
    }
}
