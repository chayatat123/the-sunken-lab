using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalBombs = 3;   // จำนวนทั้งหมด
    private int currentBombs = 0;

    void Awake()
    {
        instance = this;
    }

    public void BombPlaced()
    {
        currentBombs++;

        Debug.Log("วางระเบิด: " + currentBombs);

        if (currentBombs >= totalBombs)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("ชนะแล้ว!");
        SceneManager.LoadScene("WinScene"); // 🔥 ใส่ชื่อ Scene ของคุณ
    }
}