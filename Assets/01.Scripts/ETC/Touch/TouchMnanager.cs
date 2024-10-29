using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMnanager : MonoBehaviour
{
    private void Update() 
    {
        if (Input.GetMouseButtonDown(0)) 
            Touch();
    }

    private void Touch()
    {
        PoolManager.Instance.Pop("TouchSound");
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        if (EventSystem.current.IsPointerOverGameObject()) // UI 켜져 있다면 
        {
            SpawnParticle(pos, "PawParticle");
            return;
        }

        RaycastHit2D hit2D = Physics2D.Raycast(pos, Vector2.zero, 1);
        
        if (hit2D && hit2D.transform.parent.TryGetComponent(out GetTouch touch))
        {
            if (touch.Touch())
            {
                SpawnParticle(pos, "MouseParticle");
                return;
            }
        }
        SpawnParticle(pos, "PawParticle");
    }

    private void SpawnParticle(Vector2 pos, string name)
    {
        Transform transform = PoolManager.Instance.Pop(name).transform;
        transform.position = pos;
    }
}
