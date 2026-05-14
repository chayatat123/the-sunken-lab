using UnityEngine;
using TMPro;

public class WinUI : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        // ✅ ปลดล็อกเมาส์
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // แสดงคะแนน
        if (ScoreManager.instance != null)
        {
            scoreText.text = "SCORE: " + ScoreManager.instance.score;
        }
    }
}