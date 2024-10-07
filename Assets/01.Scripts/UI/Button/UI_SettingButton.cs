using UnityEngine;
using UnityEngine.EventSystems;

public class UI_SettingButton : UI_Button
{
    [SerializeField] private bool _settingPanelValue;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        UIManager.Instance.SetSettingPanel(_settingPanelValue);
    }
}
