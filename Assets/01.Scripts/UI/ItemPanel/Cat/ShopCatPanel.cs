using UnityEngine;

public class ShopCatPanel : MonoBehaviour
{
    private Transform _contectTrm;

    [Header("SpawnObj")]
    [SerializeField] private GameObject _horizontalLayoutGroup;
    [SerializeField] private CatPanel _catPanel;
    private Transform _currentHorizontal;

    private void Awake() 
    {
        _contectTrm = transform.GetChild(0).GetChild(0).GetChild(0);
    }

    private void OnEnable() 
    {
        for (int i = 0; i < (int)CatType.END; ++i)
        {
            if (i % 2 == 0)
                _currentHorizontal = Instantiate(_horizontalLayoutGroup, _contectTrm).transform;
            CatPanel panel = Instantiate(_catPanel, _currentHorizontal);
            panel.Init((CatType)i);
        }
    }
}
