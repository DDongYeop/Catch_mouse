using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_SceneChangeButton : UI_Button
{
    [SerializeField] private int _sceneCnt;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        SceneManager.LoadScene(_sceneCnt);
    }
}
