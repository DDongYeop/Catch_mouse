using UnityEngine;
using UnityEngine.EventSystems;

public class MouseButton : UI_Button
{
    [SerializeField] private int _money;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        GameManager.Instance.Money += _money;
        GameManager.Instance.GamePlay = true;
        GameManager.Instance.PopupUI.SetActive(false);
    }
}
