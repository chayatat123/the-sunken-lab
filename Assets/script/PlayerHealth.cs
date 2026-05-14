using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Respawn respawn;

    void Start()
    {
        currentHealth = maxHealth;
        respawn = GetComponent<Respawn>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("โดนยิง! เลือดเหลือ: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("ผู้เล่นตาย!");

        if (respawn != null)
        {
            respawn.RespawnPlayer();
        }

        currentHealth = maxHealth; // รีเลือด
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}