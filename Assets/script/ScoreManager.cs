using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    void Awake()
    {
        // 🔥 กันซ้ำ + ไม่โดนลบตอนเปลี่ยนฉาก
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 👈 สำคัญ
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}