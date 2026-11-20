using Unity.VisualScripting;
using UnityEngine;

public class Weapon_machinegun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject projectilePrefab;
    private Player_contllor player_Contllor;
    public Transform firePoint;

    [Header("Projectile Stats")]
    public float damage = 10f;
    public float speed = 10f;
    public float lifeTime = 0.5f;
    private void Start()
    {
        player_Contllor = GetComponent<Player_contllor>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject obj = Instantiate(projectilePrefab,firePoint.position,firePoint.rotation);

        machinegun_bullet projectile = obj.GetComponent<machinegun_bullet>();

        projectile.Initialize(damage, player_Contllor.Current_direction == Player_contllor.direction.L ? -speed : speed, lifeTime, firePoint.right);
    }
}



