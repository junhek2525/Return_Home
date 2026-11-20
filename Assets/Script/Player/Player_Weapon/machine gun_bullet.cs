using UnityEngine;

public class machinegun_bullet : MonoBehaviour
{
    private float damage;
    private float speed;
    private float lifeTime;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float dmg, float spd, float time, Vector2 direction)
    {
        damage = dmg;
        speed = spd;
        lifeTime = time;

        rb.linearVelocity = direction.normalized * speed;

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // damage를 이용해 적에게 데미지 적용
            enemy_AI enemy = other.GetComponent<enemy_AI>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
