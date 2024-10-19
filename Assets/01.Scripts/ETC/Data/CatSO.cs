using UnityEngine;

[CreateAssetMenu (menuName = "SO/Data/Cat", fileName = "Cat")]
public class CatSO : ScriptableObject
{
    public CatType Type;
    public string Name;
    public Sprite Image;
    public int Money;
}
