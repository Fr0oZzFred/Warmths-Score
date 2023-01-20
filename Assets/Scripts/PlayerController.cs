using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 3.0f;
    Rigidbody2D rb;
    float horizontal;
    float vertical;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Vector2 position = rb.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }
}
