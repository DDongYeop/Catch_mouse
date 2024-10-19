using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanel : MonoBehaviour
{
    private BackgroundType _currentType;
    private Image _image;
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _priceText;
    private UI_BackgroundBuyButton _buyButton;

    private void Awake() 
    {
        _image = transform.GetChild(0).GetComponent<Image>();
        _nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _priceText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _buyButton = transform.GetChild(3).GetComponent<UI_BackgroundBuyButton>();
    }

    public void Init(BackgroundType type)
    {
        BackgroundSO background = DataManager.Instance.GetBackgroundData(type);
        _currentType = background.Type;
        _image.sprite = background.Image;
        _nameText.text = background.Name;
        if (PlayerPrefs.GetInt(_currentType.ToString()) == 0)
            _priceText.text = $"{background.Money}코인";

        _buyButton.Init(type, _currentType.ToString(), background.Money);
    }

    public void ChangeBackground()
    {
        _buyButton.ChangeBackground();
    }
}
