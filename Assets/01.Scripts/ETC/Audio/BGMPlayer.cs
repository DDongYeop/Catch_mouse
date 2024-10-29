using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene(1);
    }
}
