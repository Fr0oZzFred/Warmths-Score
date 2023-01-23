using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class MouseTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent Event;
    [SerializeField] List<int> acceptedItems;
    private void OnMouseDown() {
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        bool found = false;
        foreach (var idx in acceptedItems) {
            if(GameManager.Instance.Player.WearingItem == idx) {
                found = true;
            }
        }
        if (!found) return;
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
