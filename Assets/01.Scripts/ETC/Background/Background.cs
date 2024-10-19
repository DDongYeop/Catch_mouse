using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < (int)BackgroundType.END; ++i)
        {
            if (PlayerPrefs.GetInt(((BackgroundType)i).ToString()) == 2)
                _spriteRenderer.sprite = DataManager.Instance.GetBackgroundData((BackgroundType)i).Image;
        }
    }
}
