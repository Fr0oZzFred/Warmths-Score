using System.Collections;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    Vector3[] positions = new Vector3[2];
    bool coroutineRunnning;
    [SerializeField] float delay = 0.005f;

    private void Start() {
        line.startWidth = 0.1f;
        line.endWidth = 0.2f;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (coroutineRunnning) return;
            StartCoroutine(OnClick(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }

    IEnumerator OnClick(Vector3 clickPos) {
        clickPos.z = 0;
        Vector3 d = clickPos - GameManager.Instance.Player.transform.position;
        if (d.magnitude < ZoneManager.Instance.Radius) yield break;

        coroutineRunnning = true;
        GameManager.Instance.Player.StopMovement();
        positions[0] = gameObject.transform.position;
        line.enabled = true;

        for (float t = 0; t <= 1.0f; t+= 0.05f) {
            positions[1] = Vector3.Lerp(positions[0], clickPos, t);
            line.SetPositions(positions);
            positions[0].z = positions[1].z = 0f;
            yield return new WaitForSecondsRealtime(delay);
        }

        for (float t = 1.0f; t >= 0.0f; t -= 0.05f) {
            positions[1] = Vector3.Lerp(positions[0], clickPos, t);
            line.SetPositions(positions);
            positions[0].z = positions[1].z = 0f;
            yield return new WaitForSecondsRealtime(delay);
        }

        line.enabled = false;
        GameManager.Instance.Player.enabled = true;
        coroutineRunnning = false;
    }
}
