using UnityEngine;

public class enemy_AI : MonoBehaviour
{


    public enemy_stat stats;

    private Rigidbody2D rb;
    public Vector2 attacksize = new Vector2(0.9f, 0.9f);
    public LayerMask groundLayer;
    public enum EnemyState{Idle,Move,Chase,Attack,Return}
    [Header("Enemy Settings")]
    public EnemyState currentState = EnemyState.Idle;

    private Transform player;

    private float Maxhealth;
    private float health;
    private float attack;
    private float defense;
    private float speed;
    private float collisioning_delay;
    private float collisioning_delaying;

    public bool skilling = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Maxhealth = stats.Health;
        health = Maxhealth;
        attack = stats.Attack;
        collisioning_delay = stats.collisioning_delay;
        defense = stats.Defense;
        speed = stats.speed;


        rb = GetComponent<Rigidbody2D>(); 
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, attacksize, 0f);

        foreach (Collider2D col in hit)
        {
            if (col.CompareTag("Player") && collisioning_delaying <= 0f)
            {
                Debug.Log("플레이어 감지!");

                Player_contllor player = col.GetComponent<Player_contllor>();
                player.Damageing(attack);
                collisioning_delaying = collisioning_delay;
            }
        }

        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;

            case EnemyState.Chase:
                Chase();
                break;

            case EnemyState.Attack:
                Attack();
                break;

            case EnemyState.Return:
                Return();
                break;
        }
        if (collisioning_delaying > 0f)
        {
            collisioning_delaying -= Time.deltaTime;
        }
    }

    void Idle()
    {
        //if (player == null) return;

        //float distance = Vector2.Distance(transform.position, player.position);

        //if (distance <= detectRange)
        //{
        //    currentState = EnemyState.Chase;
        //}
    }

    void Chase()
    {
        //if (player == null) return;

        //float distance = Vector2.Distance(transform.position, player.position);

        //if (distance > detectRange * 1.5f)
        //{
        //    currentState = EnemyState.Return;
        //    return;
        //}

        //if (distance <= attackRange)
        //{
        //    currentState = EnemyState.Attack;
        //    return;
        //}

        //Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;

        //transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        //if (player == null) return;

        //float distance = Vector2.Distance(transform.position, player.position);

        //if (distance > attackRange)
        //{
        //    currentState = EnemyState.Chase;
        //    return;
        //}

        //Debug.Log("적 공격!");
    }

    void Return()
    {
        //transform.position = Vector2.MoveTowards(
        //    transform.position,
        //    startPosition,
        //    moveSpeed * Time.deltaTime
        //);

        //if (Vector2.Distance(transform.position, startPosition) < 0.1f)
        //{
        //    currentState = EnemyState.Idle;
        //}
    }
    public void Move()
    {
        //transform.position = new Vector3(1f, 0f, 0f);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;  

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, attacksize);
    }
}
