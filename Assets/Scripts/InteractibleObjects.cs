using UnityEngine;
using UnityEngine.Events;

public class InteractibleObjects : MonoBehaviour {
    [SerializeField] UnityEvent onClick;
    [SerializeField] GameObject prefab = null;

    private void OnMouseDown() {
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos.z = 0;
        Vector3 d = clickPos - GameManager.Instance.Player.transform.position;
        if (d.magnitude < ZoneManager.Instance.Radius) return;
        if (ZoneManager.Instance.idx == 0) return;
        onClick.Invoke();
        Cursor.SetCursor(GameManager.Instance.NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseOver() {
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos.z = 0;
        Vector3 d = clickPos - GameManager.Instance.Player.transform.position;
        if (d.magnitude < ZoneManager.Instance.Radius) return;
        if (ZoneManager.Instance.idx == 0) return;
        Cursor.SetCursor(GameManager.Instance.TongueCursor, Vector2.zero,CursorMode.ForceSoftware);
    }
    private void OnMouseExit() {
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        Cursor.SetCursor(GameManager.Instance.NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void TryToWear(int index) {
        if (!GameManager.Instance.Player.WearItem(index)) return;

        gameObject.SetActive(false);
        TryCreatePrefab();
    }
    public void TryToWearWater(int index) {
        if (GameManager.Instance.Player.WearingItem != 3) return;
        if (!GameManager.Instance.Player.WearItem(index)) return;

        GameManager.Instance.Player.tongue.FirstPrefab = GameManager.Instance.Player.grabbedOBJ;
        GameManager.Instance.Player.grabbedOBJ = null;
        TryCreatePrefab();
    }
    void TryCreatePrefab() {
        if (!prefab) return;
        GameManager.Instance.Player.tongue.GrabedPrefab = Instantiate(prefab, this.transform.position, Quaternion.identity);
    }
}
