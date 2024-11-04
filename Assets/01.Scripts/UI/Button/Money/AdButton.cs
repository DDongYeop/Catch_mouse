using UnityEngine;
using UnityEngine.EventSystems;

public class AdButton : UI_Button
{
    private GameObject _logText;

    private void Awake() 
    {
        _logText = transform.GetChild(1).gameObject;
    }

    private void OnEnable() 
    {
        _logText.SetActive(false);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        //_logText.SetActive(true);
        
        AdMobManager.Instance.ShowRewardedAd();
        GameManager.Instance.GamePlay = true;
        GameManager.Instance.PopupUI.SetActive(false);
    }
}
