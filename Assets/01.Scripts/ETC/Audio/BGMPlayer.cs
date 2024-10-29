using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
}
