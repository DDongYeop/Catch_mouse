using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ShopButton : UI_Button
{
    [SerializeField] private bool _shopPanelValue;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        UIManager.Instance.SetShopPanel(_shopPanelValue);
    }
}
