using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public TMP_Text questText;

    void Awake()
    {
        instance = this;
    }

    public void BossKilled()
    {
        Debug.Log("บอสตายแล้ว!");

        questText.color = Color.green;
        questText.text = "PLACE THE LAST BOMB!";
    }
}