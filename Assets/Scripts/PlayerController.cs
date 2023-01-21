using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 3.0f;
    Rigidbody2D rb;
    Animator animator;
    float horizontal;
    float vertical;
    bool diagonal = false;
    public int WearingItem { get; private set; }


    void Start() {
        WearingItem = -1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal >= 1.0f && vertical >= 1.0f) {
            diagonal = true;
        }
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }

    void FixedUpdate() {
        Vector2 position = rb.position;
        if (diagonal) {
            position.x += speed * horizontal * Time.deltaTime * 0.707f;
            position.y += speed * vertical * Time.deltaTime * 0.707f;
        } else {
            position.x += speed * horizontal * Time.deltaTime;
            position.y += speed * vertical * Time.deltaTime;
        }

        rb.MovePosition(position);
    }

    public bool WearItem(int index) {
        if (WearingItem == 3 && index == 4) {
            WearingItem = index;
            return true;
        }
        if (WearingItem > -1) return false;


        WearingItem = index;
        return true;
    }

    public void UnWear() {
        WearingItem = -1;
    }
}
