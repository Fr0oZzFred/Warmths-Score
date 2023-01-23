using UnityEngine;
using UnityEngine.Events;

public class MouseTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent Event;
    private void OnMouseDown() {
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        Event.Invoke();
        Cursor.SetCursor(GameManager.Instance.NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseOver() {
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        Cursor.SetCursor(GameManager.Instance.TongueCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit() {
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        Cursor.SetCursor(GameManager.Instance.NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
