using UnityEngine;

public class InteractibleObjects : MonoBehaviour
{
    private void OnMouseDown() {
        gameObject.SetActive(false);
        WorldManager.Instance.SetGameProgression(1);
    }
}
