using UnityEngine;

public class Mouse : PoolableMono, GetTouch
{
    [SerializeField] private float _percent;

    public override void Init()
    {
    }

    public bool Touch()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if (rand > _percent / 100f)
        {
            GameManager.Instance.Money += 1;
            PoolManager.Instance.Push(this);
            return false;
        }

        GameManager.Instance.PopupUI.SetActive(true);
        GameManager.Instance.GamePlay = false;

        PoolManager.Instance.Push(this);
        return true;
    }
}
