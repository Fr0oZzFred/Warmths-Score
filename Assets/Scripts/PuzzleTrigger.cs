using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    private void OnMouseDown() {
        PuzzleManager.Instance.TriggerEvent();
    }
}
