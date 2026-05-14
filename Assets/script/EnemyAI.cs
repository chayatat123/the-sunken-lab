using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    [Header("Movement")]
    public float moveDistance = 2f;
    public float moveSpeed = 2f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.5f;
    public float bulletSpeed = 15f;

    private Vector3 startPos;
    private float nextFireTime = 0f;

    void Start()
    {
        startPos = transform.position;

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        MoveSideToSide();
        LookAtPlayer();
        Shoot();
    }

    void MoveSideToSide()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(startPos.x + offset, transform.position.y, transform.position.z);
    }

    void LookAtPlayer()
    {
        if (player == null) return;

        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        if (dir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        if (player == null) return;

        if (!CanSeePlayer()) return;

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

    bool CanSeePlayer()
    {
        Vector3 dir = player.position - firePoint.position;

        if (Physics.Raycast(firePoint.position, dir.normalized, out RaycastHit hit, 100f))
        {
            return hit.transform.CompareTag("Player");
        }

        return false;
    }
}
