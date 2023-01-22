using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour {
    [SerializeField] UnityEvent Event;

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p) {
            Event.Invoke();
        }
    }
}
