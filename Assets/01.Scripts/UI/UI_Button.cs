using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class UI_Button : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public UnityEvent OnButtonDragEvt;
    public UnityEvent OnButtonClickEvt;

    public virtual void OnDrag(PointerEventData eventData)
    {
        OnButtonDragEvt?.Invoke();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClickEvt?.Invoke();
    }
}
