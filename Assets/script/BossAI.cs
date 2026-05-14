using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform player;

    [Header("Movement")]
    public float moveSpeed = 3f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float bulletSpeed = 20f;

    private float nextFireTime = 0f;
    private HealthSystem hp;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;

        hp = GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (player == null) return;

        MoveToPlayer();
        LookAtPlayer();
        Shoot();
        PhaseCheck();
    }

    void MoveToPlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void LookAtPlayer()
    {
        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        if (dir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = firePoint.forward * bulletSpeed;

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
            b.isEnemyBullet = true;
    }

    void PhaseCheck()
    {
        if (hp == null) return;

        // 🔥 เลือดต่ำ = โหมดคลั่ง
        if (hp.currentHealth <= hp.maxHealth / 2)
        {
            fireRate = 0.5f;   // ยิงเร็วขึ้น
            moveSpeed = 5f;    // วิ่งเร็วขึ้น
        }
    }
}