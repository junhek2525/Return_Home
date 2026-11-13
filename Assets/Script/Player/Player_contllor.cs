using UnityEngine;

public class Player_contllor : MonoBehaviour
{


    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveInput;

    public enum direction {L,R,U,D };
    public direction Current_direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        directions();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );


    }
    public void directions()
    {
        if (Input.GetKey(KeyCode.A) && Current_direction != direction.L)
        {
            Current_direction = direction.L;
        }
        if (Input.GetKey(KeyCode.D) && Current_direction != direction.R)
        {
            Current_direction = direction.R;
        }
    }
}
