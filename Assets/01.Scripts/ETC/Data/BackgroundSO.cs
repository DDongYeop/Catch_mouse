using UnityEngine;

[CreateAssetMenu (menuName = "SO/Data/Background", fileName = "Background")]
public class BackgroundSO : ScriptableObject
{
    public BackgroundType Type;
    public string Name;
    public Sprite Image;
    public int Money;
}
