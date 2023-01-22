using UnityEngine;
using UnityEngine.Events;

public class InteractibleObjects : MonoBehaviour {
    [SerializeField] UnityEvent onClick;
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
    }
    public void TryToWearWater(int index) {
        if (!GameManager.Instance.Player.WearItem(index)) return;
    }
}
