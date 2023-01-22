using UnityEngine;
using UnityEngine.Events;

public class InteractibleObjects : MonoBehaviour {
    [SerializeField] UnityEvent onClick;
    [SerializeField] GameObject prefab = null;
    private void OnMouseDown() {
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos.z = 0;
        Vector3 d = clickPos - GameManager.Instance.Player.transform.position;
        if (d.magnitude < ZoneManager.Instance.Radius) return;
        onClick.Invoke();
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
