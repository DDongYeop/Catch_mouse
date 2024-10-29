public class Mouse : PoolableMono, GetTouch
{
    public override void Init()
    {
    }

    public bool Touch()
    {
        GameManager.Instance.PopupUI.SetActive(true);
        GameManager.Instance.GamePlay = false;

        PoolManager.Instance.Push(this);
        return true;
    }
}
