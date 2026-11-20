
using UnityEngine;

public class Player_contllor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 10f;
    public Vector2 attacksize = new Vector2(0.9f, 0.9f);
    public float attackDistance = 0.8f;

    private bool Jumping = false;

    private Rigidbody2D rb;
    private float moveInput;

    public enum direction { L, R, U, D };
    public direction Current_direction;

    public Transform attackpos;
    public Transform groundpos;
    public LayerMask layerMask;

    public float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        directions();

        // 바닥에 닿았는지 검사
        Jumping = !Physics2D.OverlapCircle(groundpos.position,groundCheckRadius,layerMask);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("발견!");
        }
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
        if (Input.GetKey(KeyCode.A))
        {
            Current_direction = direction.L;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Current_direction = direction.R;
        }

        if (Input.GetKeyDown(KeyCode.W) && !Jumping)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }
    void SetAttackPosition()
    {
        switch (Current_direction)
        {
            case direction.L:
                attackpos.localPosition = new Vector2(-attackDistance, 0);
                break;

            case direction.R:
                attackpos.localPosition = new Vector2(attackDistance, 0);
                break;

            case direction.U:
                attackpos.localPosition = new Vector2(0, attackDistance);
                break;

            case direction.D:
                attackpos.localPosition = new Vector2(0, -attackDistance);
                break;
        }
    }
    void Attack()
    {
        //Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(
        //    attackpos.position,
        //    attackSize,
        //    0f,
        //    enemyLayer
        //);

        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    Debug.Log("적 공격 성공!");

        //    // 나중에 적 체력 감소 코드 추가
        //}
    }
    public void Jump()
    {
        Jumping = true;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpPower
        );
    }

    // Scene에서 바닥 체크 범위 확인
    private void OnDrawGizmos()
    {
        if (groundpos != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(
                groundpos.position,
                groundCheckRadius
            );
        }
        if (attackpos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, attacksize);
        }

    }
    
}
