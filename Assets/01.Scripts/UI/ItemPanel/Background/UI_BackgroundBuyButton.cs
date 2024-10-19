using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BackgroundBuyButton : UI_Button
{
    private ShopBackgroundPanel _shopCatPanel;

    private BackgroundType _type;
    private string _saveValue;
    private int _money;
    private TextMeshProUGUI _text;

    private void Awake() 
    {
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _shopCatPanel = transform.parent.parent.parent.parent.parent.parent.GetComponent<ShopBackgroundPanel>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        switch (PlayerPrefs.GetInt(_saveValue))
        {
            case 0:
                if (GameManager.Instance.Money < _money)
                    Debug.Log("구매 불가. (사유: 돈 없음)");
                else  
                {
                    GameManager.Instance.Money -= _money;
                    PlayerPrefs.SetInt(_saveValue, 1);
                    transform.parent.GetChild(2).gameObject.SetActive(false);
                    _text.text = "장착";
                }
                break;
            case 1:
                _shopCatPanel.ChangeBackground(_type);
                break;
        }
    }

    public void Init(BackgroundType type, string value, int money)
    {
        _type = type;
        _saveValue = value;
        _money = money;

        ChangeBackground();
    }

    public void ChangeBackground()
    {
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
