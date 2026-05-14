using TMPro;
using UnityEngine;
using UnityEngine.UI;     // ⭐ ต้องมีอันนี้
using TMPro;
public class BossUIManager : MonoBehaviour
{
    public static BossUIManager instance;

    public GameObject bossUI;
    public TMP_Text bossText;
    public Image bossHPFill;

    private float maxHP;

    void Awake()
    {
        instance = this;
        bossUI.SetActive(false);
    }

    public void SetMaxHP(float hp)
    {
        maxHP = hp;
        UpdateHP(hp);
    }

    public void ShowBoss(float hp)
    {
        bossUI.SetActive(true);
        bossText.text = "THE BOSS";
        SetMaxHP(hp);
    }

    public void UpdateHP(float currentHP)
    {
        bossHPFill.fillAmount = currentHP / maxHP;
    }

    public void HideBoss()
    {
        bossUI.SetActive(false);
    }
}