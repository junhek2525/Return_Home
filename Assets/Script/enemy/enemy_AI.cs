using UnityEngine;

public class enemy_AI : MonoBehaviour
{


    public enemy_stat stats;

    private Rigidbody2D rb;
    public Vector2 attacksize = new Vector2(0.9f, 0.9f);
    public LayerMask groundLayer;


    private float health;
    private float attack;
    private float defense;
    private float speed;

    public bool skilling = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        health = stats.Health;
        attack = stats.attack;
        defense = stats.defense;
        speed = stats.speed;

        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, attacksize, 0f);

        foreach (Collider2D col in hit)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("플레이어 감지!");
            }
        }

        Move();    
    }


    public void Move()
    {
        //transform.position = new Vector3(1f, 0f, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, attacksize);
    }
}
