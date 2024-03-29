using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 3.0f;
    [SerializeField] Transform grabbedOBJPos;
    public GameObject grabbedOBJ = null;
    public Tongue tongue;
    public Dialogue dialogue;
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
        if (GameManager.Instance.CurrentGameState != GameManager.GameStates.InGame) return;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        diagonal = ((Mathf.Abs(horizontal) >= 1.0f) && (Mathf.Abs(vertical) >= 1.0f));
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        if (grabbedOBJ) {
            grabbedOBJ.transform.position = grabbedOBJPos.position;
            grabbedOBJ.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        }
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

    public void StopMovement() {
        horizontal = vertical = 0;
        enabled = false;
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
        Destroy(grabbedOBJ);
    }
    public void SetAnimToIdle() {
        animator.SetFloat("Horizontal", 0.0f);
        animator.SetFloat("Vertical", 0.0f);
    }
}
