using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    public float speed = 20f;
    public float drag = 0.1f;

    public bool isEnemyBullet = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        rb.linearDamping = drag;

        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        

        // ❌ กันยิงพวกเดียวกัน
        if (isEnemyBullet && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }

        // 🔥 หา HealthSystem แบบ "ชัวร์กว่า"
        HealthSystem hp = collision.collider.GetComponent<HealthSystem>();

        if (hp == null)
            hp = collision.collider.GetComponentInParent<HealthSystem>();

        if (hp != null)
        {
            hp.TakeDamage(damage);
            
        }

        // 🔫 Enemy ยิง Player
        if (isEnemyBullet && collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}