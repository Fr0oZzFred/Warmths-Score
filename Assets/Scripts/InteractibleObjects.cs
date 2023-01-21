using UnityEngine;
using UnityEngine.Events;

public class InteractibleObjects : MonoBehaviour {
    [SerializeField] UnityEvent onClick;
    private void OnMouseDown() {
        onClick.Invoke();
    }

    public void TryToWear(int index) {
        if (!GameManager.Instance.Player.WearItem(index)) return;

        gameObject.SetActive(false);
    }
}
