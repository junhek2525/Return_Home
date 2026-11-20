
using UnityEngine;

public class Player_contllor : MonoBehaviour
{


    [Header("Player Stats")]
    [SerializeField] public float Speed = 5f;
    [SerializeField] public float jumpPower = 10f;
    [SerializeField] public float Health = 100f;
    [SerializeField] public float Attack = 10;
    [SerializeField] public float Defense = 10;





    public Vector2 attacksize = new Vector2(0.9f, 0.9f);
    public float attackDistance = 0.8f;

    public LayerMask enemyLayer;
    public LayerMask layerMask;

    public Transform groundpos;
    public Transform attackpos;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool Jumping;

    public enum direction { L, R, U, D }
    public direction Current_direction = direction.R;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetAttackPosition();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        directions();

        // 바닥 체크
        Jumping = !Physics2D.OverlapCircle(
            groundpos.position,
            groundCheckRadius,
            layerMask
        );
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveInput * Speed,
            rb.linearVelocity.y
        );
    }

    void directions()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Current_direction != direction.L)
            {
                Current_direction = direction.L;
                SetAttackPosition();
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Current_direction != direction.R)
            {
                Current_direction = direction.R;
                SetAttackPosition();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !Jumping)
            Jump();

        if (Input.GetKeyDown(KeyCode.E))
            Attacking();
    }

    // 공격 위치 계산
    void SetAttackPosition()
    {
        float dir = Current_direction == direction.L ? -1f : 1f;

        attackpos.localPosition = new Vector3(
            dir * attackDistance,
            0f,
            0f
        );
    }

    void Attacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(
            attackpos.position,
            attacksize,
            0f,
            enemyLayer
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("적 공격 성공!");
        }
    }
    public void Damageing(float damage)
    {
        Health -= damage;

        if(Health <= 0f)
        {

        }
    }
    public void Jump()
    {
        Jumping = true;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpPower
        );
    }

    private void OnDrawGizmos()
    {
        // 바닥 체크 범위
        if (groundpos != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(
                groundpos.position,
                groundCheckRadius
            );
        }

        // 공격 범위
        if (attackpos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(attackpos.position, attacksize);
        }

    }
}
