using UnityEngine;
using UnityEngine.Events;

public class MouseTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent Event;
    private void OnMouseDown() {
        Event.Invoke();
        Cursor.SetCursor(GameManager.Instance.NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseOver() {
        Cursor.SetCursor(GameManager.Instance.TongueCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit() {
        Cursor.SetCursor(GameManager.Instance.NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
