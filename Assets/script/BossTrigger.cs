using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject bossUI; // เอา UI ทั้งหมดมารวม
    public GameObject boss;   // ตัวบอส

    void Start()
    {
        bossUI.SetActive(false); // ซ่อนตอนแรก
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossUI.SetActive(true); // แสดง UI
            boss.SetActive(true);   // เปิดบอส (ถ้ายังไม่เปิด)
        }
    }
}