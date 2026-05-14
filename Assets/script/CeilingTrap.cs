using UnityEngine;

public class CeilingTrap : MonoBehaviour
{
    [Header("Settings")]
    public GameObject door;          // ลากประตูมาใส่
    public GameObject ceilingSpike;  // ลากเพดานหนามมาใส่
    public float fallSpeed = 2f;     // ความเร็วในการตกลงมา
    public float stopYCoord = 0.5f;  // จุดต่ำสุดที่หนามจะหยุด (ถ้าไม่โดนผู้เล่นก่อน)

    private bool isActivated = false;

    void Update()
    {
        // ถ้ากับดักทำงานแล้ว ให้เพดานค่อยๆ เลื่อนลงตามแกน Y
        if (isActivated && ceilingSpike != null)
        {
            if (ceilingSpike.transform.position.y > stopYCoord)
            {
                ceilingSpike.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // เมื่อผู้เล่นเดินผ่านจุด Trigger
        if (other.CompareTag("Player") && !isActivated)
        {
            ActivateTrap();
        }
    }

    void ActivateTrap()
    {
        isActivated = true;
        if (door != null) door.SetActive(true); // ปิดประตูขังผู้เล่น
        Debug.Log("กับดักทำงาน! ประตูปิดและเพดานกำลังถล่ม!");
    }

    // ฟังก์ชันสำหรับ Reset เพดาน (เรียกใช้ตอน Respawn ถ้าต้องการ)
    public void ResetTrap(Vector3 originalPos)
    {
        isActivated = false;
        if (door != null) door.SetActive(false);
        ceilingSpike.transform.position = originalPos;
    }
}