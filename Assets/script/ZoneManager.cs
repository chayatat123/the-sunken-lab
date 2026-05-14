using UnityEngine;
using TMPro;

public class ZoneManager : MonoBehaviour
{
    [Header("Stage Settings")]
    public int currentStage = 1;
    public int killsRequired = 3;
    public int currentKills = 0;

    [Header("UI")]
    public TMP_Text zoneTaskText;

    void Start()
    {
        // 🔥 บังคับเริ่มใหม่ทุกครั้ง (กัน Inspector เพี้ยน)
        currentStage = 1;
        SetStage(currentStage);
    }

    public void SetStage(int stage)
    {
        // 🔥 กัน stage เกิน
        currentStage = Mathf.Clamp(stage, 1, 4);

        switch (currentStage)
        {
            case 1: killsRequired = 3; break;
            case 2: killsRequired = 5; break;
            case 3: killsRequired = 10; break;
            case 4: killsRequired = 1; break;
        }

        currentKills = 0;
        UpdateUIExternal();

        Debug.Log("ตอนนี้อยู่ Stage: " + currentStage);
    }

    public void OnEnemyKilled()
    {
        currentKills++;

        int left = Mathf.Max(0, killsRequired - currentKills);

        if (zoneTaskText != null)
        {
            zoneTaskText.text = "Enemies Left: " + left;
        }

        if (currentKills >= killsRequired)
        {
            if (currentStage == 4)
            {
                Debug.Log("จบบอสแล้ว!");

                if (zoneTaskText != null)
                {
                    zoneTaskText.text = "MISSION COMPLETE!";
                    zoneTaskText.color = Color.cyan;
                }
            }
            else
            {
                if (zoneTaskText != null)
                {
                    zoneTaskText.text = "Press F to Plant Bomb";
                    zoneTaskText.color = Color.green;
                }
            }
        }
    }

    public void UpdateUIExternal()
    {
        if (zoneTaskText == null) return;

        zoneTaskText.color = Color.white;

        if (currentStage == 4)
        {
            zoneTaskText.text = "Kill the Boss!";
        }
        else
        {
            zoneTaskText.text = "Enemies Left: " + killsRequired;
        }
    }
}