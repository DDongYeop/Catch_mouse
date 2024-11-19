using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    [Header("Positon")]
    [SerializeField] private float _xPosition;
    [SerializeField] private float _yPosition;

    [Header("Time")]
    [SerializeField] private float _spawnTime;
    private float _addTime = 0;

    [Header("Percent")]
    [SerializeField] private float _spawnPercent;

    private void Update() 
    {
        if (GameManager.Instance.GamePlay)
            MouseSpawn();
    }

    private void MouseSpawn() 
    {
        _addTime += Time.deltaTime;
        if (_addTime < _spawnTime)
            return;

        _addTime -= _spawnTime;
        float percent = Random.Range(0.0f, 1.0f);
        if ((_spawnPercent + Background.CurrentBackground.AddIconPercent) / 100f < percent)
            return;

        Mouse mouse = PoolManager.Instance.Pop("Mouse") as Mouse;
        mouse.transform.position = new Vector2(Random.Range(-_xPosition, _xPosition), Random.Range(-_yPosition, _yPosition));
    }
}
