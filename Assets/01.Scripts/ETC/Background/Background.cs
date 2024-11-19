using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public static BackgroundSO CurrentBackground;

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
                SetBackground((BackgroundType)i);
        }
    }

    public void SetBackground(BackgroundType type)
    {
        CurrentBackground = DataManager.Instance.GetBackgroundData(type);
        _spriteRenderer.sprite = CurrentBackground.Image;
    }
}
