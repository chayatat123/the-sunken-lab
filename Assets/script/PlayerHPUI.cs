using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public Image hpBar;          // ลาก Image มาใส่
    public PlayerHealth player;  // ลาก player มาใส่

    void Update()
    {
        if (player != null)
        {
            float current = player.GetCurrentHealth();
            float max = player.maxHealth;

            hpBar.fillAmount = current / max;
        }
    }
}