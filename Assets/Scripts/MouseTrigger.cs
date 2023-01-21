using UnityEngine;
using UnityEngine.Events;

public class MouseTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent Event;
    private void OnMouseDown() {
        Event.Invoke();
    }
}
