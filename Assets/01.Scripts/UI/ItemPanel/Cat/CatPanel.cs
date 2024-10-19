using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatPanel : MonoBehaviour
{
    private CatType _currentType;
    private Image _image;
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _priceText;
    private UI_CatBuyButton _buyButton;

    private void Awake() 
    {
        _image = transform.GetChild(0).GetComponent<Image>();
        _nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _priceText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _buyButton = transform.GetChild(3).GetComponent<UI_CatBuyButton>();
    }

    public void Init(CatType type)
    {
        CatSO cat = DataManager.Instance.GetCatData(type);
        _currentType = cat.Type;
        _image.sprite = cat.Image;
        _nameText.text = cat.Name;
        if (PlayerPrefs.GetInt(_currentType.ToString()) == 0)
            _priceText.text = $"{cat.Money}코인";

        _buyButton.Init(type, _currentType.ToString(), cat.Money);
    }

    public void ChangeCat()
    {
        _buyButton.ChangeCat();
    }
}
