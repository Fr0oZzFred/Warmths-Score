using UnityEngine;

public class SortingOrderFix : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p) {
            p.GetComponent<SpriteRenderer>().sortingOrder = 30;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p) {
            p.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
    }
}
