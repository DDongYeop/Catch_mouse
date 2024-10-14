using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BuyButton : UI_Button
{
    private string _saveValue;
    private int _money;
    private TextMeshProUGUI _text;

    private void Awake() 
    {
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }

    public void Init(string value, int money)
    {
        _saveValue = value;
        _money = money;

        switch (PlayerPrefs.GetInt(_saveValue))
        {
            case 0:
                _text.text = "구매";
                break;
            case 1:
                _text.text = "장착";
                break;
            case 2:
                _text.text = "장착 중";
                break;
        }
    }
}
