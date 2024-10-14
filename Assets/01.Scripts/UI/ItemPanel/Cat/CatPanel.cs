using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatPanel : MonoBehaviour
{
    private CatType _currentType;
    private Image _image;
    private TextMeshProUGUI _nameText;
    private UI_BuyButton _buyButton;

    private void Awake() 
    {
        _image = transform.GetChild(0).GetComponent<Image>();
        _nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _buyButton = transform.GetChild(2).GetComponent<UI_BuyButton>();
    }

    public void Init(CatType type)
    {
        CatSO cat = DataManager.Instance.GetData(type);
        _currentType = cat.Type;
        _image.sprite = cat.Image;
        _nameText.text = cat.Name;

        _buyButton.Init(_currentType.ToString(), cat.Money);
    }
}
