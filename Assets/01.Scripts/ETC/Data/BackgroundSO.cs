using UnityEngine;

[CreateAssetMenu (menuName = "SO/Data/Background", fileName = "Background")]
public class BackgroundSO : ScriptableObject
{
    [Header("Data")]
    public BackgroundType Type;
    public string Name;
    public Sprite Image;
    public int Money;

    [Header("Effect")]
    public float AddMoneyPercent; // 추가로 돈 얻는 비율
    public float AddIconPercent; // 배경 아이콘 뜨는 비율
}
