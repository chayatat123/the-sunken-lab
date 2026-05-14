using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isBoss = false;
    public GameObject door;

    private ZoneManager zm;

    void Start()
    {
        currentHealth = maxHealth;

        zm = FindAnyObjectByType<ZoneManager>();

        // 👇 ถ้าเป็นบอส → เซ็ต max HP ให้ UI
        if (CompareTag("Boss"))
        {
            BossUIManager.instance.SetMaxHP(maxHealth);
        }
    }


    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        // 👇 อัปเดตหลอดเลือด
        if (CompareTag("Boss"))
        {
            BossUIManager.instance.UpdateHP(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 🔥 ทุกตัวนับ kill หมด (รวมบอส)
        if (zm != null)
        {
            zm.OnEnemyKilled();
        }

        // 🔥 ถ้าเป็นมอนธรรมดา
        if (!isBoss)
        {
            ScoreManager.instance.AddScore(10);
        }

        // 🔥 ถ้าเป็นบอส
        if (isBoss)
        {
            if (door != null)
            {
                door.SetActive(false);
                Debug.Log("Boss ตาย เปิดประตู!");
            }

            ScoreManager.instance.AddScore(100);
        }

        Debug.Log(gameObject.name + " ตายแล้ว");

        // 🔥 ซ่อน UI บอส
        if (CompareTag("Boss"))
        {
            BossUIManager.instance.HideBoss();
        }

        Destroy(gameObject);
    }
}